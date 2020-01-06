using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System.Threading;
using Notifaction.API.SignalR;

using System.IO;
using Notifaction.API.DTO;

namespace Notifaction.API
{
    public class DashboardHostedService : IHostedService, IDashboardHostedService
    {
        private Timer _timer;
        IHubContext<NotificationHub> _hubContext;

        public DashboardHostedService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //_timer = new Timer(DoWork, null, TimeSpan.Zero,
            //TimeSpan.FromSeconds(2));

            return Task.CompletedTask;
        }

        public void DoWork(Mess mess)
        {
            _hubContext.Clients.All.SendAsync("SendMessage",
                new
                {
                    val1 = mess.val1,
                    val2 = mess.val2,
                    val3 = mess.val3,
                    val4 = mess.val4
                });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
    }
}
