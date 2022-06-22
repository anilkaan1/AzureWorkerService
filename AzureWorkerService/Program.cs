using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AzureWorkerService.Models;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using AzureWorkerService.Services;

namespace AzureWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args).UseWindowsService(options =>
            {
                options.ServiceName = "Service1";
            })
                .ConfigureServices((hostContext, services) =>
                {
                    //services.Configure<NotificationHubOptions>(hostContext.Configuration.GetSection("NotificationHub"));

                    services.AddSingleton<INotificationService, NotificationHubService>();

                    //services.AddOptions<NotificationHubOptions>()
                    //.Bind(hostContext.Configuration.GetSection("NotificationHub"));

                    services.AddHostedService<Worker>();

                });
    }

}
