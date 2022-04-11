using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ReflectionApp.Sdk;

namespace ReflexionConsoleApp.ConfigurationPlugins
{
    public static class ConfigurationPlugin
    {
        public static List<IConfigurationBase> ReadAllPlugins()
        {
            var pluginsLists = new List<IConfigurationBase>();
            var files = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.GetFiles("*.dll");

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file.FullName);

                var pluginTypes = assembly.GetTypes().Where(t =>
                    typeof(IConfigurationBase).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract).ToArray();

                foreach (var pluginType in pluginTypes)
                {
                    var pluginInstance = Activator.CreateInstance(pluginType) as IConfigurationBase;
                    pluginsLists.Add(pluginInstance);
                }
            }

            return pluginsLists;
        }
    }
}
