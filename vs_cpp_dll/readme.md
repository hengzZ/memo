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
