# Resnet 50

```bash
详细参数如下：     
STDOUT: TensorFlow:  1.13
Model:       resnet50
Dataset:     imagenet (synthetic)
Mode:        forward only
SingleSess:  False
Batch size:  128 global
             128 per device
Num batches: 100
Num epochs:  0.01
Devices:     ['/cpu:0']
NUMA bind:   False
Data format: NHWC
Optimizer:   sgd
Variables:   parameter_server
==========
```

## Deployment
```bash
pip install virtualenv
virtualenv --no-site-packages tf-1.14 -p python3
source tf-1.14/bin/activate
pip install tensorflow==1.14.0 --proxy=child-prc.intel.com:913 --force-reinstall
# 退出虚拟环境
deactivate
#For tf-1.13虚拟环境
virtualenv --no-site-packages tf-1.13 -p python3
source tf-1.13/bin/activate
pip install tensorflow==1.13.2 --proxy=child-prc.intel.com:913 --force-reinstall
#或者 python -m pip install tensorflow==1.13.2 --proxy=child-prc.intel.com:913 --force-reinstall
# 查看已安装内容
pip freeze
```

如果没有``pip``，安装的方法如下：
```bash
$ curl https://bootstrap.pypa.io/get-pip.py -o get-pip.py
$ python get-pip.py
# 如果是python3的话
$ python3 get-pip.py
```


## CPU 环境确认

#### Performance Mode
```bash
cpupower frequency-set -g performance
cpupower frequency-info -p
```

#### idle-set（非必须）
```bash
$ cpupower idle-set -e 1
$ cpupower idle-set -e 2
$ cpupower idle-set -e 3
$ cpupower idle-set -d 3
# 确认当前状态
$ cpupower idle-info
$ cpupower frequency-info
# 查看主频（-i指定信息采集间隔）
$ turbostat -i 1
```

#### 使用perf监测CPI（推荐emon，迫不得已再用perf）
```bash
perf stat -I 1000 -e "instructions,cycles"
```

## Intel turbo.sh
```bash
#!/bin/sh

cores=$(cat /proc/cpuinfo | grep process | awk '{print $3}')

if [[ ${#} == 0 ]]; then
    for core in $cores
    do
        status=`rdmsr -p${core} 0x1a0 -f 38:38`
        if [[ ${status} == 1 ]]; then
            echo "Core[${core}]:Disabled"
        else
            echo "Core[${core}]:Enabled"
        fi
    done
elif [[ $1 == "disable" ]]; then
    for core in $cores
    do
        wrmsr -p${core} 0x1a0 0x4000850089
    done
elif [[ $1 == "enable" ]]; then
    for core in $cores
    do
        wrmsr -p${core} 0x1a0 0x850089
    done
fi
```
> $ bash turbo.sh enable

## Run
```bash
git clone https://github.com/tensorflow/benchmarks
cd benchmarks/scripts/tf_cnn_benchmarks
python tf_cnn_benchmarks.py --device=cpu --nodistortions --mkl=True --forward_only=True --data_format=NHWC --model=resnet50 --num_inter_threads=2 --num_intra_threads=56 --batch_size=128
```

## 注意！
使用``pip install tensorflow==1.13.2``环境的，可以切换到一个1.13的兼容分支。。
```bash
git clone https://github.com/tensorflow/benchmarks
cd benchmarks
git checkout cnn_tf_v1.13_compatible  #重要步骤
git pull
cd scripts/tf_cnn_benchmarks
python tf_cnn_benchmarks.py --device=cpu --nodistortions --mkl=True --forward_only=True -data_format=NHWC --model=resnet50 --num_inter_threads=2 --num_intra_threads=56 -batch_size=128
```


脚本：
> runme.sh
```bash
python tf_cnn_benchmarks.py --device=cpu --nodistortions --mkl=True --forward_only=True --data_format=NHWC --model=resnet50 --num_inter_threads=2 --num_intra_threads=56 --batch_size=128
```

备注：
> python tf_cnn_benchmarks.py --help  #查看参数列表


# ResNet50 INT8
—— https://github.com/IntelAI/models/tree/master/benchmarks/image_recognition/tensorflow/resnet50#int8-inference-instructions

