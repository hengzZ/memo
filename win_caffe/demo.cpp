/**
* Project:
*   include - caffe.pb.h
*   cpp     - caffe.pb.cc， demo.cpp
*/
#include <iostream>
#include <string>
#include <vector>
#include <exception>

#include <opencv2/core/core.hpp>
#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/highgui/highgui.hpp>
#include <opencv2/videoio/videoio.hpp>

#include <boost/algorithm/string.hpp>

#include <caffe/blob.hpp>
#include <caffe/net.hpp>
#include <caffe/data_transformer.hpp>


// Helper Functions

void softmaxOperator(std::vector<float>& result, int idxStart, int numClass, int stride, float temp)
{
	float sum = 0;
	float largest = -FLT_MAX;

	for (int i = 0; i<numClass; ++i) {
		if (result[idxStart + i*stride] > largest) largest = result[idxStart + i*stride];
	}
	for (int i = 0; i<numClass; ++i) {
		float e = exp(result[idxStart + i*stride] / temp - largest / temp);
		sum += e;
		result[idxStart + i*stride] = e;
	}
	for (int i = 0; i<numClass; ++i) {
		result[idxStart + i*stride] /= sum;
	}
}

void softmaxArray(std::vector<float>& result, int idxStart, int numClass, int numBox, int boxOffset, int location, int locOffset, int stride, float temp)
{
	for (int n = 0; n<numBox; ++n) {
		for (int loc = 0; loc<location; ++loc) {
			softmaxOperator(result, idxStart + n*boxOffset + loc*locOffset, numClass, stride, temp);
		}
	}
}

void logisticArray(std::vector<float>& result, int idxStart, const int n)
{
	for (int i = 0; i<n; ++i) {
		result[idxStart + i] = 1. / (1. + exp(-result[idxStart + i]));
	}
}

int entryIndex(int location, int entry, int grideWidth, int grideHeight, int numClass)
{
	int n = location / (grideWidth*grideHeight);
	int loc = location % (grideWidth*grideHeight);
	return n * (grideWidth*grideHeight) * (4 + 1 + numClass) + entry * (grideWidth*grideHeight) + loc;
}

void region(std::vector<float>& result, cv::Size inputSize, int numBox)
{
	int grideWidth = inputSize.width / 32;
	int grideHeight = inputSize.height / 32;
	int numClass = result.size() / (grideWidth*grideHeight*numBox) - 5;
	// Logistic activation for x,y and Pobj
	for (int n = 0; n<numBox; ++n) {
		int idx = entryIndex(n*grideWidth*grideHeight, 0, grideWidth, grideHeight, numClass);
		logisticArray(result, idx, 2 * grideWidth*grideHeight);
		idx = entryIndex(n*grideWidth*grideHeight, 4, grideWidth, grideHeight, numClass);
		logisticArray(result, idx, grideWidth*grideHeight);
	}
	// Softmax activation for classes
	int idx = entryIndex(0, 5, grideWidth, grideHeight, numClass);
	softmaxArray(result, idx, numClass, numBox, result.size() / numBox, grideWidth*grideHeight, 1, grideWidth*grideHeight, 1);
}

struct Box {
	float x, y, w, h;
};

void parseRegion(const std::vector<float>& result, cv::Size inputSize, int numBox, std::vector<Box>& boxes, std::vector<std::vector<float> >& probs, float threshold)
{
	int grideWidth = inputSize.width / 32;
	int grideHeight = inputSize.height / 32;
	int numClass = result.size() / (grideWidth*grideHeight*numBox) - 5;
	std::vector<double> regionBiases = { 1.08,1.19,  3.42,4.41,  6.63,11.38,  9.42,5.11,  16.62,10.52 };
	boxes.resize(grideWidth * grideHeight * numBox);
	probs.resize(grideWidth * grideHeight * numBox);
	for (int i = 0; i < grideWidth * grideHeight * numBox; i++)
	{
		probs[i].resize(numClass);
	}
	// One Box Block with (4 + 1 + num_class) channels
	// note: 4 means (x, y, width, height), 1 means Pobj
	for (int i = 0; i<grideWidth*grideHeight; ++i) {
		int row = i / grideWidth;
		int col = i % grideWidth;
		for (int n = 0; n<numBox; ++n) {
			int index = n*grideWidth*grideHeight + i;
			int box_index = entryIndex(index, 0, grideWidth, grideHeight, numClass);
			int obj_index = entryIndex(index, 4, grideWidth, grideHeight, numClass);
			float scale = result[obj_index];
			int stride = grideWidth*grideHeight;
			boxes[index].x = (col + result[box_index + 0 * stride]) / grideWidth;
			boxes[index].y = (row + result[box_index + 1 * stride]) / grideHeight;
			boxes[index].w = exp(result[box_index + 2 * stride]) * regionBiases[2 * n] / grideWidth;
			boxes[index].h = exp(result[box_index + 3 * stride]) * regionBiases[2 * n + 1] / grideHeight;

			for (int k = 0; k<numClass; ++k) {
				int class_index = entryIndex(index, 5 + k, grideWidth, grideHeight, numClass);
				float prob = scale * result[class_index];
				probs[index][k] = (prob > threshold) ? prob : 0;
			}
		}
	}
}

