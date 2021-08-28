using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;
using System;
using System.Reflection;

namespace Mtbs.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Read Configuration from appSettings
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                //.WriteTo.File(new CompactJsonFormatter(), @"logs/log.txt",
                //    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                //    rollingInterval: RollingInterval.Day)
                .CreateLogger();
            try
            {
                Log.Information($"Starting application: Mtbs.Api");
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "An Unexpected error occurred while running application.");
                throw;
            }
            finally
            {
                Log.Information("Exiting application.");
                Log.CloseAndFlush();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
