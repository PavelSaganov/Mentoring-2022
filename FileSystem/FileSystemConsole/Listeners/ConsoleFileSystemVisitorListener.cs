using FileSystemVisitorLibrary;
using FileSystemVisitorLibrary.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSystemVisitorConsole.Listeners
{
    public class ConsoleFileSystemVisitorListener
    {
        /// <summary>
        /// Constructor with parameters to exlude or abort searching of files/directories.
        /// </summary>
        /// <param name="countForExclude">Count of folder elements to stop searching.</param>
        /// <param name="countForAbort">Count of folder elements to abort searching.</param>
        public ConsoleFileSystemVisitorListener(int countForExclude, int countForAbort)
        {
            this.countForExclude = countForExclude;
            this.countForAbort = countForAbort;
        }

        private readonly int countForExclude;

        private readonly int countForAbort;

        public List<FileInfo> Files { get; set; } = new List<FileInfo>();

        public List<FileInfo> FilteredFiles { get; set; } = new List<FileInfo>();

        public List<DirectoryInfo> Directories { get; set; } = new List<DirectoryInfo>();

        public List<DirectoryInfo> FilteredDirectories { get; set; } = new List<DirectoryInfo>();

        #region ListenMethods
        public void ListenForStartSearch(FileSystemVisitor visitor) => visitor.StartSearch += ConsoleOutputStartSearch;

        public void ListenForEndSearch(FileSystemVisitor visitor) => visitor.EndSearch += ConsoleOutputEndSearch;

        public void ListenForFileFound(FileSystemVisitor visitor) => visitor.FileFound += ConsoleOutputFileFound;

        public void ListenForFilteredFileFound(FileSystemVisitor visitor) => visitor.FilteredFileFound += ConsoleOutputFilteredFileFound;

        public void ListenForDirectoryFound(FileSystemVisitor visitor) => visitor.DirectoryFound += ConsoleOutputDirectoryFound;

        public void ListenForFilteredDirectoryFound(FileSystemVisitor visitor) => visitor.FilteredDirectoryFound += ConsoleOutputFilteredDirectoryFound;
        #endregion

        public void ClearLists()
        {
            Files.Clear();
            FilteredFiles.Clear();
            Directories.Clear();
            FilteredDirectories.Clear();
        }

        #region ConsoleOutputMethods
        private void ConsoleOutputDirectoryFound(object sender, DirectoryFoundEventArgs e)
        {
            Console.WriteLine($"Founded directory: {e.FolderElement.Name}");
            AddDirectoriesToList(e, Directories);
        }

        private void ConsoleOutputFilteredDirectoryFound(object sender, DirectoryFoundEventArgs e)
        {
            Console.WriteLine($"Founded filtered directory: {e.FolderElement.Name}");
            AddDirectoriesToList(e, FilteredDirectories);
        }

        private void ConsoleOutputFileFound(object sender, FileFoundEventArgs e)
        {
            Console.WriteLine($"Founded file: {e.FolderElement.Name}");
            AddFilesToList(e, Files);
        }

        private void ConsoleOutputFilteredFileFound(object sender, FileFoundEventArgs e)
        {
            Console.WriteLine($"Founded filtered file: {e.FolderElement.Name}");
            AddFilesToList(e, FilteredFiles);
        }

        private void ConsoleOutputStartSearch(object sender, EventArgs e) => Console.WriteLine("Search is starting...");

        private void ConsoleOutputEndSearch(object sender, EventArgs e) => Console.WriteLine("Search ended...");
        #endregion


        private void AddFilesToList(FileFoundEventArgs e, List<FileInfo> list)
        {
            if (!(e.AbortRequires && list.Count > countForAbort))
            {
                if (!(e.ExcludeRequires && list.Count > countForExclude))
                    list.Add(e.FolderElement);
                else
                    Console.WriteLine("File excluded...");
            }
            else
            {
                if (list.Any())
                {
                    list.Clear();
                    Console.WriteLine("Aborted...");
                }
            }
        }

        private void AddDirectoriesToList(DirectoryFoundEventArgs e, List<DirectoryInfo> list)
        {
            if (!(e.AbortRequires && list.Count > countForAbort))
            {
                if (!(e.ExcludeRequires && list.Count > countForExclude))
                    list.Add(e.FolderElement);
                else
                    Console.WriteLine("File excluded...");
            }
            else
            {
                if (list.Any())
                {
                    list.Clear();
                    Console.WriteLine("Aborted...");
                }
            }
        }

    }
}
