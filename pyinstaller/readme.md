## pyinstaller

安装
```bash
pip3 install --force-reinstall PyQt5==5.10.1
```

app.py
```python
import os
import sys

from PyQt5.QtCore import *
from PyQt5.QtGui import *
from PyQt5.QtWidgets import *
from PyQt5.QtWebEngineWidgets import *


class MainWindow(QWidget):
    def __init__(self):
        super(QWidget, self).__init__()
        self.setWindowTitle('MainForm')
        # 主界面布局
        # group 1
        checkBox1 = QCheckBox('checkbox 1')
        checkBox2 = QCheckBox('checkbox 2')
        checkBox3 = QCheckBox('checkbox 3')
        checkBox4 = QCheckBox('checkbox 4')
        div1 = QVBoxLayout()
        div1.addWidget(checkBox1)
        div1.addWidget(checkBox2)
        div1.addWidget(checkBox3)
        div1.addWidget(checkBox4)
        group1 = QGroupBox('Service Type')
        group1.setLayout(div1)
        # div 2
        checkBox5 = QCheckBox('way 1')
        checkBox6 = QCheckBox('way 2')
        div2 = QHBoxLayout()
        div2.addWidget(checkBox5)
        div2.addWidget(checkBox6)
        group2 = QGroupBox('Access Type')
        group2.setLayout(div2)
        # div 3
        scanCodeArea = QWebEngineView()
        scanCodeArea.load(QUrl('http://www.baidu.com'))
        loginBtn = QPushButton('Login')
        div3 = QVBoxLayout()
        div3.addWidget(scanCodeArea)
        div3.addWidget(loginBtn)
        group3 = QGroupBox('User Login')
        group3.setLayout(div3)
        # MainForm
        leftDiv = QVBoxLayout()
        leftDiv.addWidget(group1)
        leftDiv.addWidget(group2)
        mainFormLayout = QGridLayout()
        mainFormLayout.addLayout(leftDiv, 1, 1)
        mainFormLayout.addWidget(group3, 1, 2)
        #
        self.setLayout(mainFormLayout)


if __name__=='__main__':
    app = QApplication(sys.argv)
    win = MainWindow()
    win.show()
    sys.exit(app.exec_())
```

打包示例
```bash
pip3 install --force-reinstall setuptools==41.0.1
pip3 install --force-reinstall wheel==0.33.4
pip3 install --force-reinstall pyinstaller==3.5
```

```bash
cd [path]/app
pyinstaller -Fw app.py  # -w 隐藏 exe 终端窗口; -F 打包为单执行文件
```

**Pyinstaller 打包配置选项详情，请查询** <br>
https://pyinstaller.readthedocs.io/en/v3.3.1/usage.html#options

<br>

**软件更新，发布工具，请转到** <br>
[pyupdater](pyupdater)

<br>

##### 绪论 —— Python 2 Windows exe （python 代码打包）
对 python 代码打包成 exe 的方式有：
* py2exe
* pyinstaller
* cx_Freeze
* nuitka

##### 各工具优缺点
##### 1. py2exe
优点：
* 可以把 python 打包成 exe，不用在 windows 系统上安装 python。

缺点：
* 打包好的 exe 只能在相同的系统下运行， XP 与 Win7 间不兼容。
* 可能存在同是 XP 系统，但由于 DLL 缺失而无法运行的情况。
* 其他一些问题。

推荐系数： 1 星

##### 2. pyinstaller
优点：
* 跨平台。
* 输出的可以是单一目录，也可以是一个单独的打好包的可执行文件。
* 智能支持 python 的第三方模块，如 PyQt，外部数据文件等。

缺点：
* import 导入的问题，最好显示导入引擎库。

推荐系数： 4 星

##### 3. cx_Freeze
优点：
* 可以把 python 打包成 exe。

缺点：
* 启动执行的文件中不要有这种判断``if __name__ == '__main__:'``，否则可执行文件执行会没有任何效果。
* 发布后，可执行文件执行路径不能有中文（最好也不要有空格）。
* 只能指定一个要打包的模块，也就是启动模块。
* 打包文件后，需要将图片等素材拷贝一份放在打包后的文件夹下，否则运行 exe 程序会找不到图片素材。
* 要去掉 exe 里的后面黑色控制台窗口就在前面的命令改成：cxfreeze C:\Users\restartRemote.py (需打包文件路径） –target-dir D:\pyproject （存放exe的目标文件夹路径）–base-name=win32gui。

推荐系数： 1 星

##### 4. nuitka
优点:
* Nuitka 直接将 python 编译成 C++ 代码，再编译 C++ 代码产生可执行文件。 非常安全，运行速度也会获得提升。

缺点：
* 在另一台电脑上无法运行…

推荐系数： 1 星
