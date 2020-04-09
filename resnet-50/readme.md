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
pip install tensorflow==1.14.0 --proxy=child-prc.intel.com:913
# 退出虚拟环境
deactivate
#For tf-1.13虚拟环境
virtualenv --no-site-packages tf-1.13 -p python3
source tf-1.13/bin/activate
pip install tensorflow==1.13.2 --proxy=child-prc.intel.com:913
# 查看已安装内容
pip freeze
```

## CPU 环境确认

#### Performance Mode
```bash
cpupower frequency-set -g performance
cpupower frequency-info -p
```

#### idle-set（非必须）
```bash
cpupower idle-set -d 2
# 查看主频（-i指定信息采集间隔）
turbostat -i 1
```

#### 使用perf监测CPI（推荐emon，迫不得已再用perf）
```bash
perf stat -I 1000 -e "instructions,cycles"
```

## Run
```bash
git clone https://github.com/tensorflow/benchmarks
cd benchmarks/scripts/tf_cnn_benchmarks
tf_cnn_benchmarks.py --device=cpu --nodistortions --mkl=True --forward_only=True --data_format=NHWC --model=resnet50 --num_inter_threads=2 --num_intra_threads=56 --batch_size=128
```

## 注意！
使用``pip install tensorflow==1.13.2``环境
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
