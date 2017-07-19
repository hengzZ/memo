## Opencv Install on Ubuntu ##

1. Required Packages
```
sudo apt-get install build-essential
sudo apt-get install cmake git libgtk2.0-dev pkg-config libavcodec-dev libavformat-dev libswscale-dev
sudo apt-get install python-dev python-numpy libtbb2 libtbb-dev libjpeg-dev libpng-dev libtiff-dev libjasper-dev libdc1394-22-dev
```

2. Getting OpenCV Source Code
For example:
```
cd ~/<my_working_directory>
git clone https://github.com/opencv/opencv.git
git clone https://github.com/opencv/opencv_contrib.git
```

3. Building OpenCV from Source Using CMake  
```
Run cmake [<some optional parameters>] <path to the OpenCV source directory>
```
For example:
```
mkdir build
cd build
cmake -D CMAKE_BUILD_TYPE=Release -D CMAKE_INSTALL_PREFIX=/usr/local ../opencv
```
    * build type: CMAKE_BUILD_TYPE=Release\Debug
    * to build with modules from opencv_contrib set OPENCV_EXTRA_MODULES_PATH to <path to opencv_contrib/modules/>
    * set BUILD_DOCS for building documents
    * set BUILD_EXAMPLES to build all examples

    * PYTHON2(3)_EXECUTABLE = <path to python>
    * PYTHON_INCLUDE_DIR = /usr/include/python<version>
    * PYTHON_INCLUDE_DIR2 = /usr/include/x86_64-linux-gnu/python<version>
    * PYTHON_LIBRARY = /usr/lib/x86_64-linux-gnu/libpython<version>.so
    * PYTHON2(3)_NUMPY_INCLUDE_DIRS = /usr/lib/python<version>/dist-packages/numpy/core/include/

4. Build
```
make -j7 # runs 7 jobs in parallel
```

5. Install Libraries
```
sudo make install
```

## Uninstall ##
1. remove packages installed use apt-get
```
sudo apt-get autoremove -y libopencv-dev
```
2. remove all packages about opencv in / directory
```
sudo find / -name "*opencv*" -exec rm -i {} \;
```

## Reference ##
<http://docs.opencv.org/3.2.0/d7/d9f/tutorial_linux_install.html>

