using System;
using ReflexionConsoleApp.Configuration;

namespace ReflexionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var config = new ConfigurationManagerProvider();
            //config.AddSetting("TaskNumber", "1");

            var config = new FileManagerProvider();
            config.AddSetting("CountOfThreads", "1");

            foreach (var item in config.ReadAllSettings())
            {
                Console.WriteLine(item.Value);
            }

            //config.ReadAllSettings();


        }
    }
}
