﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkerService.Models
{
    public class DeviceInstallation
    {
        [Required]
        public string InstallationId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Platform { get; set; }

        [Required]
        public string PushChannel { get; set; }

        public IList<string> Tags { get; set; } = Array.Empty<string>();

    }
}
