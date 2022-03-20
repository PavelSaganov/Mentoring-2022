using FileSystemVisitorLibrary;
using System;
using System.Collections;
using System.IO;

namespace FileSystemVisitorConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("There are files of directory:");
            var visitorWithoutSorting = new FileSystemVisitor(Directory.GetCurrentDirectory());
            Console.WriteLine();
            Console.WriteLine("There are sorted files of directory:");
            var visitorWithSorting = new FileSystemVisitor(Directory.GetCurrentDirectory(), (arr) => arr.Sort() );
        }
    }
}
