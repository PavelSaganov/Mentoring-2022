using System;
using SuperMegaFantasticLibrary;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your name is: ");
            string username = Console.ReadLine();

            string greetingString = WorkWithString.GetGreetingsForName(username);
            Console.WriteLine(greetingString);
            Console.ReadKey();
        }
    }
}
