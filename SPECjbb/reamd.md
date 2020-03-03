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
查看是否使用的公司网络。使用个人网络下载。
```

```bash
chmod +x SPECjbb*/*.sh
chmod +x SPECjbb*/*/*.sh
sudo sh -c "echo always > /sys/kernel/mm/transparent_hugepage/enabled "
sudo sh -c "echo \* soft nofile 65536 >> /etc/security/limits.conf "
sudo sh -c "echo \* hard nofile 65536 >> /etc/security/limits.conf "
sudo ln -s <当前目录的绝对路径> /workloads    # 用于 run.sh 脚本的执行（因为内部的 JAVA 路径从 /workloads/JVM/$JVM/bin/java 运行）
```

### Run
将 ``jvm/jdk/bin`` 添加到环境变量 ``PATH``，如：``export PATH=~/specjbb/jvm/jdk/bin/${PATH:+:${PATH}}``。
``cd SPECjbb2015/ && sudo ./run.sh HBIR_RT jbb102 specjbb2015_pkb_baremetal jdk "-XX:UseAVX=0" NONE 0``

### Result
* ``cat /workloads/SPECjbb2015/jbb102/1000_HBIR_RT_jbb102_jdk_specjbb2015_pkb_baremetal_NONE/result/*/*/*.raw | grep 'max-jOPS' | cut -d '=' -f2 | sed -e 's/^[         ]*//'``
* ``cat /workloads/SPECjbb2015/jbb102/1000_HBIR_RT_jbb102_jdk_specjbb2015_pkb_baremetal_NONE/result/*/*/*.raw | grep 'critical-jOPS' | cut -d '=' -f2 | sed -e 's/^[         ]*//'``

### CleanUp
``sudo rm -rf specjbb.tar.gz SPECjbb2015-master openjdk.tar.gz /workloads``
