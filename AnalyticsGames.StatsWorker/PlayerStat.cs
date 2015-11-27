using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsGames.StatsWorker
{
    public class PlayerStat
    {
        public Guid GameId { get; set; }
        public int Count { get; set; }
        public DateTimeOffset Created { get; set; }

        // https://azure.microsoft.com/en-us/documentation/articles/websites-dotnet-webjobs-sdk-service-bus/
        public static void Handle([ServiceBusTrigger("playerstats")] string json)
        {
            var client = new HttpClient();
            //var json = JsonConvert.SerializeObject(playerStat);
            var content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/json");
            client.PostAsync($"{ConfigurationManager.AppSettings["notificationUrl"]}player", content).Wait();
        }
    }
}
