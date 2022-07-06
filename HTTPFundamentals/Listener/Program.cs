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
        }

        public static HttpListenerResponse Information(HttpListenerContext context, string calledMethodName)
        {
            var response = context.Response;
            response.StatusCode = (int)HttpStatusCode.Continue;
            return CreateResponseWithMethodNameBody(context, calledMethodName, response);

        }

        public static HttpListenerResponse Success(HttpListenerContext context, string calledMethodName)
        {
            var response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            return CreateResponseWithMethodNameBody(context, calledMethodName, response);
        }

        public static HttpListenerResponse Redirection(HttpListenerContext context, string calledMethodName)
        {
            var response = context.Response;
            response.StatusCode = (int)HttpStatusCode.Redirect;
            return CreateResponseWithMethodNameBody(context, calledMethodName, response);
        }

        public static HttpListenerResponse ClientError(HttpListenerContext context, string calledMethodName)
        {
            var response = context.Response;
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            return CreateResponseWithMethodNameBody(context, calledMethodName, response);
        }

        public static HttpListenerResponse ServerError(HttpListenerContext context, string calledMethodName)
        {
            var response = context.Response;
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return CreateResponseWithMethodNameBody(context, calledMethodName, response);
        }

        private static HttpListenerResponse CreateResponseWithMethodNameBody(HttpListenerContext context, string calledMethodName, HttpListenerResponse response)
        {
            string responseString = calledMethodName;
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);

            output.Close();

            return context.Response;
        }
    }
}
