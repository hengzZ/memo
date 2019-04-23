## Windows Caffe 环境安装


#### Part I - cuda 安装 (optional) 
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


#### Part II - Caffe 下载、编译
```
# 1. 下载 caffe 源码
https://github.com/BVLC/caffe/tree/windows

# 2. 安装 cmake 3.4 及以上版本
cmake-3.6.1-win64-x64.msi

# 3. Ninja release (.exe)
(将 ninja.exe 放置于 cmake.exe 目录)
https://github.com/ninja-build/ninja/releases

# 4. 编译、安装 caffe （管理员身份打开 cmd 窗口）
C:\Projects> git clone https://github.com/BVLC/caffe.git
C:\Projects> cd caffe
C:\Projects\caffe> git checkout windows
   # 修改 scripts\build_win.cmd 文件
:: **Edit any of the options inside build_win.cmd to suit your needs**
:: if NOT DEFINED WITH_NINJA set WITH_NINJA=1
:: if NOT DEFINED CMAKE_BUILD_SHARED_LIBS set CMAKE_BUILD_SHARED_LIBS=1
:: if NOT DEFINED RUN_TESTS set RUN_TESTS=1
   # 编译
C:\Projects\caffe> scripts\build_win.cmd
```
optional
```
# libraries_v140_x64_py27_1.1.0.tar.bz2 下载源
  （可手动下载然后保存到 .caffe/dependencies/download/）
https://github.com/willyd/caffe-builder/releases
```


#### Part III - Caffe Visual Studio 开发环境配置

##### 1. caffe 的 boost、glogs、opencv 等的依赖环境，都在 .caffe/dependencies/libraries_v140_x64_py27_1.1.0 目录 ！
##### 2. caffe 的环境在下载、编译目录下。
##### 3. 在工程中，添加 CPU_ONLY=1 宏定义
```
项目属性 -> C/C++ -> Preprocessor -> Preprocessor Definitions
CPU_ONLY=1
```

##### 头文件包含测试
```
#include <string>
#include <vector>
#include <iostream>
#include <cassert>
#include <vector>
#include <cmath>
#include <algorithm>

#include <opencv2/core.hpp>
#include <opencv2/imgcodecs.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>

#include "boost/algorithm/string.hpp"
#include "google/protobuf/text_format.h"

#include "caffe/blob.hpp"
#include "caffe/common.hpp"
#include "caffe/net.hpp"
#include "caffe/proto/caffe.pb.h"
#include "caffe/data_transformer.hpp"
#include "caffe/util/format.hpp"
#include "caffe/util/io.hpp"
#include "caffe/layer.hpp"
#include "caffe/layers/memory_data_layer.hpp"

int main(int argc, char** argv)
{
    std::cout << "include testing passes." << std::endl;
    return 0;
}
```

<br>

##### OpenCV 配置
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

##### caffe boost 配置
###### caffe 的 boost、glogs 等等的依赖环境，都在 .caffe/dependencies/libraries_v140_x64_py27_1.1.0 目录 ！！！
```
1. 配置 VC++ 目录
    * 包含目录 （include）
	* 库目录 （lib）
2. 链接器->输入
	* 附加依赖项 （release模式）
3. 运行时 dll 文件
``` 

##### caffe 环境配置
###### caffe 的头文件与库目录在下载、编译目录。
```
1. 配置 VC++ 目录
    * 包含目录 （include）
	* 库目录 （lib）
2. 链接器->输入
	* 附加依赖项 （release模式）
3. 运行时 dll 文件
```

<br>
<br>

#### OpenCV3 下载
```
下载 opencv3.0
```

##### Opencv Visual Studio 配置
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

##### Opencv 测试代码
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
