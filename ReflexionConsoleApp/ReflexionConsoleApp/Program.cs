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

            var configurationManagerComponent = new ConfigurationManagerComponent(configurationPlugins.FirstOrDefault());

            Console.WriteLine("Adding settings...");
            configurationManagerComponent.AddSetting("CountOfThreads", "5");   
            configurationManagerComponent.AddSetting("MainThreadName", "MainThread");   

            configurationManagerComponent.AddSetting("MainUrl", "http://localhost:80");   
            configurationManagerComponent.AddSetting("MaxRandomNumber", "1750");   

            Console.WriteLine("All settings:");

            foreach (var plugin in configurationPlugins)
            {
                Console.WriteLine($"\n{plugin.GetType().Name} plugin:");
                foreach (var setting in plugin.ReadAllSettings())
                {
                    Console.WriteLine($"{setting.Key}:{setting.Value}");
                }
            }
        }
    }
}
