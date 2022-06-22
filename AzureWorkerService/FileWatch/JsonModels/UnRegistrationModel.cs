using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkerService.FileWatch.JsonModels
{
    public class UnRegistrationModel : RequestModel
    {
        public string requestid { get; set; }
        public string requestDesc { get; set; }
        public bool willBeLogged { get; set; }
    }
}
