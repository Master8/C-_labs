using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;

using Framework;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\Users\maste\Documents\Visual Studio 2015\Projects\CS_labs\Lab5\Plugins";

            List<IPlugin> plugins = new List<IPlugin>();

            var dllFileNames = Directory.GetFiles(path, "*.dll");

            foreach (string fileName in dllFileNames)
            {
                Assembly assembly = Assembly.LoadFile(fileName);

                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetInterface(typeof(IPlugin).FullName) != null && !type.IsInterface && !type.IsAbstract)
                    {
                        plugins.Add((IPlugin)Activator.CreateInstance(type));
                    }
                }
            }
            
            foreach (IPlugin plugin in plugins)
                Console.WriteLine(plugin.Name);
        }
    }
}
