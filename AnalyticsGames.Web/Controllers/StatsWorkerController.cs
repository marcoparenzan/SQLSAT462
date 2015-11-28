using AnalyticsGames.Web.Models;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace AnalyticsGames.Web.Controllers
{
    public class StatsWorkerController : ApiController
    {
        [HttpPost]
        public void Player(PlayerStat stat)
        {
            PlayerHub.PlayerStat(stat);
        }
    }
}
