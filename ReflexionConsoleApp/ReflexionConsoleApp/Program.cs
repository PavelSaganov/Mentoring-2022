using System;
using ReflectionApp.Sdk.PluginEnums;
using ReflexionConsoleApp.ConfigurationPlugins;

namespace ReflexionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationPlugins = ConfigurationPlugin.ReadAllPlugins();
            Console.WriteLine($"{configurationPlugins.Count} config plugin(s) founded!");

            FileConfigTest();
            ConfigManagerTest();
        }

        private static void ConfigManagerTest()
        {
            var configManagerPlugin = ConfigurationPlugin.ReadPlugin(ConfigProvider.ConfigManagerProvider);

            Console.WriteLine("AppSettings before changing:");
            Console.WriteLine($"MainUrl:{configManagerPlugin.ReadSetting("MainUrl")}");
            Console.WriteLine($"MaxRandomNumber:{configManagerPlugin.ReadSetting("MaxRandomNumber")}");

            configManagerPlugin.AddSetting("MaxRandomNumber", "1790");
            configManagerPlugin.AddSetting("MainUrl", "http://localhost:8080");

            Console.WriteLine();
            Console.WriteLine("AppSettings after changing:");
            Console.WriteLine($"MainUrl:{configManagerPlugin.ReadSetting("MainUrl")}");
            Console.WriteLine($"MaxRandomNumber:{configManagerPlugin.ReadSetting("MaxRandomNumber")}");
            Console.WriteLine();
        }

        private static void FileConfigTest()
        {
            var fileConfigPlugin = ConfigurationPlugin.ReadPlugin(ConfigProvider.FileProfider);

            Console.WriteLine();
            Console.WriteLine("file config before changing:");
            Console.WriteLine($"CountOfThreads:{fileConfigPlugin.ReadSetting("CountOfThreads")}");
            Console.WriteLine($"MainThreadName:{fileConfigPlugin.ReadSetting("MainThreadName")}");

            fileConfigPlugin.AddSetting("CountOfThreads", "15");
            fileConfigPlugin.AddSetting("MainThreadName", "MainThread2");

            Console.WriteLine();
            Console.WriteLine("file config after changing:");
            Console.WriteLine($"CountOfThreads:{fileConfigPlugin.ReadSetting("CountOfThreads")}");
            Console.WriteLine($"MainThreadName:{fileConfigPlugin.ReadSetting("MainThreadName")}");
            Console.WriteLine();
        }
    }
}
