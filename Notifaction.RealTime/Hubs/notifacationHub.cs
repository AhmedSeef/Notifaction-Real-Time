using Microsoft.AspNetCore.SignalR;
using Notifaction.RealTime.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notifaction.RealTime.Hubs
{
    public class notifacationHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task NewMessage(Message msg)
        {
            await Clients.All.SendAsync("MessageReceived", msg);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
