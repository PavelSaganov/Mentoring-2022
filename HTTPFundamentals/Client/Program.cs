using System;
using System.Net.Http;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Methods available: Information\nSuccess\nRedirection\nClient error\nServer error");
                Console.WriteLine("Input method name...");
                string name = Console.ReadLine();
                try
                {
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = client.GetAsync($"http://localhost:8888/{name}").Result;
                    string responseBody = response.Content.ReadAsStringAsync().Result;

                    Console.WriteLine($"Response with status code {(int)response.StatusCode}. Body: {responseBody}");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }
    }
}
