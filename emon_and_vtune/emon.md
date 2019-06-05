## Intel Perf Tools
—— SEP and EMON

***Sampling Enabling Product (SEP) and Event Monitor (EMON) are software tools used for performance analysis & tuning of Intel h/w platforms, and the software running on them.***

安装包
* edp-v3.9.zip
* emon_nda_11_9_linux_05152019.tar.bz2

#### Emon 安装
```bash
依赖环境：
    # 安装 kernel source
    yum install kernel-devel
安装：
    tar -jxvf emon_nda_11_9_linux_05152019.tar.bz2
    unzip edp-v3.9.zip
    cd emon_nda_11_9_linux_05152019
    sh install.sh  # 使用 su 用户安装
    # 进入 emon 安装目录，重新编译驱动
    cd <emon 安装目录>/sepdk/src
    ./build-driver
(备注： 如果运行 emon 时存在 pax 与 sep 冲突，请到 emon 安装目录注销 pax 模块)
```

#### Emon 脚本
* run_emon.sh
```bash
SEP_DIR=/opt/intel/emon
DATA_DIR=$(dirname "$0")

mkdir -p ${DATA_DIR}/${1}
source ${SEP_DIR}/sep_vars.sh

${SEP_DIR}/sepdk/src/rmmod-sep
${SEP_DIR}/sepdk/src/insmod-sep

# 以下 5 个文件/脚本来源于 Sep 包
cp ${DATA_DIR}/chart_format_clx_2s.txt ${DATA_DIR}/${1}
cp ${DATA_DIR}/edp.rb ${DATA_DIR}/${1}
cp ${DATA_DIR}/clx-2s-events.txt ${DATA_DIR}/${1}
cp ${DATA_DIR}/process.sh ${DATA_DIR}/${1}
cp ${DATA_DIR}/clx-2s.xml ${DATA_DIR}/${1}

emon -v > ${DATA_DIR}/${1}/emon-v.dat
emon -M > ${DATA_DIR}/${1}/emon-M.dat
emon -i ${DATA_DIR}/${1}/clx-2s-events.txt > ${DATA_DIR}/${1}/emon.dat &
```
* stop_emon.sh
```bash
SEP_DIR=/opt/intel/emon
EMON_DIR=$(dirname "$0")
source ${SEP_DIR}/sep_vars.sh
emon -stop
```

#### Emon 运行
```bash
source /opt/intel/emon/sep_vars.sh
which emon  # 确认 emon 已安装
# 采集数据
testname=”test_emon”
sh ./run_emon.sh $testname
sh ./stop_emon.sh
(备注： 如果运行 emon 时存在 pax 与 sep 冲突，请到 emon 安装目录注销 pax 模块)
```

#### Sep 配置
—— Sep 的用途是为 emon 的结果分析提供事件列表和 Metric 公式。
* Architecture Specific <br>
针对不同的硬件平台提供不同的事件列表与 Metirc 公式。
* edp.rb <br>
ruby 脚本程序。
* process.sh <br>
调用 edp.rb 统计分析 emon 数据的脚本。

#### Sep 运行
```bash
# 运行之前，请修改 process.sh 脚本，指定文件路径和与本地环境一致的文件名。
#（官方提供的 process.sh 只是一个模板）
./process.sh
（备注： 根据提示安装依赖的 ruby 环境， yum install ruby。）
```
