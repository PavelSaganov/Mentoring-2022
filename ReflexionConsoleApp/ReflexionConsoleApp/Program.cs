using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ReflectionApp.Sdk;
using ReflexionConsoleApp.Configuration;
using ReflexionConsoleApp.ConfigurationPlugins;

namespace ReflexionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationPlugins = ConfigurationPlugin.ReadAllPlugins();
            Console.WriteLine($"{configurationPlugins.Count} config plugin(s) founded!");

            Console.WriteLine("Adding settings...");
            foreach (var configProvider in configurationPlugins)
            {
                var managerComponent = new ConfigurationManagerComponent(configProvider);

                managerComponent.AddSetting("CountOfThreads", "5");
                managerComponent.AddSetting("MainThreadName", "MainThread");
                managerComponent.AddSetting("MainUrl", "http://localhost:80");
                managerComponent.AddSetting("MaxRandomNumber", "1750");
            }

            foreach (var plugin in configurationPlugins)
            {
                Console.WriteLine($"\n{plugin.GetType().Name} plugin settings:");
                Console.WriteLine($"CountOfThreads:{plugin.ReadSetting("CountOfThreads")}");
                Console.WriteLine($"MainThreadName:{plugin.ReadSetting("MainThreadName")}");

                Console.WriteLine($"MainUrl:{plugin.ReadSetting("MainUrl")}");
                Console.WriteLine($"MaxRandomNumber:{plugin.ReadSetting("MaxRandomNumber")}");
            }
        }
    }
}
