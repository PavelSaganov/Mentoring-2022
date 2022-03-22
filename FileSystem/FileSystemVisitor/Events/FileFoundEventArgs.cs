using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitorLibrary.Events
{
    public class FileFoundEventArgs : FolderElementFoundEventArgs<FileInfo>
    {
        public FileFoundEventArgs(FileInfo folderElement, IEnumerable<FileInfo> folderElementQuery, bool excludeRequires = false, bool abortRequires = false)
            : base(folderElement, folderElementQuery, excludeRequires, abortRequires)
        { }
    }
}
