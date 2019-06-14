using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace thechauffeurteam.Hubs
{
    public class AlertHub : Hub
    {
        public void MyMethod()
        {

            Clients.Others.AlertMe();
        }

    }
}