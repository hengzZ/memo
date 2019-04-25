## Visual Studio C++ 动态库项目创建

#### 1. 项目创建
```
1. 创建一个 C++ Win32项目
2. 项目类型，选择 DLL 选项
```

#### 2. API 接口规则
```cpp
// c# 调用 c++ 动态库一般我们这样写:
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct Result_stru
{
	public int x;
	public int y;
	public int status;
};

[DllImport(@"myprocess.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "process")]
private extern static int process(IntPtr pdata, UInt32 w, UInt32 h, Int32 chipwidth, Int32 chipheight, Int32 blackwidth,
							Int32 blackheight, Int32 chipthreval, Int32 blackthreval, ref Result_stru result, int maxsize);
```
* 动态库 dll 定义
```cpp
// 头文件
#ifdef MYPROCESS_EXPORTS
#define MYPROCESS_API __declspec(dllexport)
#else
#define MYPROCESS_API __declspec(dllimport)
#endif

struct Result_stru 
{
	int x;
	int y;
	int status;
};

MYPROCESS_API int _stdcall process(void * pdata, unsigned int w, unsigned int h, int chipwidth, int chipheight, int blackwidth, int blackheight, 
							int chipthreval, int blackthreval, struct Result_stru* v, int maxsize);

// 源文件
MYPROCESS_API int _stdcall process(void * pdata, unsigned int w, unsigned int h, int chipwidth, int chipheight, int blackwidth, int blackheight, 
							int chipthreval, int blackthreval, struct Result_stru* v, int maxsize)
{
	Hobject image;

	gen_image1(&image,"byte",w,h,(Hlong)pdata);
	int ret = measure(&image,chipwidth,chipheight,blackwidth,blackheight,chipthreval,blackthreval,v,maxsize);
	clear_obj(image);	//清除内存

	return ret;
}
```

CallingConvention 参数是 c# 调用 c++ 的方式，是个枚举 msdn 解释如下：
```
* Cdecl - 调用方清理堆栈。这使您能够调用具有 varargs 的函数（如 Printf），使之可用于接受可变数目的参数的方法。 
* FastCall - 不支持此调用约定。
* StdCall - 被调用方清理堆栈。这是使用平台 invoke 调用非托管函数的默认约定。 
* ThisCall - 第一个参数是 this 指针，它存储在寄存器 ECX 中。其他参数被推送到堆栈上。此调用约定用于对从非托管 DLL 导出的类调用方法。 
* Winapi - 此成员实际上不是调用约定，而是使用了默认平台调用约定。例如，在 Windows 上默认为 StdCall，在 Windows CE.NET 上默认为 Cdecl。 
```
从上面来看Winapi方式是根据系统自动选择调用规约的。而 thisCall 是对 c++ 类的调用方法。所以 一般情况下我们选择 Winapi 就可以了。

<br>
<br>

#### C++ 动态库（导出）工程创建
DLL 即动态链接库 （Dynamic-Link Libaray） 的缩写，相当于 Linux 下的共享对象。Windows 下的 DLL 文件和 EXE 文件实际上是一个概念，都是 PE 格式的二进制文件。

##### 导出和导入的概念
在 ELF (Linux 下动态库的格式)，共享库中所有的全局函数和变量在默认情况下都可以被其他模块使用，即 ELF 默认导出所有的全局符号。
DLL 不同，需要显式地“告诉”编译器需要导出某个符号，否则编译器默认所有的符号都不导出。

* 程序使用 DLL 的过程其实是引用 DLL 中导出函数和符号的过程，即导入过程。
* 对于从 DLL 导入的符号，需要使用 “__declspec(dllimport)” 显式声明某个符号为导入符号。
* 在 ELF 中，使用外部符号时，不需要显式声明某符号是从其他共享对象导入的。

显式声明符号的导入导出： （MSVC 编译器提供了一系列 C/C++ 的扩展来指定符号的导入导出，即 __declspec 属性关键字。）
* __declspec(dllexport) 表示该符号是要从 DLL 导出的符号。
* __declspec(dllimport) 表示该符号是从其它 DLL 中导入的符号。

特别说明
```
从空工程创建 dll 时， 添加 MYPROCESS_EXPORTS 宏定义。
* C/C++ -> 预编译 -> 预编译定义 （Prepocessor Definitions）
* 添加： MYPROCESS_EXPORTS=1
```

