using System;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please enter any string:");
            string inputed = Console.ReadLine();

            Console.WriteLine($"First character of {inputed} is {GetFirstCharacterOf(inputed)}");
        }

        private static char GetFirstCharacterOf(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new Exception("String is null!");

            return str.FirstOrDefault();
        }
    }
}