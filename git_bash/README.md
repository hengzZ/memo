## git environment for windows ##

* Download git (windows version)
* vim environment installation
* exuberant-ctags installation
* add 'tree' command to Git Bash on Windows
* add python command to Git Bash


### vim environment installation ###
refer: https://github.com/hengzZ/my-vim/blob/master/README.md


### exuberant ctags installation ###

1. Download Exuberant Ctags of Windows version. [][http://ctags.sourceforge.net/]
1. Copy the exe to the Git Bash home directory.
1. use it such as: ./ctags.exe -R [path] Or Add the executable binary to the PATH.

example:  
    mkdir **GitBashPATH** folder and add the exe into it. Then Add the folder to Windows PATH.


### Add 'tree' command ###
1. Download Tree for Windows [][http://mama.indstate.edu/users/ice/tree/]
1. Add tree.exe to the folder **GitBashPATH** 

other source: [][http://gnuwin32.sourceforge.net/packages/tree.htm]


### Add 'python' ###
1. install python.exe for Windows
1. add '''export PATH=/c/Python27/${PATH:+:${PATH}}''' to ~/.bashrc
1. add '''alias python='winpty python2''' to ~/.bashrc (Git Bash 不支持Python交互环境，利用winpty接口)
