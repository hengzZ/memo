# PostgreSQL Benchmark

- PostgreSQL
- HammerDB

## 介绍

### PostgreSQL
—— https://www.postgresql.org

PostgreSQL 是一个功能强大的开源数据库系统。PostgreSQL 是完全的事务安全性数据库，完整地支持外键、联合、视图、触发器和存储过程（并支持多种语言开发存储过程）。它支持了大多数的 SQL:2008 标准的数据类型，包括整型、数值值、布尔型、字节型、字符型、日期型、时间间隔型和时间型，它也支持存储二进制的大对像，包括图片、声音和视频。

自从 MySQL 被 Oracle 收购以后，PostgreSQL 逐渐成为开源关系型数据库的首选。

#### PostgreSQL 新手入门（非 Benchmark 测试用例！！）

``` bash
$ sudo apt-get install postgresql-client
$ sudo apt-get install postgresql
# 如果还想安装图形管理界面，可以运行下面命令。（不推荐）
$ sudo apt-get install pgadmin3
```
正常情况下，安装完成后，PostgreSQL 服务器会自动在本机的 5432 端口开启。

``` bash
$ netstat -lntup
```
注意，初次安装后，默认生成一个名为 ``postgres`` 的数据库和一个名为 ``postgres`` 的数据库用户。同时还生成了一个名为 ``postgres`` 的 Linux 系统用户！！

``` bash
$ sudo adduser dbuser       #添加新LINUX用户
$ sudo su - postgres        #切换用户
$ psql                      #登录PostgreSQL控制台
# 以下，在postgres=#终端中输入：
\password postgres
CREATE USER dbuser WITH PASSWORD 'password';
CREATE DATABASE exampledb OWNER dbuser;
GRANT ALL PRIVILEGES ON DATABASE exampledb to dbuser;
\q
```

``` bash
# 以新用户登陆数据库 （使用的依旧是 psql 命令）
$ psql -U dbuser -d exampledb -h 127.0.0.1 -p 5432
```
**基本的数据库操作，就是使用一般的 SQL 语言**。

### HammerDB
—— https://www.hammerdb.com/docs/index.html

HammerDB 是一个开源的数据库压力测试的基准工具，同时支持 Linux 和 Windows 系统，有图形用户界面(GUI)和命令行两种形式。目前支持的数据库包括 Oracle, SQL Server, DB2, MySQL, MariaDB, PostgreSQL, Redis 等。

HammerDB 模拟了标准的 ``TPC-C`` 和 ``TPC-H`` 两种测试模型。

目前最新版本是 ``3.3``，Linux系统3.0版的安装方式有两种，

- 图形界面安装
- 下载.tar压缩文件，解压后直接运行hammerdb文件即可

但是，3.0以前的版本都需要用第一种安装方式！！

``` bash
# 安装方式一：Self Extracting Installer
$ ./HammerDB-3.3-Linux-x86-64-Install
This will install HammerDB on your computer. Continue? [n/Y] Y

Where do you want to install HammerDB? [/usr/local/HammerDB-3.3]

Installing HammerDB...
Installing Program Files...
Installation complete.
```

``` bash
# 安装方式二：tar.gz 文件安装
$ tar -zxvf HammerDB-3.0.tar.gz
$ cd HammerDB-3.0
$ ./hammerdb
```
卸载：``To uninstall HammerDB on Linux run the uninstall executable for the self-extracting installer or remove the directory for the tar.gz install.``

参考：
- https://blog.csdn.net/Space_zero/article/details/78924604
- https://www.hammerdb.com/blog/uncategorized/hammerdb-best-practice-for-postgresql-performance-and-scalability/

<br>


# Benchmark 测试环境部署

### 1 下载安装包

``` bash
$ sudo yum -y install https://download.postgresql.org/pub/repos/yum/reporpms/EL-7-x86_64/pgdg-redhat-repo-latest.noarch.rpm
$ sudo yum -y install postgresql11
$ sudo yum -y install postgresql11-server
$ wget https://sourceforge.net/projects/hammerdb/files/HammerDB/HammerDB-3.2/HammerDB-3.2-Linux.tar.gz
$ cd HammerDB-3.2
$ ./hammerdbcli
$ librarycheck
$ quit
```

> 备注：以上安装方式参考的 Intel 测试日志。（注意保持版本一致）
```
* vm.RemoteCommand('sudo yum -y install https://download.postgresql.org/pub/repos/yum/reporpms/'
                    'EL-7-x86_64/pgdg-redhat-repo-latest.noarch.rpm', ignore_failure=True)
  cmds = ["sudo yum -y install postgresql11", "sudo yum -y install postgresql11-server"]
* HAMMERDB_SRC = ('https://sourceforge.net/projects/hammerdb/files/HammerDB/' 'HammerDB-3.2/HammerDB-3.2-Linux.tar.gz')
```


##### Option（从源码安装）
- https://www.postgresql.org/docs/11/install-short.html

