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
    public class OrderService : Service<Order>, IOrderService
    {
        IUnitOfWork _unitOfWork;
        IOrderRepository _orderRepository;

        public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
            : base(unitOfWork, orderRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }
    }
}
