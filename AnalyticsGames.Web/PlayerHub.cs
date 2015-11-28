using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using AnalyticsGames.Web.Models;
using Microsoft.AspNet.SignalR.Hubs;

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

        private static SignalRConnectionMapping<Guid> __connections = new SignalRConnectionMapping<Guid>();

        private static void Game(Guid gameId, Action<dynamic> action)
        {
            foreach (var connectionId in __connections.GetConnections(gameId))
            {
                action(Default.Clients.Client(connectionId));
            }
        }

        public static void PlayerStat(PlayerStat stat)
        {
            Game(stat.GameId, _ => { _.player_stat(stat); });
        }

        public static void GoToRun(string gameId)
        {
            Game(Guid.Parse(gameId), _ => { _.goto_run(); });
        }

        [HubMethodName("RegisterGame")]
        public void RegisterGame(string gameId)
        {
            __connections.Add(Guid.Parse(gameId), Context.ConnectionId);
        }

        [HubMethodName("UnregisterGame")]
        public void UnregisterGame(string gameId)
        {
            __connections.Remove(Guid.Parse(gameId), Context.ConnectionId);
        }
    }
}