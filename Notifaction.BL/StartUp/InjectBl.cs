using Microsoft.Extensions.DependencyInjection;
using Notifaction.BL.Contract;
using Notifaction.BL.Contract.Base;
using Notifaction.BL.Implementation;
using Notifaction.BL.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.BL.StartUp
{
    public sealed class InjectBl
    {
        public static void StartUp(IServiceCollection services)
        {
            services.AddTransient<IPatientService, patientService>();
        }
    }
}
