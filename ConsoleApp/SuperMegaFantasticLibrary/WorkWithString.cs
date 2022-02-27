using System;

namespace SuperMegaFantasticLibrary
{
    public static class WorkWithString
    {
        public static string GetGreetingsForName(string name)
        {
            return $"{DateTime.Now}: Hello, {name}!";
        }

        public static string ConcatinateWithHelloWorld(string str)
        {
            return $"Hello World! {str}";
        }
    }
}
