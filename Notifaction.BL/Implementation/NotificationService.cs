using Notifaction.BL.Contract;
using Notifaction.BL.Implementation.Base;
using Notifaction.DAL.contract;
using Notifaction.DAL.contract.Base;
using Notifaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.BL.Implementation
{
    public class NotificationService : Service<Notification>, INotificationService
    {
        IUnitOfWork _unitOfWork;
        INotificationRepository _notificationRepository;

        public NotificationService(IUnitOfWork unitOfWork, INotificationRepository notificationRepository)
            : base(unitOfWork, notificationRepository)
        {
            _unitOfWork = unitOfWork;
            _notificationRepository = notificationRepository;
        }
    }
}
