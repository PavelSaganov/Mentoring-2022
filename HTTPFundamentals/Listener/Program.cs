using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;

namespace Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8888/");
            listener.Start();

            Console.WriteLine("Listening...");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;

                var calledMethodName = request.RawUrl.Substring(1);
                typeof(Program).GetMethod(calledMethodName).Invoke(null, new ArrayList() { context, calledMethodName }.ToArray());
            }

            listener.Stop();
        }

        public static HttpListenerResponse Information(HttpListenerContext context, string calledMethodName)
        {
            // Construct a response.
            var response = context.Response;
            string responseString = calledMethodName;
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.StatusCode = (int)HttpStatusCode.Continue;

            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            // You must close the output stream.
            output.Close();

            return context.Response;
        }

        public static HttpListenerResponse Success(HttpListenerContext context, string calledMethodName)
        {
            // Construct a response.
            var response = context.Response;
            string responseString = calledMethodName;
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.StatusCode = (int)HttpStatusCode.OK;

            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            // You must close the output stream.
            output.Close();

            return context.Response;
        }

        public static HttpListenerResponse Redirection(HttpListenerContext context, string calledMethodName)
        {
            // Construct a response.
            var response = context.Response;
            string responseString = calledMethodName;
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.StatusCode = (int)HttpStatusCode.Redirect;

            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            // You must close the output stream.
            output.Close();

            return context.Response;
        }

        public static HttpListenerResponse ClientError(HttpListenerContext context, string calledMethodName)
        {
            // Construct a response.
            var response = context.Response;
            string responseString = calledMethodName;
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.StatusCode = (int)HttpStatusCode.BadRequest;

            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            // You must close the output stream.
            output.Close();

            return context.Response;
        }

        public static HttpListenerResponse ServerError(HttpListenerContext context, string calledMethodName)
        {
            // Construct a response.
            var response = context.Response;
            string responseString = calledMethodName;
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            // You must close the output stream.
            output.Close();

            return context.Response;
        }
    }
}
