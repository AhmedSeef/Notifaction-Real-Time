using Notifaction.RealTime.DTOs;
using Notifaction.RealTime.Hubs;
using Notifaction.RealTime.services.contract;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System.Threading;
using Notifaction.RealTime.Models;

namespace Notifaction.RealTime.services.implementation
{
    public class DashboardHostedService : IHostedService, IDashboardHostedService
    {

        IHubContext<notifacationHub> _hubContext;
        public DashboardHostedService(IHubContext<notifacationHub> hubContext)
        {
            _hubContext = hubContext;
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

        public void GetMs(Message me)
        {
            _hubContext.Clients.All.SendAsync("sendAllme", me);
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
