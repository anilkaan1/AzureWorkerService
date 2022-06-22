using AzureWorkerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureWorkerService.Services
{
    public interface INotificationService
    {
        Task<bool> CreateOrUpdateInstallationAsync(DeviceInstallation deviceInstallation, CancellationToken token);
        Task<bool> DeleteInstallationByIdAsync(string installationId, CancellationToken token);
        Task<bool> RequestNotificationAsync(NotificationRequest notificationRequest, CancellationToken token);

    }
}
