using FileSystemVisitorLibrary;
using FileSystemVisitorLibrary.Configuration;
using System;
using System.Collections;
using System.Configuration;
using System.IO;

namespace FileSystemVisitorConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new FileSystemVisitorConfiguration(Directory.GetCurrentDirectory());

            Console.WriteLine("There are files of directory:");
            var visitorWithoutSorting = new FileSystemVisitor(config);
            Console.WriteLine();
            Console.WriteLine("There are sorted files of directory:");
            var visitorWithSorting = new FileSystemVisitor(config, (arr) => arr.Sort() );
        }
    }
}
