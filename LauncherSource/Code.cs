using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

// Modify various properties here:
[assembly:AssemblyTitle("A launcher for CTT-PS script.")]
[assembly:AssemblyProduct("Custom Texture Tool PS Launcher")]
[assembly:AssemblyCopyright("Bighead")]
[assembly:AssemblyVersion("1.0.0.0")]
[assembly:AssemblyFileVersion("1.0.0.0")]

namespace CTTLauncher
{
  class CTTMainClass
  {
    public static void Main()
    {
      // Edit the script name here.
      string ScriptName   = "*Custom Texture Tool PS v*.*.ps1";
      string CurrentPath  = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      string[] Collection = Directory.GetFiles(CurrentPath, ScriptName, SearchOption.TopDirectoryOnly);

      foreach (string ScriptFile in Collection)
      {
        string ScriptPath = Path.Combine(Directory.GetCurrentDirectory(), ScriptFile);
        var PSProcess = new Process();
        PSProcess.StartInfo.UseShellExecute = true;
        PSProcess.StartInfo.RedirectStandardOutput = false;
        PSProcess.StartInfo.FileName = @"C:\windows\system32\windowspowershell\v1.0\powershell.exe";
        PSProcess.StartInfo.Arguments = "-ExecutionPolicy Bypass -file " + '"' + ScriptPath + '"';
        PSProcess.Start();
        break;
      }
    }
  }
}
