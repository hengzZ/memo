#### step 1: unpack the .tgz file
```
tar -zxf l_openvino_toolkit_p_2018.5.445.tgz
```
####
```
cd l_openvino_toolkit_p_2018.5.445
```
#### run a script to automatically download and install external software dependencies
```
sudo -E ./install_cv_sdk_dependencies.sh
```

###### If you have a previous version of the toolkit installed, rename or delete two directories:
###### • /home/<user>/inference_engine_samples
###### • /home/<user>/openvino_models


### step 2: Install
```
sudo ./install.sh
```

##### If you used root privileges to run the installer, it installs the Intel Distribution of OpenVINO toolkit in this directory: 
##### • /opt/intel/computer_vision_sdk_<version>/
###### (For simplicity, a symbolic link to the latest installation is also created: /opt/intel/computer_vision_sdk/)

##### If you used regular user privileges to run the installer, it installs the Intel Distribution of OpenVINO toolkit in this directory:
##### • /home/<user>/intel/computer_vision_sdk_<version>/
###### (For simplicity, a symbolic link to the latest installation is also created: /home/<user>/intel/computer_vision_sdk/)


#### step 3: Open the Installation guide at: [https://software.intel.com/en-us/articles/openvino-install-linux] and follow the guide instructions to complete the remaining tasks listed below:
* **Configure Model Optimizer**
* **Set Environment variables**
* **Run Demos to verify and compile samples**


#### 1. set the environment variables temporarily
```
source /opt/intel/computer_vision_sdk/bin/setupvars.sh
```

#### 2. configure the Model Optimizer for each framework separately
```
cd /opt/intel/computer_vision_sdk/deployment_tools/model_optimizer/install_prerequisites
sudo ./install_prerequisites_tf.sh
```

#### 3. run the image classification demo
```
cd /opt/intel/computer_vision_sdk/deployment_tools/demo
./demo_squeezenet_download_convert_run.sh
```