using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingLeagueCalculator
{
    public class GameMatch(Team teamA, int scoreA, Team teamB, int scoreB): Model
    {
        public Team TeamA { get; set; } = teamA;

        public Team TeamB { get; set; } = teamB;

        public int ScoreA { get; set; } = scoreA;

        public int ScoreB { get; set; } = scoreB;

    }
}