float boxIntersection(const Box& a, const Box& b);
float boxUnion(const Box& a, const Box& b);
float overlap(float x1, float w1, float x2, float w2);

float boxIor(const Box& a, const Box& b)
{
	float iora = boxIntersection(a, b) / (a.w * a.h);
	float iorb = boxIntersection(a, b) / (b.w * b.h);
	return (iora > iorb) ? iora : iorb;
}

float boxIou(const Box& a, const Box& b)
{
	return boxIntersection(a, b) / boxUnion(a, b);
}

float boxIntersection(const Box& a, const Box& b)
{
	float w = overlap(a.x, a.w, b.x, b.w);
	float h = overlap(a.y, a.h, b.y, b.h);
	if (w<0 || h<0) return 0;
	return w*h;
}

float boxUnion(const Box& a, const Box& b)
{
	return a.w * a.h + b.w * b.h - boxIntersection(a, b);
}

float overlap(float x1, float w1, float x2, float w2)
{
	float l1 = x1 - w1 / 2;
	float l2 = x2 - w2 / 2;
	float left = l1 > l2 ? l1 : l2;
	float r1 = x1 + w1 / 2;
	float r2 = x2 + w2 / 2;
	float right = r1 < r2 ? r1 : r2;
	return right - left;
}

void doSort(const std::vector<float>& result, cv::Size inputSize, int numBox, std::vector<Box>& boxes, std::vector<std::vector<float> >& probs, float iouThreshold, float iorThreshold)
{
	int grideWidth = inputSize.width / 32;
	int grideHeight = inputSize.height / 32;
	int numClass = result.size() / (grideWidth*grideHeight*numBox) - 5;

	int total = grideWidth * grideHeight * numBox;
	for (int i = 0; i<total; ++i) {
		int any_t = 0;
		for (int j = 0; j<numClass; ++j) {
			any_t = any_t || probs[i][j] > 0;
		}
		if (!any_t) continue;

		Box &a = boxes[i];
		for (int j = i + 1; j<total; ++j)
		{
			Box &b = boxes[j];
			if (boxIou(a, b) > iouThreshold) {
				for (int k = 0; k<numClass; ++k)
				{
					if (probs[i][k] < probs[j][k])
						probs[i][k] = 0.0;
					else
						probs[j][k] = 0.0;
				}
			}
			else if (boxIor(a, b) > iorThreshold) {
				for (int k = 0; k<numClass; ++k)
				{
					if (probs[i][k] < probs[j][k])
						probs[i][k] = 0.0;
					else
						probs[j][k] = 0.0;
				}
			}
		}
	}
}

int maxIndex(const std::vector<float>& a, int n)
{
	if (n <= 0) return -1;
	int i, max_i = 0;
	float maxn = a[0];
	for (i = 1; i < n; ++i) {
		if (a[i] > maxn) {
			maxn = a[i];
			max_i = i;
		}
	}
	return max_i;
}

struct ARectangle {
	int x;
	int y;
	int width;
	int height;
	int type;
	float prob;
};