##### 案例1： dll 导出工程
```cpp
//----------------- myDll.h 文件代码如下 -----------------
// 下列 ifdef 块是创建使从 DLL 导出更简单的宏的标准方法。
// 此 DLL 中的所有文件都是用命令行上定义的 MYDLL_EXPORTS 符号编译的。
// 在使用此 DLL 的任何其他项目上不应定义此符号。
// 这样，源文件中包含此文件的任何其他项目都会将 MYDLL_API 函数视为是从 DLL 导入的，
// 而此 DLL 则将用此宏定义的符号视为是被导出的。  
#ifdef MYDLL_EXPORTS  
#define MYDLL_API __declspec(dllexport)  
#else  
#define MYDLL_API __declspec(dllimport)  
#endif  

/**
 * 要导出的对象
 */
class MYDLL_API CmyDll{
public:
    CmyDll(void);
    //TODO:    在此添加您的方法
}

/**
 * 要导出的变量
 */
extern MYDLL_API int nmyDll;

/**
 * 要导出的函数
 */
MYDLL_API int fnmyDll(void);


//----------------- myDll.cpp 文件代码如下 -----------------
//    myDll.cpp   : 定义DLL应用程序的导出函数。
#include "myDll.h"
  
//这是导出变量的一个示例
MYDLL_API int nmyDll = 0;

//这是导出函数的一个示例
MYDLL_API int fnmyDll(void)
{
       return 42;
}

//这是已导出类的构造函数
//有关类定义的信息，请参阅myDll.h
CmyDll::CmyDll()
{
       return;
}
//--------------------------------------------------------
// ******************************************************
//--------------------------------------------------------


//--------------------------------------------------------
// 以下测试代码，通过两种方式创建 dll 文件
//--------------------------------------------------------
//----------------- myDll.h 文件代码如下 -----------------
//------------------------- 方式一 ------------------------

class MYDLL_API CmyDll{
public:
       CmyDll(void);     
       //TODO:    在此添加您的方法

      //第一种方式在类里面导出函数
      int Add(int x, int y);  
}

extern MYDLL_API int nmyDll;

MYDLL_API int fnmyDll(void);

//---------------- 方式二 通过 extern 导出函数 --------------

class MYDLL_API CmyDll{
public:
       CmyDll(void);     
       //TODO:    在此添加您的方法
}

extern MYDLL_API int nmyDll;

MYDLL_API int fnmyDll(void);

//第一种，添加 extern "C"
extern "C" int Add(int x, int y);

//第二种情况，为当有很多函数导出时，为省略 extern “C”，可以将导出函数包括在 {} 内
extern "C"
{
        int MYDLL_API Add(int x, int y);
}
//--------------------------------------------------------

//-------- 此时相对应的 myDll.cpp 文件代码如下 ---------------
//    myDll.cpp   : 定义DLL应用程序的导出函数。
#include "myDll.h"
  
//这是导出变量的一个示例
MYDLL_API int nmyDll = 0;

//这是导出函数的一个示例
MYDLL_API int fnmyDll(void)
{
       return 42;
}

//这是已导出类的构造函数
//有关类定义的信息，请参阅myDll.h
CmyDll::CmyDll()
{
       return;
}

//通过类导出，
int CmyDll::Add(int x, int y)
{
       return x+y;
}

//通过 extern 导出，此时方式一和方式二都是如此，
int Add(int x, int y)
{
       return x+y;
}
//--------------------------------------------------------
//**** 注意： 函数实现上，前面都不需要添加 MYDLL_API ****
//--------------------------------------------------------
```

##### 案例2： dll 使用

##### 方式一： ＤＬＬ 的隐式调用
隐式链接采用静态加载的方式，比较简单，需要 .h、.lib、.dll 三件套。
```cpp
/**
 * 在 “包含目录” 里添加头文件 testdll.h 所在的目录。
 * 在 “库目录” 里添加头文件 testdll.lib 所在的目录。
 * 在 “附加依赖项” 里添加 “testdll.lib”，
 * 也可以在代码中添加一行代码来设置库的链接，#pragma comment(lib, "DLLSample.lib")。
 */
//---------------------- 方式一 .h .lib .dll 三件套 -------------------------
#include "stdlib.h"  
#include "myDLL.h"  
  
int _tmain(int argc, _TCHAR* argv[])  
{  
　　//这是通过上节的extern方式调用的
    int z= Add(1,2);  
　　
　　//也可以通过类导出的方式调用
　　//CmyDll dll;
　　//int z = dll.Add(1,2);

    printf("z is:%d\n", z);  
    system("pause");  
    return 0;  
}
//-------------------------------------------------------------------------
//----------------------- 方式二 #pragma comment ---------------------------
#include "stdlib.h"  
#include "myDLL.h"  
#prama comment(lib, "myDll.lib")  
//此时的 myDll.lib 的路径必须能找到的，可以给定一个全路径如：“c:\\myDll.lib” 。

int _tmain(int argc, _TCHAR* argv[])  
{  
    int z= Add(1,2);  
    printf("z is:%d\n", z);  
    system("pause");  
    return 0;  
}
//-------------------------------------------------------------------------
```

