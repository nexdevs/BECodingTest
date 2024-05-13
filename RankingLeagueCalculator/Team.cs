using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingLeagueCalculator
{
    public class Team(string name): Model
    {
        public string Name { get; set; } = name;

        public int Score { get; set; } = 0;

        public override string ToString()
        {
            return Name + ", " + Score + (Score == 1 ? " pt" : " pts");
        }
    }
}
