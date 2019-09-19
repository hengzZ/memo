## Intel(R) Software Development Emulator

* https://wiki.ith.intel.com/display/SDE/SDE+Users+Manual
* https://wiki.ith.intel.com/display/SDE/SDE+Mix+output+file+structure
* https://wiki.ith.intel.com/display/SDE/SDE

##### instruction mix histograms
命令行
```bash
path-to-kit/sde -mix             -- user-application [args]
path-to-kit/sde -mix -ilen       -- user-application [args]
path-to-kit/sde -mix -category   -- user-application [args]
path-to-kit/sde -mix -iform      -- user-application [args]
```

###### Mix Accounting
*The rows in the mix output histograms come in **two flavors**. The rows that begin with "*" are meta-categories which sum up the data in different ways.*

* isa-ext —— ISA-extension
* isa-set —— ISA "set" is a categorization of instructions in the BASE ISA-extension.
* ISA extensions are things like (BASE, X87, MMX,SSE,SSE2, SSE3, etc.).

###### Mix histogram tool
* https://wiki.ith.intel.com/display/SDE/Mix+histogram+tool

***If you would like to know how many AVX instructions were executed then the best way is to use the \*isa-ext-AVX or the \*isa-set-AVX. These two should be the same.***

<br>

## Perf
—— Linux Tools - Perf

##### 安装
```bash
sudo yum install perf
```

##### 命令
* ``perf top``
* ``perf record ./a.out && sleep 10 ; perf report``
