using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AzureWorkerService.FileWatch.JsonModels
{
    public class RegistrationModel : RequestModel
    {
        public string requestid { get; set; }
        public string requestDesc { get; set; }
        public string InstallationId { get; set; }
        public string Platform { get; set; }
        public string PushChannel { get; set; }
        public string UserId { get; set; }
        public bool willBeLogged { get; set; }
        public class NotificationList
        {
            public List<RegistrationModel> RegistrationItems { get; set; }
        }
    }
}