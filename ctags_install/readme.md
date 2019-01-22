## Install Exuberant Ctags

#### Ubuntu
```bash
sudo apt-get install exuberant-ctags
```


#### Centos
```bash
# 下载 ctags-5.8.tar.gz
# http://ctags.sourceforge.net

wget https://versaweb.dl.sourceforge.net/project/ctags/ctags/5.8/ctags-5.8.tar.gz
tar -zxvf ctags-5.8.tar.gz

cd ctags-5.8
./configure
make
make install
```
