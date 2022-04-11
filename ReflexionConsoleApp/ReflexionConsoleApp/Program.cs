using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ReflectionApp.Sdk;
using ReflexionConsoleApp.ConfigurationPlugins;

namespace ReflexionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationPlugins = ConfigurationPlugin.ReadAllPlugins();
            Console.WriteLine($"{configurationPlugins.Count} plugin(s) added!");

            Console.WriteLine("All settings:");

            // Some of this settings are in AppSettings, some of the settings are in settings.txt depends on attribute
            foreach (var plugin in configurationPlugins)
            {
                Console.WriteLine($"\n{plugin.GetType().Name}:");
                plugin.AddSetting("CountOfThreads", "4");
                plugin.AddSetting("MainThreadName", "MainThread");
                //plugin.AddSetting("MainUrl", "http:/localhost:80/");
                //plugin.AddSetting("TaskNumber", "10");
                //plugin.AddSetting("MaxRandomNumber", "50");

                foreach (var setting in plugin.ReadAllSettings())
                {
                    Console.WriteLine($"{setting.Key}:{setting.Value}");
                }
            }
        }
    }
}
