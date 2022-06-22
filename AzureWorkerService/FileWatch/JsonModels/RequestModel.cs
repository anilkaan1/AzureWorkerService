using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureWorkerService.FileWatch.JsonModels
{
    public interface RequestModel
    {
        string requestid { get; set; }

        string requestDesc { get; set; }

        bool willBeLogged { get; set; }

    }
}
