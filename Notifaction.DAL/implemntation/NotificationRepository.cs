using Notifaction.DAL.contract;
using Notifaction.DAL.implemntation.Base;
using Notifaction.DB;
using Notifaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.DAL.implemntation
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        private readonly DataContext _Context;

        public NotificationRepository(DataContext Context) : base(Context)
        {
            _Context = Context;
        }
    }
}
