using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;
namespace FactoryAutomation.Common
{
    public static class AssemblyHelper
    {
        public static Assembly[] LoadAssemblyForDirectory(string _DirectoryPath)
        {
            DirectoryInfo di = new DirectoryInfo(_DirectoryPath);
            FileInfo[] fiArray = di.GetFiles();
            FileInfo[] dllInfo = (from fi in fiArray
                                 where fi.Extension == ".dll"
                                 select fi).ToArray();
            Assembly[] assemblys = new Assembly[dllInfo.Length];
            for(int i = 0; i < assemblys.Length; i++)
            {
                try
                {
                    if(File.Exists(dllInfo[i].FullName) == true)
                    {
                        assemblys[i] = Assembly.LoadFile(dllInfo[i].FullName);
                    }
                }
                catch(Exception e)
                {

                }
            }
            return assemblys;
        }
    }
}
