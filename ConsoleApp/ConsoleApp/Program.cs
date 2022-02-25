using System;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your name is: ");
            string username = Console.ReadLine();

            Console.WriteLine($"Hello, {username}");
            Console.ReadKey();
        }
    }
}
