using Notifaction.RealTime.DTOs;
using Notifaction.RealTime.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.RealTime.services.contract
{
    public interface IDashboardHostedService
    {
        void DoWork(Mess mess);
        void GetMs(Message me);
    }
}
