using System;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog((context, services, configuration) =>
                {
                    configuration
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File(path: "Logs/log.txt")
                    .WriteTo.Email(GetEmailConnectionInfo());
                });

        private static EmailConnectionInfo GetEmailConnectionInfo()
        {
            return new EmailConnectionInfo()
            {
                EmailSubject = "Log from module9",
                MailServer = "smtp.gmail.com",
                FromEmail = "module9testacc@gmail.com",
                ToEmail = "sahpavval@gmail.com",
                Port = 587,
                EnableSsl = true,
                NetworkCredentials = new NetworkCredential("module9testacc@gmail.com", "aspqsboajuqxpsux")
            };
        }
    }
}
