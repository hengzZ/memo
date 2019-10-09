## AMD Architecture Programming
* 开发手册文档页 <br>
  https://developer.amd.com/resources/developer-guides-manuals/ <br>
  https://www.amd.com/en/support/tech-docs
* 寄存器(msr)查询手册 <br>
  [AMD64 Architecture Programmer’s Manual Volume 2: System Programming](https://www.amd.com/system/files/TechDocs/24593.pdf)

#### 系统配置工具

##### 1. msr-tools
* 安装
  ```bash
  yum install msr-tools
  ```
* 使用（以 intel cpu 为例，AMD 请查手册确定 msr 地址）
  ```bash
  rdmsr -X 0x620          # 0x620 为 msr 地址
  wrmsr -a 0x620  0x1818  # Set uncore to 2.4GHz
  ```

##### 2. turbostat
* 查看 cpu 运行时主频
  ```bash
  turbostat -i 1 -c 0-17  # -i 信息采集间隔， -c 指定观测的核心
  ```

##### 3. perf
* 系统调用分析
  ```bash
  perf top
  ```

##### 4. top
* cpu 利用率查看
  ```bash
  top   # 简单版
  htop  # 界面版
  ```

##### 5. numactl
* cpu 核心绑定
  ```bash
  numactl -C 0-35 <command to run workload>
  ```

##### 6. sar / iostat / mpstat
* 状态实时查询
  ```bash
  $ sar -A 1
  $ iostat -x 1
  $ mpstat 1
  ```
