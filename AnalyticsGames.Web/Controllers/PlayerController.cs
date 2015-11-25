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
    public class PlayerController : ApiController
    {
        [HttpPost]
        public void Run(string id)
        {
        }

        [HttpPost]
        public void Start(string id)
        {
            PlayerHub.Default.Clients.All.goto_run();
        }

        [HttpPost]
        public void Left(string id)
        {
            Send(id, "left");
        }

        private void Send(string id, string command)
        {
            var client = EventHubClient.CreateFromConnectionString(ConfigurationManager.AppSettings["PlayerRun"], "PlayerRun");
            var json = JsonConvert.SerializeObject(new { gameId = id, command = command });
            var bytes = Encoding.UTF8.GetBytes(json);
            var data = new EventData(bytes);

            client.Send(data);
        }

        [HttpPost]
        public void Right(string id)
        {
            Send(id, "right");
        }
    }
}
