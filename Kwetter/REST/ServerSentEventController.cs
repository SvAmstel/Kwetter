using Kwetter.Data.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using static Kwetter.REST.KwetterController;

namespace Kwetter.REST
{
    public class ServerSentEventController : Hub
    {
        // required to let the Hub to be called from other server-side classes/controllers, using static methods
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ServerSentEventController>();
 
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

