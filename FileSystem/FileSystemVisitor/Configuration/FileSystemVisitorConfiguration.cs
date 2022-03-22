using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FileSystemVisitorLibrary.Configuration
{
    public class FileSystemVisitorConfiguration : IConfiguration
    {
        public bool AbortRequested { get; set; }

        public bool ExcludeRequested { get; set; }

        public int CountForAbort { get; set; }

        public int CountForExclude { get; set; }

        public string PathToFolder { get; set; }

        public Action<ArrayList> actionToFilter { get; set; }

        public FileSystemVisitorConfiguration(string pathToFolder = null)
        {
            CountForAbort = int.Parse(ConfigurationManager.AppSettings.Get("CountForAbort"));
            PathToFolder = pathToFolder ?? ConfigurationManager.AppSettings.Get("PathToFolder");
            CountForExclude = int.Parse(ConfigurationManager.AppSettings.Get("CountForExclude"));
            AbortRequested = bool.Parse(ConfigurationManager.AppSettings.Get("AbortRequested"));
            ExcludeRequested = bool.Parse(ConfigurationManager.AppSettings.Get("ExcludeRequested"));
        }
    }
}
