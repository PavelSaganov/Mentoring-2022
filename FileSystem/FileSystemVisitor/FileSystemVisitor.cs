using FileSystemVisitorLibrary.Configuration;
using FileSystemVisitorLibrary.Events;
using System;
using System.Collections;
using System.Configuration;
using System.IO;

namespace FileSystemVisitorLibrary
{
    public class FileSystemVisitor : IEnumerable
    {
        private event EventHandler<FolderElementAddingEventArgs> NewFolderElement;
        private event EventHandler StartSearch;
        private event EventHandler EndSearch;
        
        private string PathToFolder { get; set; }

        public ArrayList ElementsOfFolder { get; set; }

        private readonly FileSystemVisitorConfiguration _configuration;

        public FileSystemVisitor(FileSystemVisitorConfiguration configuration)
        {
            ElementsOfFolder = new ArrayList();
            PathToFolder = configuration.PpathToFolder;
            _configuration = configuration;

            // Events
            StartSearch += OnStartFilter;
            EndSearch += OnEndFilter;
            NewFolderElement += OnElementAdding;

            // Search and add folder elements
            StartSearch?.Invoke(this, new EventArgs());
            AddFindedFolderElements();
            EndSearch?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Constructor that invokes action to filter founded elemenents of folder.
        /// </summary>
        /// <param name="pathToFolder">Path to folder to work with.</param>
        /// <param name="configuration">Configuration with necessary parameters.</param>
        /// <param name="actionToFilter">Action to filter folder elements.</param>
        public FileSystemVisitor(FileSystemVisitorConfiguration configuration, Action<ArrayList> actionToFilter)
            : this(configuration)
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
            {
                NewFolderElement?.Invoke(this, 
                    new FolderElementAddingEventArgs(allElements[elementNumber], elementNumber, _configuration.ExcludeRequested, _configuration.AbortRequested));
            }
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
            if (e.AbortRequested && e.CountOfElements == _configuration.CountForAbort)
            {
                if (ElementsOfFolder.Count > 0)
                    ElementsOfFolder.Clear();
                Console.WriteLine($"Adding aborted since count of elements > {_configuration.CountForAbort}");
            }
            else if (!(e.ExcludeRequested && e.CountOfElements > _configuration.CountForExclude))
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
