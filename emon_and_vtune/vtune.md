## Intel VTune Amplifier
—— Locate Performance Bottlenecks Fast

##### 1. source 环境变量
```bash
source /opt/intel/vtune_amplifier/amplxe-vars.sh
```

##### 2. 数据采集
```bash
/opt/intel/vtune_amplifier/bin64/amplxe-cl -h
# Usage: amplxe-cl <-action> [-action-option] [-global-option] [[--] target [target options]]
# amplxe-cl -help <action>
## 采集 
amplxe-cl -collect hotspots [待测试 workload 的 bash 运行命令]
## 查看报告 r000hs
amplxe-cl -report hotspots -r r000hs
```

##### 3. （optional）安装 Windows 版 VTune 查看图表型报告