``` bash
$ wget https://ftp.postgresql.org/pub/source/v11.5/postgresql-11.5.tar.gz
$ yum install -y readline-devel zlib-devel
#export LD_LIBRARY_PATH=/usr/local/pgsql/lib:$LD_LIBRARY_PATH
```

#### VNC Viewer 安装和使用

``` bash
$ vncserver
$ vncviewer 192.168.14.171:1
```


### 2 配置参数
—— https://www.hammerdb.com/docs

- /usr/local/pgsql/data/postgresql.conf
- /etc/sysctl.conf
- /etc/security/limits.conf


[/etc/sysctl.conf]
``` shell
vm.swappiness = 0
kernel.sem = 250 32000 100 128
fs.file-max = 6815744
net.ipv4.ip_local_port_range = 9000 65500
net.core.rmem_default = 262144
net.core.rmem_max = 4194304
net.core.wmem_default = 262144
net.core.wmem_max = 1048576
fs.aio-max-nr = 1048576
vm.nr_hugepages = 35000
```

[/etc/security/limits.conf]
``` shell
postgres soft memlock 100000000
postgres hard memlock 100000000
```

[postgresql.conf]
``` shell
listen_addresses = '10.239.83.80'          # what IP address(es) to listen on
port = 5432                                # (change requires restart)
max_connections = 256                      # (change requires restart)
shared_buffers = 64000MB                   # min 128kB
huge_pages = on                            # on, off, or try
temp_buffers = 4000MB                      # min 800kB
work_mem = 4000MB                          # min 64kB
maintenance_work_mem = 512MB               # min 1MB
autovacuum_work_mem = -1                   # min 1MB, or -1 to use maintenance_work_mem
max_stack_depth = 7MB                      # min 100kB
dynamic_shared_memory_type = posix         # the default is the first option 
max_files_per_process = 4000               # min 25
effective_io_concurrency = 32              # 1-1000; 0 disables prefetching
wal_level = minimal                        # minimal, archive, hot_standby, or logical
synchronous_commit = off                   # synchronization level;
#wal_sync_method = open_datasync
wal_buffers = 512MB                        # min 32kB, -1 sets based on shared_buffers
#checkpoint_segments = 256                 # in logfile segments, min 1, 16MB each
checkpoint_timeout = 1h                    # range 30s-1h
checkpoint_completion_target = 1           # checkpoint target duration, 0.0 - 1.0
checkpoint_warning = 0                     # 0 disables
log_min_messages = error                   # values in order of decreasing detail:
log_min_error_statement = error            # values in order of decreasing detail:
autovacuum = off                           # Enable autovacuum subprocess?  'on'
datestyle = 'iso, dmy'
lc_messages = 'en_US.UTF-8'                # locale for system error message
lc_monetary = 'en_US.UTF-8'                # locale for monetary formatting
lc_numeric = 'en_US.UTF-8'                 # locale for number formatting
lc_time = 'en_US.UTF-8'                    # locale for time formatting
default_text_search_config = 'pg_catalog.english'
max_locks_per_transaction = 64             # min 10
max_pred_locks_per_transaction = 64        # min 10
archive_mode=off
max_wal_senders=0
min_wal_size=262144
max_wal_size=524288
```
**Note: HammerDB v3.2 is installed on the same system as PostgreSQL.**


**PostgreSQL Schema Build Options**
<div align="center">
<img src="postgresql-schema-build-options.png" width="45%">
</div>


#### 删除 PostgreSQL Schema
```bash
$ su - postgres
$ /usr/local/pgsql/bin/psql -U postgres
# 在控制台 'postgres=#' 输入以下内容：
drop database tpcc;
drop role tpcc;
quit                   #退出
```


<br>

# Linux 系统服务管理

从 CentOS 7.x 开始，CentOS 开始使用 ``systemd`` 服务来代替 ``daemon``。与此同时，使用 ``systemctl`` 命令来替代旧的 ``service`` 命令。

```
1. 原来管理系统启动和系统服务的命令 service 将由 systemctl 命令代替：
- |daemon命令|	            |systemctl命令|	                |说明|
- service [服务] start	    systemctl start [unit type]	    启动服务
- service [服务] stop	      systemctl stop [unit type]	    停止服务
- service [服务] restart	  systemctl restart [unit type]	  重启服务
2. 原来的 chkconfig 命令与 systemctl 命令对比：
- |daemon命令|	            |systemctl命令|	                |说明|
- chkconfig [服务] on	      systemctl enable [unit type]	  设置服务开机启动
- chkconfig [服务] off	    systemctl disable [unit type]	  设备服务禁止开机启动
3. Centos 7.x 中取消了 iptables，用 firewall 取而代之。 关闭防火墙 firewall：
- systemctl stop firewalld.service                         |关闭防火墙|
- systemctl disable firewalld.service                      |禁止防火墙开机启动|
```

# Linux 系统目录结构

https://www.runoob.com/linux/linux-system-contents.html
