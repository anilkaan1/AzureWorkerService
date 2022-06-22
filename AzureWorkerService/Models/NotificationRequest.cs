using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkerService.Models
{
    public class NotificationRequest
    {
        public string Text { get; set; }
        public string Action { get; set; }
        public string[] Tags { get; set; } = Array.Empty<string>();
        public bool Silent
        {
            get; set;
        }
    }
}