##### 方式二： ＤＬＬ 的显示调用
对于显式连接，即动态加载。我们需要调用 LoadLibrary 
在 MSDN 中：HMODULE WINAPI LoadLibrary(
  __in  LPCTSTR lpFileName
); 
它的功能是映射一个可执行模块到调用进程的地址空间。由此我们知道显示调用就是\*\*函数指针\*\*来调用函数。
```
配置步骤：
1. 声明头文件 <windows.h>，说明我想用 windows32 方法来加载和卸载 DLL。
2. 然后用 typedef 定义一个指针函数类型。 typedef void(*fun)(int, int); //这个指针类型，要和你调用的函数类型和参数保持一致。
3. 定一个句柄实例，用来取 DLL 的实例地址。 HINSTANCE hdll;
   格式为 hdll=LoadLibrary（“DLL地址”）; 这里字符串类型是 LPSTR，当是 unicode 字符集的时候会不行，
   因此要在配置-属性-常规里面把默认字符集 “unicode” 改成支持多字符扩展即可。
4. 取的地址要判断，返回的句柄是否为空，如果为无效句柄，那么要释放加载 DLL 所占用的内存。
5. 定义一个函数指针，用来获取你要用的函数地址。
  然后通过 GetProcAdress 来获取函数的地址，参数是 DLL 的句柄和你要调用的函数名：比如：FUN=(fun)GetProcAdress(hdll,"sum");
  这里也要判断要函数指针是否为空，如果没取到要求的函数，那么要释放句柄。
6. 然后通过函数指针来调用函数。
7. 调用结束后，就释放句柄 FreeLibrary(hdll);
```
```cpp
// 通过调用 windowsAPI 来加载和卸载 DLL
#include "Windows.h"  
typedef int(*Dllfun)(int , int);  
  
int _tmain(int argc, _TCHAR* argv[])  
{  
    Dllfun funName;  
    HINSTANCE hdll;  
    //put DLL under the Debug path   
    //use _T 设置为宽字符  
    hdll = LoadLibrary( _T("myDLL.dll"));  
    if (hdll == NULL)  
    {  
        FreeLibrary(hdll);  
    }  
    funName = (Dllfun)GetProcAddress(hdll, "Add");  
    if (funName == NULL)  
    {  
        FreeLibrary(hdll);  
    }  
    int x = 1, y = 10;  
    double z= funName(r, h);  
    printf("z= %d\n", z);  
  
    FreeLibrary(hdll);  
    return 0;  
}
```

##### 案例3： C# 调用 C++ 库函数
如果是非托管的，就用DllImport，举例
```csharp
using System;  
using System.Runtime.InteropServices;  
class MainApp
[DllImport("Kernel32")] //读取动态库文件  
public static extern int GetProcAddress(int handle, String funcname);
```
特别说明：
```
此代码是在 C# 中调用 C++ 写的一个动态库。比如 Kernel32.dll 中的函数。
这个函数用 C++ 写，有如下要求：
* 必须为全局函数
* 函数参数必须为基本类型，也就是 C++ 和 C# 都有的类型，否则你在
  public static extern int GetProcAddress(int handle, String funcname);  
  这里没有办法声明该函数。
```

* 问题一： 在 VC 里传入参数为 CString，而 C#里 是 string，怎么传参数呢？
```
// 将 VC++ string 改成 char** , C# 中没有与 string 对应的类型。
VC++ 中为: int Set(char** str,int n);
C# 中为: int Set(ref string str,int n); 
//
VC++ 中的 BOOL 类型对应 C# 中的 System.Int32 类型。 （BOOL 在 C# 中对应的是 Boolean。）
```

* 问题二： 用 VC 写的 DLL 如果是一个导出类，而不是函数接口，C# 里可以直接调用么？
```
疑问： C# 里需要实例化那个类么？
建议在 C++ 中另外写个函数封装一下，如:
int Dllgetch(int a)  
{  
  solution st = //实例化类 solution  
  return st.getch(a);  
}
这个 Dllgetch(int a) 就可以提取出来供 C# 调用。
```

