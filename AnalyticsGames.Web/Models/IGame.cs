using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsGames.Web.Models
{
    public interface IGame
    {
        void PlayerStat(PlayerStat stat);
        void GoToRun();
    }
}
