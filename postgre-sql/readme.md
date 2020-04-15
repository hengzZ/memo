## PostgreSQL Benchmark

#### 安装包
文档教程：
* https://www.postgresqltutorial.com/install-postgresql/
* https://www.hammerdb.com/docs/ch01.html

下载链接：（版本必须一致）
```
* vm.RemoteCommand('sudo yum -y install https://download.postgresql.org/pub/repos/yum/reporpms/'
                    'EL-7-x86_64/pgdg-redhat-repo-latest.noarch.rpm', ignore_failure=True)
  cmds = ["sudo yum -y install postgresql11", "sudo yum -y install postgresql11-server"]
* HAMMERDB_SRC = ('https://sourceforge.net/projects/hammerdb/files/HammerDB/' 'HammerDB-3.2/HammerDB-3.2-Linux.tar.gz')
```

#### 环境部署
```bash
# PostgreSQL
$ wget https://download.postgresql.org/pub/repos/yum/reporpms/EL-7-x86_64/pgdg-redhat-repo-latest.noarch.rpm
$ yum install -y pgdg-redhat-repo-latest.noarch.rpm
$ yum install -y readline-devel zlib-devel
# yum install -y postgresql11 postgresql11-server
# https://www.postgresql.org/ftp/source/v11.5/
$ wget https://ftp.postgresql.org/pub/source/v11.5/postgresql-11.5.tar.gz
$ tar -zxvf postgresql-11.5.tar.gz
$ cd postgresql-11.5
$ ./configure
$ make -j20
$ make install
# HammerDB
$ wget https://sourceforge.net/projects/hammerdb/files/HammerDB/HammerDB-3.2/HammerDB-3.2-Linux.tar.gz
$ tar -zxvf HammerDB-3.2-Linux.tar.gz
```

#### Run （有待确认）
```bash
# 初始化数据库
$ cd /usr/local/pgsql/bin
$ ./initdb -D /usr/local/pgsql/data/
# 配置文件 data/postgresql.conf
# 启动 postgresql
$ systemctl start postgresql-11
# 启动 hammerdb
$ cd HammerDB-3.2
$ ./hammerdb
```

补充知识点：
```
从CentOS 7.x开始，CentOS开始使用systemd服务来代替daemon，与此同时，
1. 原来管理系统启动和管理系统服务的命令 service 由 systemctl 命令来代替：
- |daemon命令|	            |systemctl命令|	                |说明|
- service [服务] start	    systemctl start [unit type]	    启动服务
- service [服务] stop	    systemctl stop [unit type]	    停止服务
- service [服务] restart	systemctl restart [unit type]	重启服务
2. 原来的 chkconfig 命令与 systemctl 命令对比：
- |daemon命令|	            |systemctl命令|	                |说明|
- chkconfig [服务] on	    systemctl enable [unit type]	设置服务开机启动
- chkconfig [服务] off	    systemctl disable [unit type]	设备服务禁止开机启动
3. Centos 7.x 中取消了 iptables，用 firewall 取而代之。 关闭防火墙 firewall：
- systemctl stop firewalld.service                          |关闭防火墙|
- systemctl disable firewalld.service                       |禁止防火墙开机启动|
```


#### 配置文件

/etc/sysctl.conf
```shell
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

/etc/security/limits.conf
```shell
postgres soft memlock 100000000
postgres hard memlock 100000000
```

postgresql.conf
```shell
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


#### 查看 CPU 逻辑核对应的 ID
```bash
cpuinfo
# numactl 绑定 AMD CPU 的后 56 个物理核。
numactl -C 8-63,72-127 --localalloc <cmd>
```