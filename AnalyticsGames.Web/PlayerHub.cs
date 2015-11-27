using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using AnalyticsGames.Web.Models;

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

        //private readonly static IHubContext<IGame> __context;
        //private readonly static SignalRConnectionMapping<Guid> __connections;

        //static PlayerHub()
        //{
        //    __context = GlobalHost.ConnectionManager.GetHubContext<IGame>("PlayerHub");
        //    __connections = new SignalRConnectionMapping<Guid>();
        //}

        //private static void Game(Guid gameId, Action<IGame> action)
        //{
        //    foreach (var connectionId in __connections.GetConnections(gameId))
        //    {
        //        action(__context.Clients.Client(connectionId));
        //    }
        //}

        //public static void PlayerStat(PlayerStat stat)
        //{
        //    Game(stat.GameId, _ => { _.PlayerStat(stat); });
        //}

        //public static void GoToRun(Guid gameId)
        //{
        //    Game(gameId, _ => { _.GoToRun(); });
        //}

        //public void RegisterGame(string gameId)
        //{
        //    __connections.Add(Guid.Parse(gameId), Context.ConnectionId);
        //}

        //public void UnregisterGame(string gameId)
        //{
        //    __connections.Remove(Guid.Parse(gameId), Context.ConnectionId);
        //}
    }
}