/*
* MATLAB Compiler: 5.1 (R2014a)
* Date: Sat May 06 15:10:39 2017
* Arguments: "-B" "macro_default" "-W" "dotnet:demo,Demo,0.0,private" "-T" "link:lib"
* "-d" "E:\UseMatlab_0505\Handian\demo\for_testing" "-v"
* "E:\UseMatlab_0505\Handian\demo.m" "E:\UseMatlab_0505\Handian\Greed.m"
* "E:\UseMatlab_0505\Handian\Greed2t.m" "E:\UseMatlab_0505\Handian\Plot4Sim.m"
* "E:\UseMatlab_0505\Handian\poly_intersect.m" "E:\UseMatlab_0505\Handian\RandHandian.m"
* "E:\UseMatlab_0505\Handian\ThreeGroup.m"
* "class{Demo:E:\UseMatlab_0505\Handian\demo.m,E:\UseMatlab_0505\Handian\Greed.m,E:\UseMat
* lab_0505\Handian\Greed2t.m,E:\UseMatlab_0505\Handian\Plot4Sim.m,E:\UseMatlab_0505\Handia
* n\poly_intersect.m,E:\UseMatlab_0505\Handian\RandHandian.m,E:\UseMatlab_0505\Handian\Thr
* eeGroup.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace demoNative
{

  /// <summary>
  /// The Demo class provides a CLS compliant, Object (native) interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// E:\UseMatlab_0505\Handian\demo.m
  /// <newpara></newpara>
  /// E:\UseMatlab_0505\Handian\Greed.m
  /// <newpara></newpara>
  /// E:\UseMatlab_0505\Handian\Greed2t.m
  /// <newpara></newpara>
  /// E:\UseMatlab_0505\Handian\Plot4Sim.m
  /// <newpara></newpara>
  /// E:\UseMatlab_0505\Handian\poly_intersect.m
  /// <newpara></newpara>
  /// E:\UseMatlab_0505\Handian\RandHandian.m
  /// <newpara></newpara>
  /// E:\UseMatlab_0505\Handian\ThreeGroup.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class Demo : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Compiler Runtime
    /// instance.
    /// </summary>
    static Demo()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

          int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "demo.ctf";

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
    /// Constructs a new instance of the Demo class.
    /// </summary>
    public Demo()
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
    ~Demo()
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
    /// Provides a void output, 0-input Objectinterface to the demo MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// actual main
    /// demo
    /// </remarks>
    ///
    public void demo()
    {
      mcr.EvaluateFunction(0, "demo", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the demo MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// actual main
    /// demo
    /// </remarks>
    /// <param name="_U4b">Input argument #1</param>
    ///
    public void demo(Object _U4b)
    {
      mcr.EvaluateFunction(0, "demo", _U4b);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the demo MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// actual main
    /// demo
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] demo(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "demo", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the demo MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// actual main
    /// demo
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="_U4b">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] demo(int numArgsOut, Object _U4b)
    {
      return mcr.EvaluateFunction(numArgsOut, "demo", _U4b);
    }


    /// <summary>
    /// Provides an interface for the demo function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// actual main
    /// demo
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("demo", 1, 0, 0)]
    protected void demo(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("demo", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the Greed MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// PP(:,:) = PPt(kkk,:,:);
    /// PP = poly_intersect(np,PP);
    /// PPt(kkk,:,:) = PP(:,:);    
    /// out = kkk
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object Greed()
    {
      return mcr.EvaluateFunction("Greed", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the Greed MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// PP(:,:) = PPt(kkk,:,:);
    /// PP = poly_intersect(np,PP);
    /// PPt(kkk,:,:) = PP(:,:);    
    /// out = kkk
    /// </remarks>
    /// <param name="np">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object Greed(Object np)
    {
      return mcr.EvaluateFunction("Greed", np);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the Greed MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// PP(:,:) = PPt(kkk,:,:);
    /// PP = poly_intersect(np,PP);
    /// PPt(kkk,:,:) = PP(:,:);    
    /// out = kkk
    /// </remarks>
    /// <param name="np">Input argument #1</param>
    /// <param name="P">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object Greed(Object np, Object P)
    {
      return mcr.EvaluateFunction("Greed", np, P);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the Greed MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// PP(:,:) = PPt(kkk,:,:);
    /// PP = poly_intersect(np,PP);
    /// PPt(kkk,:,:) = PP(:,:);    
    /// out = kkk
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Greed(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Greed", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the Greed MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// PP(:,:) = PPt(kkk,:,:);
    /// PP = poly_intersect(np,PP);
    /// PPt(kkk,:,:) = PP(:,:);    
    /// out = kkk
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="np">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Greed(int numArgsOut, Object np)
    {
      return mcr.EvaluateFunction(numArgsOut, "Greed", np);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the Greed MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// PP(:,:) = PPt(kkk,:,:);
    /// PP = poly_intersect(np,PP);
    /// PPt(kkk,:,:) = PP(:,:);    
    /// out = kkk
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="np">Input argument #1</param>
    /// <param name="P">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Greed(int numArgsOut, Object np, Object P)
    {
      return mcr.EvaluateFunction(numArgsOut, "Greed", np, P);
    }


    /// <summary>
    /// Provides an interface for the Greed function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// PP(:,:) = PPt(kkk,:,:);
    /// PP = poly_intersect(np,PP);
    /// PPt(kkk,:,:) = PP(:,:);    
    /// out = kkk
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("Greed", 2, 1, 0)]
    protected void Greed(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("Greed", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the Greed2t MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object Greed2t()
    {
      return mcr.EvaluateFunction("Greed2t", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the Greed2t MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="np">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object Greed2t(Object np)
    {
      return mcr.EvaluateFunction("Greed2t", np);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the Greed2t MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="np">Input argument #1</param>
    /// <param name="P">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object Greed2t(Object np, Object P)
    {
      return mcr.EvaluateFunction("Greed2t", np, P);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the Greed2t MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Greed2t(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Greed2t", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the Greed2t MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="np">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Greed2t(int numArgsOut, Object np)
    {
      return mcr.EvaluateFunction(numArgsOut, "Greed2t", np);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the Greed2t MATLAB function.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="np">Input argument #1</param>
    /// <param name="P">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Greed2t(int numArgsOut, Object np, Object P)
    {
      return mcr.EvaluateFunction(numArgsOut, "Greed2t", np, P);
    }


    /// <summary>
    /// Provides an interface for the Greed2t function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("Greed2t", 2, 1, 0)]
    protected void Greed2t(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("Greed2t", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a void output, 0-input Objectinterface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    ///
    public void Plot4Sim()
    {
      mcr.EvaluateFunction(0, "Plot4Sim", new Object[]{});
    }


    /// <summary>
    /// Provides a void output, 1-input Objectinterface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="mP1">Input argument #1</param>
    ///
    public void Plot4Sim(Object mP1)
    {
      mcr.EvaluateFunction(0, "Plot4Sim", mP1);
    }


    /// <summary>
    /// Provides a void output, 2-input Objectinterface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    ///
    public void Plot4Sim(Object mP1, Object P1)
    {
      mcr.EvaluateFunction(0, "Plot4Sim", mP1, P1);
    }


    /// <summary>
    /// Provides a void output, 3-input Objectinterface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    ///
    public void Plot4Sim(Object mP1, Object P1, Object mP2)
    {
      mcr.EvaluateFunction(0, "Plot4Sim", mP1, P1, mP2);
    }


    /// <summary>
    /// Provides a void output, 4-input Objectinterface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    /// <param name="P2">Input argument #4</param>
    ///
    public void Plot4Sim(Object mP1, Object P1, Object mP2, Object P2)
    {
      mcr.EvaluateFunction(0, "Plot4Sim", mP1, P1, mP2, P2);
    }


    /// <summary>
    /// Provides a void output, 5-input Objectinterface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    /// <param name="P2">Input argument #4</param>
    /// <param name="mP3">Input argument #5</param>
    ///
    public void Plot4Sim(Object mP1, Object P1, Object mP2, Object P2, Object mP3)
    {
      mcr.EvaluateFunction(0, "Plot4Sim", mP1, P1, mP2, P2, mP3);
    }


    /// <summary>
    /// Provides a void output, 6-input Objectinterface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    /// <param name="P2">Input argument #4</param>
    /// <param name="mP3">Input argument #5</param>
    /// <param name="P3">Input argument #6</param>
    ///
    public void Plot4Sim(Object mP1, Object P1, Object mP2, Object P2, Object mP3, Object 
                   P3)
    {
      mcr.EvaluateFunction(0, "Plot4Sim", mP1, P1, mP2, P2, mP3, P3);
    }


    /// <summary>
    /// Provides a void output, 7-input Objectinterface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    /// <param name="P2">Input argument #4</param>
    /// <param name="mP3">Input argument #5</param>
    /// <param name="P3">Input argument #6</param>
    /// <param name="mP4">Input argument #7</param>
    ///
    public void Plot4Sim(Object mP1, Object P1, Object mP2, Object P2, Object mP3, Object 
                   P3, Object mP4)
    {
      mcr.EvaluateFunction(0, "Plot4Sim", mP1, P1, mP2, P2, mP3, P3, mP4);
    }


    /// <summary>
    /// Provides a void output, 8-input Objectinterface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    /// <param name="P2">Input argument #4</param>
    /// <param name="mP3">Input argument #5</param>
    /// <param name="P3">Input argument #6</param>
    /// <param name="mP4">Input argument #7</param>
    /// <param name="P4">Input argument #8</param>
    ///
    public void Plot4Sim(Object mP1, Object P1, Object mP2, Object P2, Object mP3, Object 
                   P3, Object mP4, Object P4)
    {
      mcr.EvaluateFunction(0, "Plot4Sim", mP1, P1, mP2, P2, mP3, P3, mP4, P4);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Plot4Sim(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Plot4Sim", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="mP1">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Plot4Sim(int numArgsOut, Object mP1)
    {
      return mcr.EvaluateFunction(numArgsOut, "Plot4Sim", mP1);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Plot4Sim(int numArgsOut, Object mP1, Object P1)
    {
      return mcr.EvaluateFunction(numArgsOut, "Plot4Sim", mP1, P1);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Plot4Sim(int numArgsOut, Object mP1, Object P1, Object mP2)
    {
      return mcr.EvaluateFunction(numArgsOut, "Plot4Sim", mP1, P1, mP2);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    /// <param name="P2">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Plot4Sim(int numArgsOut, Object mP1, Object P1, Object mP2, Object P2)
    {
      return mcr.EvaluateFunction(numArgsOut, "Plot4Sim", mP1, P1, mP2, P2);
    }


    /// <summary>
    /// Provides the standard 5-input Object interface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    /// <param name="P2">Input argument #4</param>
    /// <param name="mP3">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Plot4Sim(int numArgsOut, Object mP1, Object P1, Object mP2, Object 
                       P2, Object mP3)
    {
      return mcr.EvaluateFunction(numArgsOut, "Plot4Sim", mP1, P1, mP2, P2, mP3);
    }


    /// <summary>
    /// Provides the standard 6-input Object interface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    /// <param name="P2">Input argument #4</param>
    /// <param name="mP3">Input argument #5</param>
    /// <param name="P3">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Plot4Sim(int numArgsOut, Object mP1, Object P1, Object mP2, Object 
                       P2, Object mP3, Object P3)
    {
      return mcr.EvaluateFunction(numArgsOut, "Plot4Sim", mP1, P1, mP2, P2, mP3, P3);
    }


    /// <summary>
    /// Provides the standard 7-input Object interface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    /// <param name="P2">Input argument #4</param>
    /// <param name="mP3">Input argument #5</param>
    /// <param name="P3">Input argument #6</param>
    /// <param name="mP4">Input argument #7</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Plot4Sim(int numArgsOut, Object mP1, Object P1, Object mP2, Object 
                       P2, Object mP3, Object P3, Object mP4)
    {
      return mcr.EvaluateFunction(numArgsOut, "Plot4Sim", mP1, P1, mP2, P2, mP3, P3, mP4);
    }


    /// <summary>
    /// Provides the standard 8-input Object interface to the Plot4Sim MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="mP1">Input argument #1</param>
    /// <param name="P1">Input argument #2</param>
    /// <param name="mP2">Input argument #3</param>
    /// <param name="P2">Input argument #4</param>
    /// <param name="mP3">Input argument #5</param>
    /// <param name="P3">Input argument #6</param>
    /// <param name="mP4">Input argument #7</param>
    /// <param name="P4">Input argument #8</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] Plot4Sim(int numArgsOut, Object mP1, Object P1, Object mP2, Object 
                       P2, Object mP3, Object P3, Object mP4, Object P4)
    {
      return mcr.EvaluateFunction(numArgsOut, "Plot4Sim", mP1, P1, mP2, P2, mP3, P3, mP4, P4);
    }


    /// <summary>
    /// Provides an interface for the Plot4Sim function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// if mP1 &lt; 2 || mP2 &lt; 2 || mP3 &lt; 2 || mP4 &lt; 2 
    /// return;
    /// end
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("Plot4Sim", 8, 0, 0)]
    protected void Plot4Sim(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("Plot4Sim", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the poly_intersect MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// **********************************************************   
    /// 判断各点按顺序相连的线段是否有交点
    /// poly_x,poly_y 分别为各个点的x,y坐标，均为列向量
    /// **********************************************************   
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object poly_intersect()
    {
      return mcr.EvaluateFunction("poly_intersect", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the poly_intersect MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// **********************************************************   
    /// 判断各点按顺序相连的线段是否有交点
    /// poly_x,poly_y 分别为各个点的x,y坐标，均为列向量
    /// **********************************************************   
    /// </remarks>
    /// <param name="np">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object poly_intersect(Object np)
    {
      return mcr.EvaluateFunction("poly_intersect", np);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the poly_intersect MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// **********************************************************   
    /// 判断各点按顺序相连的线段是否有交点
    /// poly_x,poly_y 分别为各个点的x,y坐标，均为列向量
    /// **********************************************************   
    /// </remarks>
    /// <param name="np">Input argument #1</param>
    /// <param name="PP_in1">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object poly_intersect(Object np, Object PP_in1)
    {
      return mcr.EvaluateFunction("poly_intersect", np, PP_in1);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the poly_intersect MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// **********************************************************   
    /// 判断各点按顺序相连的线段是否有交点
    /// poly_x,poly_y 分别为各个点的x,y坐标，均为列向量
    /// **********************************************************   
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] poly_intersect(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "poly_intersect", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the poly_intersect MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// **********************************************************   
    /// 判断各点按顺序相连的线段是否有交点
    /// poly_x,poly_y 分别为各个点的x,y坐标，均为列向量
    /// **********************************************************   
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="np">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] poly_intersect(int numArgsOut, Object np)
    {
      return mcr.EvaluateFunction(numArgsOut, "poly_intersect", np);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the poly_intersect MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// **********************************************************   
    /// 判断各点按顺序相连的线段是否有交点
    /// poly_x,poly_y 分别为各个点的x,y坐标，均为列向量
    /// **********************************************************   
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="np">Input argument #1</param>
    /// <param name="PP_in1">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] poly_intersect(int numArgsOut, Object np, Object PP_in1)
    {
      return mcr.EvaluateFunction(numArgsOut, "poly_intersect", np, PP_in1);
    }


    /// <summary>
    /// Provides an interface for the poly_intersect function in which the input and
    /// output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// **********************************************************   
    /// 判断各点按顺序相连的线段是否有交点
    /// poly_x,poly_y 分别为各个点的x,y坐标，均为列向量
    /// **********************************************************   
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("poly_intersect", 2, 1, 0)]
    protected void poly_intersect(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("poly_intersect", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object RandHandian()
    {
      return mcr.EvaluateFunction("RandHandian", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="length">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object RandHandian(Object length)
    {
      return mcr.EvaluateFunction("RandHandian", length);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="length">Input argument #1</param>
    /// <param name="width">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object RandHandian(Object length, Object width)
    {
      return mcr.EvaluateFunction("RandHandian", length, width);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="length">Input argument #1</param>
    /// <param name="width">Input argument #2</param>
    /// <param name="yover">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object RandHandian(Object length, Object width, Object yover)
    {
      return mcr.EvaluateFunction("RandHandian", length, width, yover);
    }


    /// <summary>
    /// Provides a single output, 4-input Objectinterface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="length">Input argument #1</param>
    /// <param name="width">Input argument #2</param>
    /// <param name="yover">Input argument #3</param>
    /// <param name="minidistP2P">Input argument #4</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object RandHandian(Object length, Object width, Object yover, Object 
                        minidistP2P)
    {
      return mcr.EvaluateFunction("RandHandian", length, width, yover, minidistP2P);
    }


    /// <summary>
    /// Provides a single output, 5-input Objectinterface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="length">Input argument #1</param>
    /// <param name="width">Input argument #2</param>
    /// <param name="yover">Input argument #3</param>
    /// <param name="minidistP2P">Input argument #4</param>
    /// <param name="NumofP">Input argument #5</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object RandHandian(Object length, Object width, Object yover, Object 
                        minidistP2P, Object NumofP)
    {
      return mcr.EvaluateFunction("RandHandian", length, width, yover, minidistP2P, NumofP);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] RandHandian(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "RandHandian", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="length">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] RandHandian(int numArgsOut, Object length)
    {
      return mcr.EvaluateFunction(numArgsOut, "RandHandian", length);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="length">Input argument #1</param>
    /// <param name="width">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] RandHandian(int numArgsOut, Object length, Object width)
    {
      return mcr.EvaluateFunction(numArgsOut, "RandHandian", length, width);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="length">Input argument #1</param>
    /// <param name="width">Input argument #2</param>
    /// <param name="yover">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] RandHandian(int numArgsOut, Object length, Object width, Object yover)
    {
      return mcr.EvaluateFunction(numArgsOut, "RandHandian", length, width, yover);
    }


    /// <summary>
    /// Provides the standard 4-input Object interface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="length">Input argument #1</param>
    /// <param name="width">Input argument #2</param>
    /// <param name="yover">Input argument #3</param>
    /// <param name="minidistP2P">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] RandHandian(int numArgsOut, Object length, Object width, Object 
                          yover, Object minidistP2P)
    {
      return mcr.EvaluateFunction(numArgsOut, "RandHandian", length, width, yover, minidistP2P);
    }


    /// <summary>
    /// Provides the standard 5-input Object interface to the RandHandian MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="length">Input argument #1</param>
    /// <param name="width">Input argument #2</param>
    /// <param name="yover">Input argument #3</param>
    /// <param name="minidistP2P">Input argument #4</param>
    /// <param name="NumofP">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] RandHandian(int numArgsOut, Object length, Object width, Object 
                          yover, Object minidistP2P, Object NumofP)
    {
      return mcr.EvaluateFunction(numArgsOut, "RandHandian", length, width, yover, minidistP2P, NumofP);
    }


    /// <summary>
    /// Provides an interface for the RandHandian function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// width  = 1500;
    /// length = 1500;
    /// minidistP2P = 50;
    /// NumofP =40;
    /// P=[553,	 49,1,0;     x,y,形状材料(1:8ABS; 2:8PP; 3:7ABS; 4:7PP; 5:方1PP;  
    /// 6:方2ABS; 7：方3PP; 8: 方4PP)   指定工位 1-3
    /// 570,	100,1,0;
    /// 571,	163,1,0;
    /// 576,	233,1,0;
    /// 581,	308,1,0;
    /// 587,	383,1,0;
    /// 593,	458,1,0;
    /// 600,	538,1,0;
    /// 606,	613,1,0;
    /// 621,	634,1,0;
    /// 629,	669,1,0;
    /// 617,	664,7,0;
    /// 672,	658,1,0;
    /// 722,	633,1,0;
    /// 771,	594,1,0;
    /// 758,	561,1,0;
    /// 758,	539,7,0;
    /// 754,	503,1,0;
    /// 737,	473,1,0;
    /// 728,	414,1,0;
    /// 722,	342,1,0;
    /// 715,	318,7,0;
    /// 715,	256,7,0;
    /// 715,	193,7,0;
    /// 716,	139,7,0;
    /// 719,	 97,7,0;
    /// 857,	137,1,0;
    /// 937,	166,1,0;
    /// 985,	214,1,0;
    /// 1009,	278,1,0;
    /// 1008,	353,1,0;
    /// 989,	394,1,0;
    /// 1008,	431,1,0;
    /// 991,	473,1,0;
    /// 1010,	510,1,0;
    /// 1010,	613,1,0;
    /// 1009,	673,1,0;
    /// 1009,	733,1,0;
    /// 1010,	797,1,0;
    /// 1007,	861,1,0;];
    /// tP = P(:,1);
    /// P(:,1) = P(:,2);
    /// P(:,2) = tP - 540;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("RandHandian", 5, 8, 0)]
    protected void RandHandian(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("RandHandian", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }
    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the ThreeGroup MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 按指定的分工位
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object ThreeGroup()
    {
      return mcr.EvaluateFunction("ThreeGroup", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the ThreeGroup MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 按指定的分工位
    /// </remarks>
    /// <param name="np">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object ThreeGroup(Object np)
    {
      return mcr.EvaluateFunction("ThreeGroup", np);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the ThreeGroup MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 按指定的分工位
    /// </remarks>
    /// <param name="np">Input argument #1</param>
    /// <param name="P">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object ThreeGroup(Object np, Object P)
    {
      return mcr.EvaluateFunction("ThreeGroup", np, P);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the ThreeGroup MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 按指定的分工位
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] ThreeGroup(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "ThreeGroup", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the ThreeGroup MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 按指定的分工位
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="np">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] ThreeGroup(int numArgsOut, Object np)
    {
      return mcr.EvaluateFunction(numArgsOut, "ThreeGroup", np);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the ThreeGroup MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// 按指定的分工位
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="np">Input argument #1</param>
    /// <param name="P">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] ThreeGroup(int numArgsOut, Object np, Object P)
    {
      return mcr.EvaluateFunction(numArgsOut, "ThreeGroup", np, P);
    }


    /// <summary>
    /// Provides an interface for the ThreeGroup function in which the input and output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// 按指定的分工位
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("ThreeGroup", 2, 6, 0)]
    protected void ThreeGroup(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("ThreeGroup", numArgsOut, ref argsOut, argsIn, varArgsIn);
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
