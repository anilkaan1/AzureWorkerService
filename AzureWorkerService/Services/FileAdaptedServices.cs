using AzureWorkerService.FileWatch.FileFunctions;
using AzureWorkerService.FileWatch.JsonModels;
using AzureWorkerService.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AzureWorkerService.Services
{
    public class FileAdaptedServices
    {
        private readonly ILogger<Worker> _logger;
        private INotificationService _notificationService;

        public FileAdaptedServices(ILogger<Worker> logger, INotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;
        }

        public async void ReadAndSendNotifications()
        {

            List<string> notificationFileNames = FileFunctions.GetNotificationFiles();

            if (notificationFileNames != null)
            {
            


            foreach (string fileName in notificationFileNames){

                NotificationList myNotModel = JsonFunctions.readNotification(fileName);

                FileFunctions.moveProcessed(fileName);

                foreach (NotificationModel notificationModel in myNotModel.NotificationItems)
                { 
                    NotificationRequest myModel = new NotificationRequest();

                    myModel.Action = notificationModel.action;
                    myModel.Tags = notificationModel.tags.ToArray();
                    myModel.Text = notificationModel.text;
                    myModel.Silent = notificationModel.silent;

                    _logger.LogInformation("RequestDescription: {0}", notificationModel.requestDesc);
                                   
                    _logger.LogInformation("RequestId: {0}\n", notificationModel.requestid);

                    TextWriter tsw = new StreamWriter(string.Format(@"{0}\{1}", Directory.GetCurrentDirectory(), "Log.txt"), true);

                    tsw.Write("RequestDescription: " + notificationModel.requestDesc + "\n" + "RequestId: " + notificationModel.requestid + "\n");

                    tsw.Close();

                    bool success = await _notificationService.RequestNotificationAsync(myModel,System.Threading.CancellationToken.None);
                    
                    

                    }

                }


            }

        }
    }
}
