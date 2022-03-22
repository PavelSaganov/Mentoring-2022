using FileSystemVisitorConsole.Listeners;
using FileSystemVisitorLibrary;
using FileSystemVisitorLibrary.Configuration;
using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Linq;

namespace FileSystemVisitorConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new FileSystemVisitorConfiguration(Directory.GetCurrentDirectory());

            var visitor = new FileSystemVisitor(Directory.GetCurrentDirectory(),
                (element) => element.FullName.Contains('a'),
                (element) => element.FullName.Contains('r'));

            #region Listen
            var listener = new ConsoleFileSystemVisitorListener(config.CountForExclude, config.CountForAbort);
            listener.ListenForStartSearch(visitor);
            listener.ListenForFileFound(visitor);
            listener.ListenForDirectoryFound(visitor);
            listener.ListenForFilteredDirectoryFound(visitor);
            listener.ListenForFilteredFileFound(visitor);
            listener.ListenForEndSearch(visitor);
            #endregion

            var command = string.Empty;
            while (true)
            {
                Console.Clear();
                visitor.GetFiles();
                visitor.GetDirectories();
                listener.ClearLists();
                Console.WriteLine("Input directory name you want to visit, or ../ to return to previpus directory:");
                command = Console.ReadLine();
                visitor.MoveToDirectory(command);

            }
        }
    }
}
