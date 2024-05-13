using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingLeagueCalculator
{
    public class StdoutWritter : DataWritter
    {
        public override void Write(List<Team> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i].ToString());
            }
        }
    }
}
