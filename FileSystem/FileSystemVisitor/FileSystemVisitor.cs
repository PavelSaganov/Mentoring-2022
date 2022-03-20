using System;
using System.Collections;
using System.IO;

namespace FileSystemVisitorLibrary
{
    public class FileSystemVisitor : IEnumerable
    {
        private string PathToFolder { get; set; }
        public string[] ElementsOfFolder { get; set; }

        public FileSystemVisitor(string pathToFolder)
        {
            PathToFolder = pathToFolder;
            ElementsOfFolder = GetElementsOfFolder(); 
        }

        public FileSystemVisitor(string pathToFolder, Action<string[]> actionToFilter)
        {
            PathToFolder = pathToFolder;
            ElementsOfFolder = GetElementsOfFolder();
            actionToFilter.Invoke(ElementsOfFolder);
        }

        private string[] GetElementsOfFolder()
        {
            return Directory.GetFileSystemEntries(PathToFolder);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var element in ElementsOfFolder)
            {
                yield return element;
            }
        }
    }
}
