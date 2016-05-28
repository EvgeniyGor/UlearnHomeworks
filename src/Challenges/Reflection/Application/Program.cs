using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GetPluginNames().ForEach(Console.WriteLine);
        }

        private static List<string> GetPluginNames()
        {
            return new List<string>
            {
                GetPluginName("Plugin1.dll"),
                GetPluginName("Plugin2.dll")
            };
        }

        private static string GetPluginName(string dllName)
        {
            var baseDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent?.Parent?.Parent;

            var pluginPath = baseDirectory?.GetFiles(dllName, SearchOption.AllDirectories).FirstOrDefault()?.FullName;

            if (pluginPath == null)
            {
                throw new ArgumentException($"Dll name { dllName } is wrong");
            }

            var pluginAssembly = Assembly.LoadFrom(pluginPath);

            var pluginType = pluginAssembly.DefinedTypes.FirstOrDefault();

            if (pluginType == null)
            {
                throw new TypeLoadException("Failed to load plugin type");
            }

            return pluginAssembly.CreateInstance(pluginType.FullName)?.ToString();
        }
    }
}
