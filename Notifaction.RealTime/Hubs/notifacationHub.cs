using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notifaction.RealTime.Hubs
{
    public class notifacationHub : Hub
    {
        public async Task NewMessage(string msg)
        {
            await Clients.All.SendAsync("MessageReceived", msg);
        }
    }
}
