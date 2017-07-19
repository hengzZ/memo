# cuda install on Ubuntu14.04 #

## 1.pre-installation ##
1. Verify You Have a CUDA-Capable GPU
```
$ lspci | grep -i nvidia
```
2. Verify You Have a Supported Version of Linux
```
$ uname -m && cat /etc/*release
```
3. Verify the System Has gcc Installed
```
$ gcc --version
```
4. Verify the System has the Correct Kernel Headers and Development Packages Installed
```
$ uname -r
$ sudo apt-get install linux-headers-$(uname -r)
```

## 2.download cuda toolkit ##
[cuda toolkit](./images/cuda.png)  


## 3.uninstall previous installation ##
Use the following command to uninstall a Toolkit runfile installation:
```
$ sudo /usr/local/cuda-X.Y/bin/uninstall_cuda_X.Y.pl
```
Use the following command to uninstall a Driver runfile installation:
```
$ sudo /usr/bin/nvidia-uninstall
```
Use the following commands to uninstall a RPM/Deb installation:
```
$ sudo yum remove <package_name> # Redhat/CentOS 
$ sudo dnf remove <package_name> # Fedora 
$ sudo zypper remove <package_name> # OpenSUSE/SLES 
$ sudo apt-get --purge remove <package_name> # Ubuntu
```

## 4.Runfile Installation ##
1. Perform the **pre-installation** actions
2. Disable the Nouveau drivers  
```
$ lsmod | grep nouveau 
```
Create a file at /etc/modprobe.d/blacklist-nouveau.conf with the following contents:  
> blacklist nouveau
> options nouveau modeset=0  
```
$ sudo update-initramfs -u
```
3. Reboot into text mode  
> **Ctrl+Alt+F1** into text mode
> **Ctrl+Alt+F7** into graph mode
4. Verify that the Nouveau drivers are not loaded
```
lsmod |grep nouveau
```
5. stop lightdm
```
sudo /etc/init.d/lightdm stop
```
6. Run the installer:  
```
$ sudo sh cuda_<version>_linux.run
```
note: **--no-opengl-libs** Useful for systems where the display is driven by a non-NVIDIA GPU.  
7. Reboot the system to reload the graphical interface  
```
sudo /etc/init.d/lightdm start
ctrl+alt+F7
```
8. Verify the device nodes are created properly   
Check that the device files/dev/nvidia\* exist and have the correct (0666) file permissions.   
you can create them manually by using a startup script such as the one below:   
```
#!/bin/bash 

/sbin/modprobe nvidia 

if [ "$?" -eq 0 ]; then 
    # Count the number of NVIDIA controllers found. 
    NVDEVS=`lspci | grep -i NVIDIA` 
    N3D=`echo "$NVDEVS" | grep "3D controller" | wc -l` 
    NVGA=`echo "$NVDEVS" | grep "VGA compatible controller" | wc -l` 

    N=`expr $N3D + $NVGA - 1` 
    for i in `seq 0 $N`; do 
        mknod -m 666 /dev/nvidia$i c 195 $i 
    done 
    
    mknod -m 666 /dev/nvidiactl c 195 255 
else 
    exit 1 
fi 

/sbin/modprobe nvidia-uvm 

if [ "$?" -eq 0 ]; then 
    # Find out the major device number used by the nvidia-uvm driver 
    D=`grep nvidia-uvm /proc/devices | awk '{print $1}'` 
    mknod -m 666 /dev/nvidia-uvm c $D 0 
else 
    exit 1 
fi
```
9. Perform the post-installation actions
```
$ export PATH=/usr/local/cuda-8.0/bin${PATH:+:${PATH}}
$ export LD_LIBRARY_PATH=/usr/local/cuda-8.0/lib64${LD_LIBRARY_PATH:+:${LD_LIBRARY_PATH}}
```


## deb package install use PPA sources##
1. download deb package  
2. add PPA
```
sudo add-apt-repository ppa:graphics-drivers/ppa
sudo apt-get update
sudo apt-get install nvidia-381
```


## key signature ##
```
sudo apt-get install mokutil
sudo mokutil --import /usr/share/nvidia/nvidia-modsign-crt-*.der
```


## NOTE ##
* **BIOS Setting for ASUS motherboard** for post-installation
Advanced->System Agent Configuration->Graphics Configuration->Primary Display: PCIE or Auto  
Boot->Secure Boot->OS Type: other os  

