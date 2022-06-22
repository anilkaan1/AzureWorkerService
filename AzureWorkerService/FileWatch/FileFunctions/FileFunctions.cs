using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkerService.FileWatch.FileFunctions
{
    public class FileFunctions
    {
        private static string myPath = @"C:\Users\Eutek\source\repos\AzureWorkerService\AzureWorkerService\TrackedArea";

        public static List<String> GetNotificationFiles()
        {

            List<String> files = new List<String>();

            files = Directory.GetFiles(string.Format(@"{0}\Notification", myPath)).ToList();


            //files.OrderBy();

            //Neye göre sıralayalım ?

            return files;


        }


        public static void moveProcessed(string fileName)
        {
            if (File.Exists(string.Format(@"{0}\NotificationSended\{1}", myPath, Path.GetFileName(fileName))))
                File.Delete(string.Format(@"{0}\NotificationSended\{1}", myPath, Path.GetFileName(fileName)));

            string currentFilePath = string.Format(@"{0}\Notification\{1}", myPath, Path.GetFileName(fileName));

            string nextFilePath = string.Format(@"{0}\NotificationSended\{1}", myPath, Path.GetFileName(fileName));

            File.Move(currentFilePath, nextFilePath);
        }

    }
}
