using Notifaction.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifaction.API
{
    public interface IDashboardHostedService
    {
        void DoWork(Mess mess);
    }
}
