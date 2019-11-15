using System.Reflection;

// This should be the same version as below
[assembly: AssemblyFileVersion("1.1.8")]

#if DEBUG
[assembly: AssemblyInformationalVersion("1.1.8-PreRelease")]
#else
[assembly: AssemblyInformationalVersion("1.1.7")]
#endif

[assembly: AssemblyTitle("FunBase")]
[assembly: AssemblyDescription("Basic Functional library in C#")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct("FunBase")]
[assembly: AssemblyCopyright("Copyright © 2019")]
[assembly: AssemblyCulture("")]
