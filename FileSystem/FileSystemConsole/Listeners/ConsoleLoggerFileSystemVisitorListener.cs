using FileSystemVisitorLibrary;
using System;

namespace FileSystemVisitorConsole.Listeners
{
    public class ConsoleLoggerFileSystemVisitorListener
    {
        public void ListenForStartSearch(FileSystemVisitor visitor) => visitor.StartSearch += ConsoleOutputStartSearch;

        public void ListenForEndSearch(FileSystemVisitor visitor) => visitor.StartSearch += ConsoleOutputEndSearch;

        private void ConsoleOutputStartSearch(object sender, EventArgs e) => Console.WriteLine("Search is starting...");
        private void ConsoleOutputEndSearch(object sender, EventArgs e) => Console.WriteLine("Search ended...");
    }
}
