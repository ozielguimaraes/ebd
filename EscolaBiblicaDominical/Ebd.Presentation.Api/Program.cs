using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace Ebd.Presentation.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.File("Logs/application.log")
            //    .CreateLogger();
#if DEBUG
            CreateHostBuilder(args)
                .Build()
                .Run();
#else
            BuildWebHost(args).Run();
#endif

            //Log.CloseAndFlush();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .ConfigureLogging((_, builder) =>
                    {
                        ConfigureLog(builder);
                    });
                });

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.AddJsonFile("appsettings.json", false, true);
                builder.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false, true);
                builder.AddEnvironmentVariables();
            })
            .UseStartup<Startup>()
            .ConfigureLogging((_, builder) =>
               {
                   ConfigureLog(builder);
               })
            .Build();

        private static void ConfigureLog(ILoggingBuilder builder)
        {
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddEventLog(options =>
                {
                    options.SourceName = "Ebd";
                });
                builder.AddLog4Net("log4net.config");
                loggingBuilder.AddSerilog();
            });
        }
    }
}
