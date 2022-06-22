using AzureWorkerService.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkerService.FileWatch.JsonModels
{
    public class JsonFunctions
    {
        public static NotificationList readNotification(string filename)
        {

            NotificationList notObj = new NotificationList();

            using (StreamReader file = File.OpenText(String.Format(filename)))
            {

                using (JsonTextReader reader2 = new JsonTextReader(file))
                {

                    // 'Exception has been thrown by the target of an invocation.'
                    // reader2.ReadAsString();

                    string a = file.ReadToEnd();

                    notObj = JsonConvert.DeserializeObject<NotificationList>(a);
                }
            }

            return notObj;

        }
    }
}
