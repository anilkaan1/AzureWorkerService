using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkerService.Models
{
    public class Registration
    {
        public string UserId;
        public string InstallationId;

        public Registration(string UserId, string InstallationId)
        {
            this.UserId = UserId;
            this.InstallationId = InstallationId;
        }
    }
}
