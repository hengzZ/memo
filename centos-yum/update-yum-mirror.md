## yum 下载源更新

* 下载源更新
```
# 进入yum配置文件目录
cd /etc/yum.repos.d/
# 备份
mv CentOS-Base.repo CentOS-Base.repo.bak
# 下载163的配置 （optional）
wget http://mirrors.163.com/.help/CentOS6-Base-163.repo
mv CentOS6-Base-163.repo CentOS-Base.repo

# 更新
yum clean all
yum makecache
yum update
```

* yum 代理设置
```
# 打开配置文件
vim /etc/yum.conf
# 在 [main] 中， 添加代理：
proxy=http://proxyHost:port
```