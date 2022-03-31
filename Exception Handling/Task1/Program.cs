using System;
using Task1.CustomExceptions;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please enter any string:");
            string stringValue = Console.ReadLine();
            try
            {
                Console.WriteLine($"First character of {stringValue} is {GetFirstCharacterOf(stringValue)}");
            }
            catch (NullOrEmptyStringException e)
            {
                Console.WriteLine($"Founded {e.GetType()} exception with the message: {e.Message}");
            }
        }

        private static char GetFirstCharacterOf(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                throw new NullOrEmptyStringException("Value is null or whitespace!");

            return str[0];
        }
    }
}