using FileSystemVisitorLibrary.Configuration;
using FileSystemVisitorLibrary.CustomCollections;
using FileSystemVisitorLibrary.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitorLibrary
{
    public class FileSystemVisitor : IEnumerable
    {
        public FileSystemVisitor(string pathToFolder)
        {
            PathToFolder = pathToFolder;
        }

        /// <summary>
        /// Constructor that invokes action to filter founded elemenents of folder.
        /// </summary>
        /// <param name="pathToFolder">Path to folder to work with.</param>
        /// <param name="filterForFolders">Predicate to filter folders.</param>
        public FileSystemVisitor(string pathToFolder, Predicate<DirectoryInfo> filterForFolders)
            : this(pathToFolder)
        {
            FilterForDirectories = filterForFolders;
        }

        /// <summary>
        /// Constructor that invokes action to filter founded elemenents of folder.
        /// </summary>
        /// <param name="pathToFolder">Path to folder to work with.</param>
        /// <param name="filterForFiles">Predicate to filter files.</param>
        public FileSystemVisitor(string pathToFolder, Predicate<FileInfo> filterForFiles)
            : this(pathToFolder)
        {
            FilterForFiles = filterForFiles;
        }

        /// <summary>
        /// Constructor that invokes action to filter founded elemenents of folder.
        /// </summary>
        /// <param name="pathToFolder">Path to folder to work with.</param>
        /// <param name="filterForFolders">Predicate to filter folders.</param>
        /// <param name="filterForFiles">Predicate to filter files.</param>
        public FileSystemVisitor(string pathToFolder, Predicate<DirectoryInfo> filterForFolders, Predicate<FileInfo> filterForFiles)
            : this(pathToFolder, filterForFolders)
        {
            FilterForFiles = filterForFiles;
        }

        public event EventHandler<FileFoundEventArgs> FileFound;
        public event EventHandler<DirectoryFoundEventArgs> DirectoryFound;
        public event EventHandler<FileFoundEventArgs> FilteredFileFound;
        public event EventHandler<DirectoryFoundEventArgs> FilteredDirectoryFound;
        public event EventHandler StartSearch;
        public event EventHandler EndSearch;

        private string PathToFolder { get; set; }

        Predicate<DirectoryInfo> FilterForDirectories { get; set; }

        Predicate<FileInfo> FilterForFiles { get; set; }

        public CustomInfoCollection<FileInfo> GetFiles()
        {
            StartSearch?.Invoke(this, new EventArgs());
            ValidatePathToDirectory();

            var directory = new DirectoryInfo(PathToFolder);
            var files = directory.GetFiles();

            for (int i = 0; i < files.Length; i++)
            {
                if (FilterForFiles != null && FilterForFiles(files[i]))
                    OnFilteredFileFound(this, new FileFoundEventArgs(files[i], files, true, true));
                else
                    OnFileFound(this, new FileFoundEventArgs(files[i], files, true, true));
            }

            EndSearch?.Invoke(this, new EventArgs());

            var result = new CustomInfoCollection<FileInfo>(files);
            return result;
        }

        public CustomInfoCollection<DirectoryInfo> GetDirectories()
        {
            StartSearch?.Invoke(this, new EventArgs());
            ValidatePathToDirectory();

            var directory = new DirectoryInfo(PathToFolder);
            var subdirectories = directory.GetDirectories();

            for (int i = 0; i < subdirectories.Length; i++)
                if (FilterForDirectories != null && FilterForDirectories(subdirectories[i]))
                    OnFilteredDirectoryFound(this, new DirectoryFoundEventArgs(subdirectories[i], subdirectories, true, true));
                else
                    OnDirectoryFound(this, new DirectoryFoundEventArgs(subdirectories[i], subdirectories, true, true));

            EndSearch?.Invoke(this, new EventArgs());

            var result = new CustomInfoCollection<DirectoryInfo>(subdirectories);
            return result;
        }

        #region Handlers
        private void OnFileFound(object sender, FileFoundEventArgs e) => FileFound?.Invoke(sender, e);

        private void OnFilteredFileFound(object sender, FileFoundEventArgs e) => FilteredFileFound?.Invoke(sender, e);

        private void OnDirectoryFound(object sender, DirectoryFoundEventArgs e) => DirectoryFound?.Invoke(sender, e);

        private void OnFilteredDirectoryFound(object sender, DirectoryFoundEventArgs e) => FilteredDirectoryFound?.Invoke(sender, e);
        #endregion

        public void MoveToDirectory(string directoryName)
        {
            if (directoryName == "../")
                PathToFolder = Directory.GetParent(PathToFolder).FullName;
            else
            {
                var newPath = $"{PathToFolder}//{directoryName}";
                if (Directory.Exists(newPath))
                    PathToFolder = $"{PathToFolder}//{directoryName}";
            }
        }

        /// <summary>
        /// Get enumerator of class.
        /// </summary>
        /// <returns>Enumerator based on ElementsOfFolderEnumerator</returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var element in new List<int> { 1, 2, 3 })
            {
                yield return element;
            }
        }

        private void ValidatePathToDirectory()
        {
            if (!Directory.Exists(PathToFolder))
                throw new DirectoryNotFoundException();
        }
    }
}
