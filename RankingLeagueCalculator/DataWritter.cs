using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingLeagueCalculator
{
    public abstract class DataWritter
    {
        public abstract void Write(List<Team> items);
    }
}
