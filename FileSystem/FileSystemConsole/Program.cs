using FileSystemVisitorLibrary;
using System;
using System.IO;

namespace FileSystemVisitorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] arr = new string[] { "ssss", "sss2", "33" };
            var a0 = new FileSystemVisitor(Directory.GetCurrentDirectory());
            foreach (var item in a0)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------------------");
            var a = new FileSystemVisitor(Directory.GetCurrentDirectory(), (ara) => Array.Sort(ara) );
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
}
