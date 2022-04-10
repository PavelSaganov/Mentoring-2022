using System;
using System.IO;
using ReflexionConsoleApp.Configuration;

namespace ReflexionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var config = new ConfigurationManagerProvider();
            //config.AddSetting("TaskNumber", "1");
            //using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory()))
            //{
            //    int a = 2 + 3;
            //}

            var config = new FileManagerProvider();
            config.AddSetting("CountOfThreads", "1");


        }
    }
}