int draw(const std::vector<float>& result, cv::Size inputSize, int numBox, cv::Mat& img, std::vector<Box>& boxes, std::vector<std::vector<float> >& probs, float threshold)
{
	int grideWidth = inputSize.width / 32;
	int grideHeight = inputSize.height / 32;
	int numClass = result.size() / (grideWidth*grideHeight*numBox) - 5;
	std::vector<ARectangle> rects;
	rects.clear();
	int num = grideWidth * grideHeight * numBox;
	int wImg = img.cols;
	int hImg = img.rows;
	for (int i = 0; i < num; ++i) {
		int kind = maxIndex(probs[i], numClass);
		float prob = probs[i][kind];
		if (prob > threshold) {
			const Box& b = boxes[i];

			int left = (b.x - b.w / 2.)*wImg;
			int right = (b.x + b.w / 2.)*wImg;
			int top = (b.y - b.h / 2.)*hImg;
			int bot = (b.y + b.h / 2.)*hImg;

			if (left < 0) left = 0;
			if (right > wImg - 1) right = wImg - 1;
			if (top < 0) top = 0;
			if (bot > hImg - 1) bot = hImg - 1;

			ARectangle rt;
			rt.x = left;
			rt.y = top;
			rt.width = right - left;
			rt.height = bot - top;
			rt.type = kind;
			rt.prob = prob;
			rects.push_back(rt);
		}
	}
	const std::vector<std::string> names = { "defect" };
	for (unsigned int i = 0; i < rects.size(); ++i) {
		int kind = rects[i].type;
		int w = rects[i].width;
		int h = rects[i].height;
		int x = rects[i].x + (w >> 1);
		int y = rects[i].y + (h >> 1);
		cv::Point leftTop = cv::Point(rects[i].x, rects[i].y);
		cv::Point rightBottom = cv::Point(rects[i].x + rects[i].width, rects[i].y + rects[i].height);
		if (0 == kind) {
			cv::rectangle(img, leftTop, rightBottom, cv::Scalar(0, 0 , 255), 11);
			putText(img, names.at(kind).c_str(), cv::Point(leftTop.x, leftTop.y - 5), CV_FONT_HERSHEY_COMPLEX, 2.5, cv::Scalar(0, 0, 255), 5);
		}
		else {
			cv::rectangle(img, leftTop, rightBottom, cv::Scalar(0, 255,255), 11);
			putText(img, names.at(kind).c_str(), cv::Point(leftTop.x, leftTop.y - 5), CV_FONT_HERSHEY_COMPLEX, 2.5, cv::Scalar(0, 255, 255), 5);
		}
	}
	return rects.size();
}


int main(int argc, char** argv)
{
	cv::VideoCapture capture(0);

	if (!capture.isOpened()) {
		std::cout << "cannot open video capture." << std::endl;
		return -1;
	}

	caffe::Caffe::set_mode(caffe::Caffe::CPU);
	boost::shared_ptr<caffe::Net<float> > net;
	net.reset(new caffe::Net<float>("tiny-yolo-voc-defect.prototxt", caffe::TEST));
	net->CopyTrainedLayersFrom("tiny-yolo-voc-defect_final.caffemodel");

	caffe::Blob<float>* inputBlob = net->input_blobs().at(0);
	int imgChannels = inputBlob->shape().at(1);
	cv::Size imgSize = cv::Size(inputBlob->shape().at(3), inputBlob->shape().at(2));  // NCHW

	const float scale = 0.0039215686;
	caffe::TransformationParameter param;
	param.set_scale(scale);
	boost::shared_ptr<caffe::DataTransformer<float> > dt;
	dt.reset(new caffe::DataTransformer<float>(param, caffe::TEST));

	cv::Mat image, imgResized;

	while (true) {
		capture >> image;

		image = cv::imread("testimage.bmp");

		if (image.empty()) {
			break;
		}

		if (imgChannels != image.channels()) break;
		if (image.size() != imgSize) {
			cv::resize(image, imgResized, imgSize);
		}
		else {
			imgResized = image;
		}


		dt->Transform(imgResized, inputBlob);
		net->Forward();
		boost::shared_ptr<caffe::Blob<float> > detecBlob = net->blob_by_name("result");

		int dims = detecBlob->count();
		const float* blobData = detecBlob->cpu_data();
		std::vector<float> detection;
		copy(blobData, blobData + dims, back_inserter(detection));

		// Speicify the threshold values
		int numBox = 5;
		float threshold = 0.2;
		float iouThreshold = 0.5;
		float iorThreshold = 0.5;
		// Parse the detection result
		std::vector<std::vector<float> > probs;
		std::vector<Box> boxes;
		region(detection, imgSize, numBox);
		parseRegion(detection, imgSize, numBox, boxes, probs, threshold);
		doSort(detection, imgSize, numBox, boxes, probs, iouThreshold, iorThreshold);
		int ret = draw(detection, imgSize, numBox, image, boxes, probs, threshold);

		std::cout << "defect number: " << ret << std::endl;

		cv::resize(image, imgResized, cv::Size(640,480));
		cv::imshow("demo", imgResized);
		int keyval = cv::waitKey(10);
		if (27 == keyval) break;
	}

	capture.release();
	cv::destroyAllWindows();
	return 0;
}
