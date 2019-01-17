## MySQL

### Environment Setup ###

##### 1. MySQL 安装
```
# CentOS MariaDB 数据库
$ yum install mariadb-server
```

##### 2. Linux 下启动/关闭
```
# 以命令行方式安装的版本
  开启  ./mysqld_safe &
  关闭  mysqladmin -uroot shutdown
# 以 rpm 方式安装的版本
  开启  service mysql start
  关闭  service mysql stop
备注： 在命令行启动 mysql 时，如不加 "--console"，启动、关闭信息不在界面中显示，而是记录在安装目录下的 data 目录里，文件名一般是 hostname.err,通过此文件查看 mysql 的控制台信息。

# CentOS MariaDB 启动
systemctl start mariadb.service
systemctl enable mariadb.service # 开机自启动
mysqladmin -uroot password "root" # 修改密码
```

##### 3. 查看 mysql 服务的状态
```
$ netstat -nlp | grep mysql

# Show mysql instances
ps -ef | grep mysql | grep port
ps aux | grep mysql | grep port
# Show mysqld
netstat -anptu | grep mysql
#
grep MySQL /etc/services
```


### Knowledges ###

##### 1. 登陆查看
```
# root@localhost:root
mysql -uroot -proot
# 查看状态
\s
# 退出
\q
```

##### 2. 修改字符集
```
TODO
```

##### 3. MySQL 添加账户、修改密码
```
# 创建授权
CREATE USER 'inteltest'@'%' IDENTIFIED BY 'inteltest1234';
GRANT ALL ON *.* TO 'inteltest'@'%';
# 删除、取消授权
drop user 'test'@'host';
revoke privileges on databasename.tablename from 'username'@'host';
```

##### 4. 查看所有用户
```
select user,host from mysql.user;
```
##### 5. 查看数据库
```
show databases;
```
##### 6. 使用 mysql 访问远程/本地数据库（mysqld）
```
mysql -hlocalhost/远程IP -uinteltest -pinteltest -P8002(数据库端口号) --socket=/data/8002/prod/mysql.sock（mysqlclient的socket文件）
```