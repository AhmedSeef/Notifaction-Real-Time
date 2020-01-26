using Notifaction.RealTime.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.RealTime.services.contract
{
    public interface IDashboardHostedService
    {
        void DoWork(Mess mess);
    }
}
