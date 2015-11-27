using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsGames.Web.Models
{
    public class PlayerStat
    {
        public Guid GameId { get; set; }
        public int Count { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
