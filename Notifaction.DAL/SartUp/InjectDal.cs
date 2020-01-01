using Microsoft.Extensions.DependencyInjection;
using Notifaction.DAL.contract;
using Notifaction.DAL.contract.Base;
using Notifaction.DAL.implemntation;
using Notifaction.DAL.implemntation.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.DAL.SartUp
{
    public sealed class InjectDal
    {
        public static void StartUp(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
        }
    }
}