#####案例： C# 需要调用 C++ 对象，但是又不想做成 COM (Component Object Model)，就只好通过导出类中的函数处理。
DLL 创建代码：
```
注意：要在属性页中的 C++下的预处理器的预处理器定义中加上： SIMPLE_CLASS_EXPORTS
```
```cpp
/*------------------------ SimpleCClass.h ------------------------*/
#ifndef  _SIMPLE_C_CLASS_H_
#define  _SIMPLE_C_CLASS_H_
#ifdef SIMPLE_CLASS_EXPORTS
#define SIMPLE_CLASS_EXPORTS __declspec(dllexport)
#else
#define SIMPLE_CLASS_EXPORTS __declspec(dllimport)
#endif
#include <iostream>
#include <string>

using namespace std;
 
class SIMPLE_CLASS_EXPORTS SimpleCClass
{
public:
	SimpleCClass(void);
	~SimpleCClass(void);
public:
	int			Add(int x,int y);
	void		SetName(wstring sName);
	void		Show();
private:
	wstring		m_sName;
	int			m_iResult;
};

#endif
/*------------------------ SimpleCClass.cpp ------------------------*/
#include "SimpleCClass.h"
 
SimpleCClass::SimpleCClass(void)
{
	m_iResult = -1;
	m_sName = L"";
}
 
SimpleCClass::~SimpleCClass(void)
{
}
 
int SimpleCClass::Add( int x,int y )
{
	m_iResult =  x + y;
	return m_iResult;
}
 
void SimpleCClass::SetName( wstring sName )
{
	m_sName = sName;
}
 
void SimpleCClass::Show()
{
	cout<<"两数相交的结果为"<<m_iResult <<"\t"<<endl;
	//cout<<"输入名字为"<<  <<"\t"<<endl;
}

/*------------------------------------------------------------------*/
// 定义导出类中的函数
/*------------------------------------------------------------------*/
/*------------------------ ExportSimple.h ------------------------*/
#ifndef  _EXPORT_SIMPLE_H_
#define  _EXPORT_SIMPLE_H_
#ifdef SIMPLE_CLASS_EXPORTS
#define SIMPLE_CLASS_EXPORTS __declspec(dllexport)
#else
#define SIMPLE_CLASS_EXPORTS __declspec(dllimport)
#endif
#include "SimpleCClass.h"
#include "windows.h"
 
SimpleCClass* g_pSimple = NULL;  // 对象实例化
 
// 创建对象
extern "C" SIMPLE_CLASS_EXPORTS void CreateSimple();
 
extern "C" SIMPLE_CLASS_EXPORTS int Add(int x, int y);
 
extern "C" SIMPLE_CLASS_EXPORTS void SetName(LPCTSTR sName);
 
extern "C" SIMPLE_CLASS_EXPORTS void Release();
 
#endif
/*------------------------ ExportSimple.cpp ------------------------*/
#include "ExportSimple.h"

extern "C" SIMPLE_CLASS_EXPORTS void CreateSimple()
{
	g_pSimple = new SimpleCClass();
}
 
extern "C" SIMPLE_CLASS_EXPORTS int Add( int x, int y )
{
	return g_pSimple->Add(x,y);
}
 
extern "C" SIMPLE_CLASS_EXPORTS void SetName( LPCTSTR sName )
{
	g_pSimple->SetName(sName);
}
 
extern "C" SIMPLE_CLASS_EXPORTS void Release()
{
	if (NULL != g_pSimple)
	{
		delete g_pSimple;
		g_pSimple = NULL;
	}
}
/*------------------------------------------------------------------*/
```
C# 调用代码：
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// 添加引用
using System.Runtime.InteropServices;

namespace TestExportSimple
{
    #region 导入 VRBTLoftingBuilder 动态库
    public static class ImportSimleDLL
    {
        //string DLLPath = System.Windows.Forms.Application.StartupPath;
        const string DLLPath = @"D:\TestCode\DynamicImportDLL\Debug\SimpleOperate.dll";
 
        [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None)]
        public static extern void CreateSimple();
 
        [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None)]
        public static extern int Add(int x,int z);
 
        [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None)]
        public static extern void SetName([MarshalAs(UnmanagedType.LPTStr)]string  sName);
 
        [DllImport(DLLPath, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None)]
        public static extern void Release();
    }
    #endregion
    
    ....
}
```

<br>

###### reference
https://www.cnblogs.com/marblemm/p/7804374.html <br>
https://blog.csdn.net/cartzhang/article/details/9097043