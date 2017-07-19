/*
* MATLAB Compiler: 5.1 (R2014a)
* Date: Sat May 06 13:53:39 2017
* Arguments: "-B" "macro_default" "-W" "dotnet:add,Class1,0.0,private" "-T" "link:lib"
* "-d" "E:\UseMatlab_0505\example\add\for_testing" "-v" "E:\UseMatlab_0505\example\add.m"
* "class{Class1:E:\UseMatlab_0505\example\add.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace add
{

  /// <summary>
  /// The Class1 class provides a CLS compliant, MWArray interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// E:\UseMatlab_0505\example\add.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class Class1 : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static Class1()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

          int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "add.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Class1 class.
    /// </summary>
    public Class1()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Class1()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the add MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 加法运算
    /// c = a + b
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray add()
    {
      return mcr.EvaluateFunction("add", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the add MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 加法运算
    /// c = a + b
    /// </remarks>
    /// <param name="a">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray add(MWArray a)
    {
      return mcr.EvaluateFunction("add", a);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the add MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 加法运算
    /// c = a + b
    /// </remarks>
    /// <param name="a">Input argument #1</param>
    /// <param name="b">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray add(MWArray a, MWArray b)
    {
      return mcr.EvaluateFunction("add", a, b);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the add MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 加法运算
    /// c = a + b
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] add(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "add", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the add MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 加法运算
    /// c = a + b
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="a">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] add(int numArgsOut, MWArray a)
    {
      return mcr.EvaluateFunction(numArgsOut, "add", a);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the add MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 加法运算
    /// c = a + b
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="a">Input argument #1</param>
    /// <param name="b">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] add(int numArgsOut, MWArray a, MWArray b)
    {
      return mcr.EvaluateFunction(numArgsOut, "add", a, b);
    }


    /// <summary>
    /// Provides an interface for the add function in which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 加法运算
    /// c = a + b
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void add(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
    {
      mcr.EvaluateFunction("add", numArgsOut, ref argsOut, argsIn);
    }



    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
