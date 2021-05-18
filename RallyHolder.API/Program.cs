using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using RallyHolder.Domain.Context;
using System;

namespace RallyHolder.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder
                         .ConfigureNLog("nlog.config")
                         .GetCurrentClassLogger();

            logger.Info("Initializing the Application");
            try
            {
                //CreateHostBuilder(args).Build().Run();
                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    DatasBase.InitialLoad(services);
                }
                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "The Application stopped running");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseStartup<Startup>()
                    .UseNLog();
                });
    }
}
