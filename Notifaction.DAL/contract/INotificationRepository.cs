using Notifaction.DAL.contract.Base;
using Notifaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.DAL.contract
{
    public interface INotificationRepository : IRepository<Notification>
    {
    }
}
