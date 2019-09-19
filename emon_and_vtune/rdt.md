## Intel(R) RDT utility
—— Intel Resources Director Technology

* tool
  https://github.com/intel/intel-cmt-cat/tree/master/pqos

This software package provides basic support for
* Cache Monitoring Technology (CMT)
* Memory Bandwidth Monitoring (MBM)
* Cache Allocation Technology (CAT)
* Memory Bandwidth Allocation (MBA)

##### Note
* For additional CMT, MBM, CAT and MBA details please see refer to the Intel(R)
Architecture Software Development Manuals available at:
http://www.intel.com/content/www/us/en/processors/architectures-software-developer-manuals.html

* Specific information with regard to CMT, MBM, CAT and MBA can be found in
Chapter 17.18 and 17.19 (SDM volume 3, version 065).

<br>

## Core/Uncore Freq Setting
* Uncore
  ```bash
  rdmsr -a 0x620 
  wrmsr -a 0x620 0x1818  # fix uncore frequency 2.4Ghz.
  ```
* Core
  ```bash
  ./hwpdesire.sh -f 2300000  # fix core frequency to 2.3GHz.
  ```

##### Get scripts
```shell
git clone https://github.intel.com/DEG-CCE-SE/setCpuFRE.git
cd setCpuFRE
chmod +x *
```
