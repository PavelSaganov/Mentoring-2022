using FileSystemVisitorLibrary.Events;
using System;
using System.Collections;
using System.Configuration;
using System.IO;

namespace FileSystemVisitorLibrary
{
    public class FileSystemVisitor : IEnumerable
    {
        // Hardcoded config. Should be changed
        private static readonly int countForAbort = int.Parse(ConfigurationManager.AppSettings.Get("CountForAbort"));
        private static readonly int countForExclude = int.Parse(ConfigurationManager.AppSettings.Get("CountForExclude"));

        private string PathToFolder { get; set; }

        private event EventHandler<FolderElementAddingEventArgs> NewFolderElement;
        private event EventHandler StartSearch;
        private event EventHandler EndSearch;

        public ArrayList ElementsOfFolder { get; set; }

        public FileSystemVisitor(string pathToFolder)
        {
            ElementsOfFolder = new ArrayList();
            PathToFolder = pathToFolder;

            // Events
            StartSearch += OnStartFilter;
            EndSearch += OnEndFilter;
            NewFolderElement += OnElementAdding;

            // Search and add folder elements
            StartSearch?.Invoke(this, new EventArgs());
            AddFindedFolderElements();
            EndSearch?.Invoke(this, new EventArgs());
        }

        public FileSystemVisitor(string pathToFolder, Action<ArrayList> actionToFilter) : this(pathToFolder)
        {
            actionToFilter.Invoke(ElementsOfFolder);
        }

        /// <summary>
        /// Filling PathToFolder property by folder elements name. Also invokes handler of adding new element.
        /// </summary>
        private void AddFindedFolderElements()
        {
            var allElements = GetElementsOfFolder();
            for (int elementNumber = 0; elementNumber < allElements.Length; elementNumber++)
                NewFolderElement?.Invoke(this, new FolderElementAddingEventArgs(allElements[elementNumber], elementNumber, false, false));
        }

        private void OnStartFilter(object sender, EventArgs e)
        {
            Console.WriteLine("Search is starting...");
        }

        private void OnEndFilter(object sender, EventArgs e)
        {
            Console.WriteLine("Search ended...");
        }

        /// <summary>
        /// Handler to add new element. Can abort adding, add new element or skip element.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments/</param>
        private void OnElementAdding(object sender, FolderElementAddingEventArgs e)
        {
            if (e.AbortRequested && e.CountOfElements == countForAbort)
            {
                if (ElementsOfFolder.Count > 0)
                    ElementsOfFolder.Clear();
                Console.WriteLine($"Adding aborted since count of elements > {countForAbort}");
            }
            else if (!(e.ExcludeRequested && e.CountOfElements > countForExclude))
            {
                ElementsOfFolder.Add(e.ElementName);
                Console.WriteLine($"Added new folder element: {e.ElementName}");
            }
        }

        private string[] GetElementsOfFolder() => Directory.GetFileSystemEntries(PathToFolder);

        /// <summary>
        /// Get enumerator of class.
        /// </summary>
        /// <returns>Enumerator based on ElementsOfFolderEnumerator</returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var element in ElementsOfFolder)
            {
                yield return element;
            }
        }
    }
}
