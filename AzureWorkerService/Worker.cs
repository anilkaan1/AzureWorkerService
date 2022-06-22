using AzureWorkerService.Models;
using AzureWorkerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AzureWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        readonly INotificationService _notificationService;
        private FileAdaptedServices _fileAdaptedServices;
        Timer a;

        public Worker(ILogger<Worker> logger, INotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;



            _fileAdaptedServices = new FileAdaptedServices(             _logger,       _notificationService       );



            
        }
        
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            System.Diagnostics.Debugger.Launch();

            //3 adet dosya izleme timerý burada baþlýyor.
            await base.StartAsync(cancellationToken);
            a = new Timer(myTimerCallBack, a, 1, 4000);

        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            
        }

        public void myTimerCallBack(object objParam)
        {
             _fileAdaptedServices.ReadAndSendNotifications();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            //    var success = await _notificationService.RequestNotificationAsync(new NotificationRequest
            //    {
            //        Action = "action_a",
            //        Text = "ugly face anisa",
            //        Tags = Array.Empty<string>(),
            //        Silent = false
            //    }, CancellationToken.None);


            //   await Task.Delay(1000, stoppingToken);
            //}
        }
    }
}
