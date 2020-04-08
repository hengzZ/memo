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

## deployment


## Run
```bash
git clone https://github.com/tensorflow/benchmarks
cd benchmarks/scripts/tf_cnn_benchmarks
tf_cnn_benchmarks.py --device=cpu --nodistortions --mkl=True --forward_only=True --data_format=NHWC --model=resnet50 --num_inter_threads=2 --num_intra_threads=56 --batch_size=128
```
