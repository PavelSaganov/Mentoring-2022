﻿using System;
using GreetingLibrary;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your name is: ");
            var username = Console.ReadLine();

            var greetingString = WorkWithString.GetGreetingsForName(username);
            Console.WriteLine(greetingString);
            Console.ReadKey();
        }
    }
}
