using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkerService.FileWatch.JsonModels
{
    public class NotificationModel : RequestModel
    {
        public string requestid { get; set; }
        public string requestDesc { get; set; }
        public bool willBeLogged { get; set; }
        public string text { get; set; }
        public string action { get; set; }
        public List<string> tags { get; set; }
        public bool silent { get; set; }

    }




    public class NotificationList{
        public List<NotificationModel> NotificationItems { get; set; }
    }

    


}
