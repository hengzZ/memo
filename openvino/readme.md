## OpenVINO

*Develop Multiplatform Computer Vision Solutions*

Installation: https://software.intel.com/en-us/articles/OpenVINO-Install-Linux


#### Model Optimizer

*Model Optimizer process assumes you have a network model trained using one of the supported frameworks.*
```
* Caffe
* TensorFlow
* MXNet
* Kaldi
* ONNX
```
***It support network models which can be converted to the ONNX* format***

###### 1. (Check) Please configure the Model Optimizer for the framework that was used to train the network. 
```bash
<INSTALL_DIR>/deployment_tools/model_optimizer/install_prerequisites
```
###### 2. Preparing and Optimizing Your Trained Model
* caffe: https://software.intel.com/en-us/articles/OpenVINO-Using-Caffe
* tensorflow: https://software.intel.com/en-us/articles/OpenVINO-Using-TensorFlow
* MXNet: https://software.intel.com/en-us/articles/OpenVINO-Using-MxNet
* ONNX: https://software.intel.com/en-us/articles/OpenVINO-Using-ONNX

###### 3. The layer list varies by framework. For full lists of supported layers for each framework, refer to the following pages:
* Supported Caffe Layers: https://software.intel.com/en-us/articles/OpenVINO-Using-Caffe#caffe-supported-layers
* Supported TensorFlow Layers: https://software.intel.com/en-us/articles/OpenVINO-Using-TensorFlow#tensorflow-supported-layers
* Supported MXNet Layers: https://software.intel.com/en-us/articles/OpenVINO-Using-MXNet#mxnet-supported-layers
* Supported ONNX Layers: https://software.intel.com/en-us/articles/OpenVINO-Using-ONNX#supported-onnx-layers


Go to the <INSTALL_DIR>/deployment_tools/model_optimizer directory <br>
Run the mo_tf.py script with a path to the MetaGraph .meta file to convert a model: <br>
```bash
mo_tf.py --input_meta_graph <INPUT_META_GRAPH>.meta
```


#### Custom Layer
please refer: https://software.intel.com/en-us/articles/OpenVINO-ModelOptimizer#caffe-models-with-custom-layers
