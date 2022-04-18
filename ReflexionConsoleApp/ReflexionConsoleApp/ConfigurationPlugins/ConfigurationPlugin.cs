using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ReflectionApp.Sdk;
using ReflectionApp.Sdk.Attributes;
using ReflectionApp.Sdk.PluginEnums;

namespace ReflexionConsoleApp.ConfigurationPlugins
{
    public static class ConfigurationPlugin
    {
        public static List<IConfigurationProvider> ReadAllPlugins()
        {
            var pluginsLists = new List<IConfigurationProvider>();
            var files = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.GetFiles("*.dll");

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file.FullName);

                var pluginTypes = assembly.GetTypes().Where(t =>
                    typeof(IConfigurationProvider).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract).ToArray();

                foreach (var pluginType in pluginTypes)
                {
                    var pluginInstance = Activator.CreateInstance(pluginType) as IConfigurationProvider;
                    pluginsLists.Add(pluginInstance);
                }
            }

            return pluginsLists;
        }

        public static IConfigurationProvider ReadPlugin(ConfigProvider provider)
        {
            var files = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.GetFiles("*.dll");
            var attributeType = GetTypeOfAttribute(provider);

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file.FullName);

                foreach (var type in assembly.GetTypes())
                {
                    foreach (var prop in type.GetProperties())
                    {
                    }
                }

                var pluginType = assembly.GetTypes().Where(t =>
                    typeof(IConfigurationProvider).IsAssignableFrom(t)
                    && !t.IsInterface
                    && !t.IsAbstract
                    && t.GetProperties().All(p => p.GetCustomAttributes(false).Any(attribute => attribute.GetType().Equals(attributeType)))
                    ).FirstOrDefault();

                var pluginInstance = Activator.CreateInstance(pluginType) as IConfigurationProvider;
                return pluginInstance;
            }

            return null;
        }

        private static Type GetTypeOfAttribute(ConfigProvider provider)
        {
            switch (provider)
            {
                case ConfigProvider.FileProfider:
                    return typeof(FileConfigurationAttribute);
                case ConfigProvider.ConfigManagerProvider:
                    return typeof(ConfigurationManagerAttribute);
            }
            return typeof(FileConfigurationAttribute);
        }
    }
}
