using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using Microsoft.AspNet.SignalR;

namespace SalonDB.Web.Hubs
{
    public class ProgressHub : Hub
    {
        public void SendProgress()
        {
            var Message = "RefreshData";

            Clients.All.sendMessage(Message);
        }
    }
}