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
            Console.WriteLine("Hello World!");
            var a0 = new FileSystemVisitor(Directory.GetCurrentDirectory());
            //foreach (var item in a0)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("-------------------------------------------");
            var a = new FileSystemVisitor(Directory.GetCurrentDirectory(), (ara) => ara.Sort() );
            //foreach (var item in a)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
