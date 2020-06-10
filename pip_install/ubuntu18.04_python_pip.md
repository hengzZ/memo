# Linux 系统安装

## 1 U盘挂载

``` bash
$ mount l                          #查看挂载列表
$ mkdir /mnt/xulin                 #创建挂载目录（挂载点）
# 插入U盘，查看U盘信息
$ sudo fdisk -l
$ sudo mount /dev/sdb1 /mnt/xulin  #/dev/sdb1为U盘设备文件 （-t 指定文件系统类型，可不指定）
```
``` bash
$ sudo umount /dev/sdb1            #断开与挂载点的关联
```


## 2 系统盘制作

- 下载系统iso镜像文件
- 使用 UltraISO 制作系统安装盘（U盘/光盘/软盘）


## 3 安装系统

- 重启，按 F12 进入 BIOS 配置界面
- 选择从 U 盘（系统安装盘）启动

```
1. Try Ubuntu without installing  (便携式操作系统，可用于重装系统前的文件拷贝。)
2. Install Ubuntu                 (系统安装)
```


## 4 安装中文输入法

- Region & Language > Input Sources > Manage Installed Languages > Install/Remove Languages > Chinese (simplified) > Apply
- 重启电脑
- Region & Language > Input Sources > "+" > Chinese > Chinese (Intelligent Pinyin) > Add

输入法切换：``Windows键 + 空格键``


## 5 Python 开发环境

``sudo gedit /etc/apt/apt.conf``
```
Acquire::http::proxy "http://child-prc.intel.com:913/";
Acquire::https::proxy "https://child-prc.intel.com:913/";
sudo apt-get update
```

``` bash
sudo apt-get install python          #Python2                
sudo apt-get install python3         #Python3
sudo apt-get install virtualenv      #虚拟环境部署工具
sudo apt-get install python-pip      #pip2
sudo apt-get install python3-pip     #pip3
```
``` bash
sudo apt-get remove python*          #移除python, python3, ...
```
如非强制要求，不推荐从源码安装 python。


## 6 SSH 服务

``` bash
sudo apt-get install openssh-server
sudo apt-get install openssh-client
```
