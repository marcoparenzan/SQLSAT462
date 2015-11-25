using System;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AnalyticsGames.Web
{
    public class PlayerHub : Hub
    {
        public static IHubContext Default
        {
            get
            {
                return 
                    Microsoft.AspNet.SignalR
                    .GlobalHost
                    .ConnectionManager
                    .GetHubContext<PlayerHub>();
            }
        }
    }
}