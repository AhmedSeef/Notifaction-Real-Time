using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using Notifaction.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notifaction.API.SignalrHubs
{
    public class TestSignalRHub : Microsoft.AspNet.SignalR.Hub
    {
        // required to let the Hub to be called from other server-side classes/controllers, using static methods
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<TestSignalRHub>();

        // Send the data to all clients (may be called from client JS - hub.client.broadcastCommonData)
        public void BroadcastCommonData(CommonData data)
        {
            Clients.All.BroadcastCommonData(data);
        }

        // Send the data to all clients (may be called from server C#)
        // In this example, called by TestController on data update (see the Post method)
        public static void BroadcastCommonDataStatic(CommonData data)
        {
            hubContext.Clients.All.BroadcastCommonData(data);
        }
    }
}
