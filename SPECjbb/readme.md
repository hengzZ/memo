# SPECjbb

### Installation

#### SPECjbb
* ``curl -SL --noproxy gitlab.devtools.intel.com https://gitlab.devtools.intel.com/mljones2/SPECjbb2015/-/archive/master/SPECjbb2015-master.tar.gz -o specjbb.tar.gz``
* ``mkdir JVM && mkdir JVM/jdk``
* ``tar -xvzf specjbb.tar.gz && mv SPECjbb2015-master SPECjbb2015``

#### JDK
* ``wget https://download.java.net/java/GA/jdk11/9/GPL/openjdk-11.0.2_linux-x64_bin.tar.gz -O openjdk.tar.gz``
* ``tar -xvzf openjdk.tar.gz -C JVM/jdk --strip-components 1``

###### 补充：Unable to establish SSL connection. 问题解决
Archive 网页：https://jdk.java.net/archive/
```
请查看是否使用的公司网络。使用个人网络下载，防止网络受限。
或者 使用 --no-check-certificate 参数：
$ wget https://download.java.net/java/GA/jdk11/9/GPL/openjdk-11.0.2_linux-x64_bin.tar.gz -O openjdk.tar.gz --no-check-certificate
```

#### 给脚本添加可执行权限
* ``chmod +x SPECjbb*/*.sh``
* ``chmod +x SPECjbb*/*/*.sh``


#### OS 环境配置
注意，请先备份旧的系统环境配置！！
```bash
$ sudo cp /sys/kernel/mm/transparent_hugepage/enabled ./enabled.old
$ sudo cp /etc/security/limits.conf ./limits.conf.old
```
配置：
```bash
sudo sh -c "echo [always] madvise never > /sys/kernel/mm/transparent_hugepage/enabled "
sudo sh -c "echo \* soft nofile 65536 >> /etc/security/limits.conf "
sudo sh -c "echo \* hard nofile 65536 >> /etc/security/limits.conf "
sudo ln -s `pwd` /workloads  #非常重要的一步！ 将<当前目录的绝对路径>软连接至/workloads。（注意！删除软连接要很小心！！！ 一定不要带 -r 参数！！）
#【说明】： /workloads 用于 run.sh 脚本的执行（因为内部的 JAVA 路径从 /workloads/JVM/$JVM/bin/java 运行
```

###### 补充： 是否启用透明大页
```
Red Hat Enterprise Linux 系统
cat /sys/kernel/mm/redhat_transparent_hugepage/enabled

[结果]: [always] madvise never

其它 Linux 系统
cat /sys/kernel/mm/transparent_hugepage/enabled

[结果]: always madvise [never]

说明： [always] 表示透明大页启用了。 [never] 表示透明大页禁用。 [madvise] 表示只在 MADV_HUGEPAGE 标志的 VMA 中使用 THP （Transparent Huge Pages）。

### 传统/标准大页和透明大页的区别
1. grep -i HugePages_Total /proc/meminfo
如果 HugePages_Total 返回 0，意味着标准大页禁用了。
2. cat /proc/sys/vm/nr_hugepages
如果返回 0，意味着传统大页禁用了。

透明大页（THP）管理和标准/传统大页（HP)管理都是操作系统为了减少页表转换消耗的资源而发布的新特性，虽然 ORACLE 建议利用大页机制来提高数据库的性能，
但是 ORACLE 却同时建议关闭透明大页管理。这二者的区别在于大页的分配机制，标准大页管理是预分配的方式，而透明大页管理则是动态分配的方式。
```

## 依赖环境！！
CentOS下：
```bash
yum install -y python
yum install -y redhat-lsb-core
yum install -y numactl bc
```
Ubuntu下：
```bash
apt-get -y install python
apt-get -y install lsb-release
apt-get -y install numactl bc
```


### Step1: Performance Mode
```bash
# CPU 功耗模式设置
$ cpupower frequency-set -g performance
# CPU 功耗模式查看
$ cpupower help frequency-info
$ cpupower frequency-info -p
$ cpupower idle-info
```

### Step2: run svr_info first
```bash
$ cd SPECjbb2015/svrinfo-master
$ ./svr_info.sh
```

### Step3: Run
将 ``jvm/jdk/bin`` 添加到环境变量 ``PATH``，如：``export PATH=~/specjbb/jvm/jdk/bin/${PATH:+:${PATH}}``。
``cd SPECjbb2015/ && sudo ./run.sh HBIR_RT jbb102 specjbb2015_pkb_baremetal jdk "-XX:UseAVX=0" NONE 0``

### Result
* ``cat /workloads/SPECjbb2015/jbb102/1000_HBIR_RT_jbb102_jdk_specjbb2015_pkb_baremetal_NONE/result/*/*/*.raw | grep 'max-jOPS' | cut -d '=' -f2 | sed -e 's/^[         ]*//'``
* ``cat /workloads/SPECjbb2015/jbb102/1000_HBIR_RT_jbb102_jdk_specjbb2015_pkb_baremetal_NONE/result/*/*/*.raw | grep 'critical-jOPS' | cut -d '=' -f2 | sed -e 's/^[         ]*//'``

### CleanUp
* ``sudo rm -rf specjbb.tar.gz SPECjbb2015-master openjdk.tar.gz``
* ``sudo rm -f /workloads  #注意，删除软连接不要使用 -r 参数！！！！！ 会删源目录内数据``
