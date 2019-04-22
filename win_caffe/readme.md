## Windows Caffe 环境安装


#### (optional) cuda 安装
```
# cuda 下载
https://developer.nvidia.com/cuda-downloads
# local exe 安装方式
1. Launch the downloaded installer package.
2. Read and accept the EULA.
3. Select "next" to download and install all components.
4. Once the download completes, the installation will begin automatically.
5. Once the installation completes, click "next" to acknowledge the Nsight Visual Studio Edition installation summary.
6. Click "close" to close the installer.
7. Navigate to the CUDA Samples' nbody directory.
8. Open the nbody Visual Studio solution file for the version of Visual Studio you have installed. 
9. Open the "Build" menu within Visual Studio and click "Build Solution". 
10. Navigate to the CUDA Samples' build directory and run the nbody sample. 
# （optional） cuDNN 安装
https://developer.nvidia.com/cudnn
```


#### 1. Caffe 下载
```
# 下载源
https://github.com/BVLC/caffe/tree/windows
# 安装 cmake 3.4 及以上版本
cmake-3.6.1-win64-x64.msi
# Ninja release (.exe)
https://github.com/ninja-build/ninja/releases
# 编译、安装
C:\Projects> git clone https://github.com/BVLC/caffe.git
C:\Projects> cd caffe
C:\Projects\caffe> git checkout windows
:: Edit any of the options inside build_win.cmd to suit your needs
C:\Projects\caffe> scripts\build_win.cmd
```


#### 2. Visual Studio 配置
```

```


#### 3. OpenCV3 下载
```
下载 opencv3.0
```


#### 4. Visual Studio 配置
```
1. 配置 VC++ 目录
	* 包含目录 （include）
	* 库目录 （lib）
2. 链接器->输入
	* 附加依赖项 （release模式）
	opencv_ts300.lib
	opencv_world300.lib
3. 运行时 dll 文件
	opencv_world300.dll
```


#### 5. 测试代码
```
#include <opencv2/core.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>

using namespace cv;

int main(int argc, char** argv)
{
	Mat image = imread("Test.jpg");
	imwrite("testWriting.jpg", image);
	return 0;
}
```
