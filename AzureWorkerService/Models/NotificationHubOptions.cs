using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkerService.Models
{
    public class NotificationHubOptions
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ConnectionString { get; set; }
    }
}
