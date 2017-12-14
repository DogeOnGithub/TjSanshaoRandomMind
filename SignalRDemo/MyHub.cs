using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRDemo
{
    [HubName("TjSanshaoHub")]
    public class MyHub : Hub
    {
        public void Hello(string msg)
        {
            Clients.All.hello(msg);
        }
    }
}