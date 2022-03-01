using System;

namespace GreetingLibrary
{
    public static class WorkWithString
    {
        public static string GetGreetingsForName(string name)
        {
            return $"{DateTime.Now}: Hello, {name}!";
        }
    }
}
