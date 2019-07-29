## pyupdater
—— ***pyupdater is based on pyinstaller***

##### PyUpdater 是什么？
An auto-update library and cli tool that enables simple, secure & efficient shipment of app updates. (**CLI - Command Line Interface**)

<br>

#### Part 1 —— 安装配置
##### 1.1 安装
* 安装稳定版
```bash
pip install --upgrade PyUpdater
```
* 安装插件 S3、SCP <br>
  —— 查看 plugins 的文档，查询安装配置选项。
```bash
pip install --upgrade PyUpdater[s3]
pip install --upgrade PyUpdater[scp]
```
* 安装完整版
```bash
pip install --upgrade PyUpdater[all]
```

#### Part 2 —— 命令
##### 2.1 Archive 归档
* 功能/作用 <br>
  归档的功能是将 app 使用的外部依赖（external asset）归档记录，不需要将归档的外部依赖捆绑到 app 中，因此也可以实现对外部依赖的单独更新。

* 示例
```bash
# 使用归档命令指定 ffmpeg 依赖版本
pyupdater archive --name ffmpeg --version 2.1.4
pyupdater archive --name ffmpeg  --version 2.2
```

* 帮助信息
```bash
usage: pyupdater archive [opts] filename

optional arguments:
  -h, --help            show this help message and exit
  --name NAME           Name used when renaming binary before archiving.
  --version VERSION     Version of file
  -k, --keep            Will not delete source file after archiving
```

* 详细文档查看
    * https://www.pyupdater.org/usage-cli-asset/
    * 或 https://www.pyupdater.org/usage-client-asset/

##### 特别说明 —— CLI 与 Client 文档的区别
##### ▪ CLI 文档是以 Command Line Tool（命令行工具）的形式使用 PyUpdater，直接用就可以实现 app 的自动检测更新。
##### ▪ Client 文档则是为了给 app 提供自动检测更新的功能库，可以将检测更新逻辑以代码形式加入程序之中，即常规的软件更新方式。

##### 2.2 Build 生成
* 功能/作用 <br>
  生成的功能是编译生成最终的 exe 文件。 Build 命令是 PyInstaller 的包装（Wrapper），所有的 Options 最终都是传给的 PyInstaller。

* 示例
```bash
# Build from python script
$ pyupdater build -F --app-version 1.0 app.py

# Build from spec file (see Make Spec on how to create spec files)
$ pyupdater build --app-version 1.2 app.spec

# Beta channel
$ pyupdater build --app-version 1.2beta2
```

* 帮助信息
```bash
usage: pyupdater build [opts]<script>

optional arguments:
  -h, --help            show this help message and exit
  --archive-format {zip,gztar,bztar,default}
  --clean               Clean build. Bypass the cache
  --app-version APP_VERSION
  -k, --keep            Will not delete executable after archiving
  --pyinstaller-log-info
                        Prints PyInstaller execution info to consoleconsole
```

* 注意
    * Build 命令会被归档，即生成的 exe 会被归档，以压缩包或默认形式进行归档，用于检测更新。
    * Build 命令具有不同的 release channel (发布通道)，只有 Stable Channel 可以创建 Patches。

##### 2.3 Clean
* 功能/作用 <br>
  从当前的 Repository 中清除 PyUpdater 的 traces 信息。

* 示例
```bash
pyupdater clean
```

##### 2.4 Collect Debug Info
* 功能/作用 <br>
  Uploads debug logs, from pyupdater's CLI, to a private gist.

* 示例
```bash
pyupdater collect-debug-info
```

##### 2.5 Init
* 功能/作用 <br>
  Initialize a repo for use with PyUpdater. 创建一个 PyUpdater 仓库，参考 Git init 即可。

* 示例
```bash
pyupdater init
```

##### 特别说明
* It's safe to delete files in the pyu-data directory as needed.
* Anytime you update your settings a new client_config.py file will be created.

##### 2.6 Keys
* 功能/作用 <br>
  用于创建和导入(import)密钥包文件(keypack files)。 密钥包主要包含用于对 PyUpdater 使用的元数据文件进行加密签名的密钥。

* 示例
```bash
# Create
$ pyupdater keys --create

# Once you initialized your repo & copied the keypack to the root of the repo.
$ pyupdater keys --import
```

##### 2.7 Make Spec
* 功能/作用 <br>
  创建一个兼容 PyUpdater 的 spec 文件。

* 示例
```bash
pyupdater make-spec app.py
```

##### 特别说明 —— 什么是 spec 文件？
spec 文件，即配置规范文件，主要用于软件打包。 Linux RPM 编译安装过程的核心是处理 .spec 文件。它说明了软件包怎样被配置，补缀哪些补丁，安装哪些文件，被安装到哪里，在安装该包之前或之后需要运行哪些系统级别的活动。

##### 2.8 Pkg 打包
* 功能/作用 <br>
  软件打包。 根据需要创建 patches，收集哈希值、文件大小、版本及平台信息等。

* 示例
```bash
# Used to process packages. Usually ran after build or archive command
$ pyupdater pkg -p

# Used to sign meta-data. Can be used anytime.
$ pyupdater pkg -S
```

##### 2.9 Plugins
* 功能/作用 <br>
  shows a list of installed upload plugins & authors name.

* 示例
```bash
$ pyupdater plugins

s3 by Digital Sapphire
scp by Digital Sapphire
```

##### 2.10 Settings
* 功能/作用 <br>
  Update configuration for the current repository.

* 示例
```bash
$ pyupdater settings --urls

$ pyupdater settings --plugin s3

$ pyupdater settings --company
```

##### 2.11 Upload
* 功能/作用 <br>
  Uploads all data in the deploy folder to the desired remote location.

* 示例
```bash
# Upload to Amazon S3
$ pyupdater upload --service s3

# Upload to remote server over ssh
$ pyupdater upload --service scp
```

##### 特别说明
PyUpdater 的 Upload 是需要借助 S3 或 SCP 插件的，在安装时指定并安装。

##### 2.12 Help
* 功能/作用 <br>
  现实帮助信息。

* 示例
```bash
$ pyupdater -h

$ pyupdater {command} -h
```

#### Part 3 —— 使用步骤
##### 3.1 使用步骤
请查看 https://www.pyupdater.org/usage-cli/ 的 usage 系列

##### 3.2 示例 —— integrate PyUpdater with wxPython.
##### 一个自更新的 wxPython 应用 
—— 链接 https://pyupdater-wx-demo.readthedocs.io/en/latest/

* GitHub 仓库 https://github.com/wettenhj/pyupdater-wx-demo

##### 3.2.1 运行
* 下载 wxPython 应用程序源码
```bash
git clone https://github.com/wettenhj/pyupdater-wx-demo
```
* 运行 run.py —— 内部已带有更新逻辑，此时会提醒用户运行 ``pyupdater init`` 命令
```bash
python run.py
```
* 此时获得了一个版本的应用，请参照后续教程发布新版本，然后完成自动更新。
https://pyupdater-wx-demo.readthedocs.io/en/latest/overview.html
