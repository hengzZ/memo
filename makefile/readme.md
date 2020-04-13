# Makefile


## 工程浏览 ##
1. 浏览工程目录树（文件夹结构）
2. 确定源代码目录
    * 如果目录中有第三方依赖库，先略过依赖库代码
    * 确定作者添加代码文件
3. 作者代码浏览
    * 有对应头文件的源代码文件首先略过
    * 没有对应头文件的代码和头文件一样对待
    * 逐个浏览头文件，确定对象（cpp: class声明, c: 将一个文件视为对象，如果c实现面向对象编程，则结构体为一个对象）
4. 源代码浏览（算法流梳理）
    * 首先找到main函数所在文件（使用搜索工具搜索main函数位置）
    * 充分利用跳转工具（go to define \ go back）


## 编码 ##

### 代码书写规范 ###
参考[谷歌开源项目风格指南][]: C++风格指南、python风格指南、Shell风格指南  

### 设计模式 ###
参考[设计模式:可复用面向对象软件的基础][]: 23种设计模式  
参考[数据结构与算法分析（C语言描述）][] [C++数据结构与算法][]: 数据对象的设计  

### 算法设计与分析基础 ###
参考[算法设计与分析基础][]: 10通用算法设计技术  


## 语法参考 ##

### C/C++标准库文档参考 ###
参考[cppreference.com][]: C++98,C++03,C++11,C++14,C++17  
参考[The C Library Reference Guide][]: C Language, C Library  

### Python语言及标准库参考 ###
参考[Python3官方文档][]: Tutorial(代码示例), Library Reference, Language Reference  
参考[Python Cookbook][]: 以书的排版形式，展现示例代码

### Markdown语法参考 ###
参考[Markdown语法说明][]  

### Makefile （C++ 快速入门）
参考[A simple Makefile Tutorial][]


## 其他 ##
* 推荐一个很好的免费教程网站[tutorialspoint][]: 特点是教程文档简单易懂（虽然是英文文档），具有启发性，入门尤其适合。入门之后借助官方文档和项目代码深入学习。
* [C/C++书单][]。书单很长，质量虽高，却莫陷入太深。
* Github站点[Solutions to Introduction to Algorithms][]: Solutions to Introduction to Algorithms by Charles E. Leiserson, Clifford Stein, Ronald Rivest, and Thomas H. Cormen (CLRS).



[谷歌开源项目风格指南]: http://zh-google-styleguide.readthedocs.io/en/latest/
[设计模式:可复用面向对象软件的基础]: http://product.dangdang.com/142308.html
[数据结构与算法分析（C语言描述）]: http://product.dangdang.com/8767364.html
[C++数据结构与算法]: http://product.dangdang.com/23594179.html
[算法设计与分析基础]: http://product.dangdang.com/23633875.html
[cppreference.com]: http://en.cppreference.com/w/Main_Page
[The C Library Reference Guide]: https://www-s.acm.illinois.edu/webmonkeys/book/c_guide/

[Python3官方文档]: https://docs.python.org/3/
[Python Cookbook]: http://python3-cookbook.readthedocs.io/zh_CN/latest/index.html# 
[Markdown语法说明]: http://xianbai.me/learn-md/article/syntax/readme.html
[A simple Makefile Tutorial]: http://www.cs.colby.edu/maxwell/courses/tutorials/maketutor/
[tutorialspoint]: http://www.tutorialspoint.com/
[C/C++书单]: https://stackoverflow.com/questions/388242/the-definitive-c-book-guide-and-list
[Solutions to Introduction to Algorithms]: https://github.com/gzc/CLRS

