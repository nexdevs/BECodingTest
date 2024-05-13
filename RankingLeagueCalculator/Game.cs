using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingLeagueCalculator
{
    public class Game
    {
        public int TiePoints { get; set;  }

        public int WinPoints { get; set; }

        public int LossPoints { get; set; }

        public List<Team> Teams { get; set; }

        public List<GameMatch> Matches { get; set; }

        public Game(int tiePoints, int winPoints, int lossPoints)
        {
            TiePoints = tiePoints;
            WinPoints = winPoints;
            LossPoints = lossPoints;
            Teams = [];
            Matches = [];
        }

        public void LoadMatches(List<string[]> matches)
        {
            for (int i = 0; i < matches.Count; i++) 
            { 
                string teamA = matches[i][0];
                string scoreA = matches[i][1];
                string teamB = matches[i][2];
                string scoreB = matches[i][3];

                if (!Teams.Exists(t => t.Name.Equals(teamA)))
                    Teams.Add(new Team(teamA));

                if (!Teams.Exists(t => t.Name.Equals(teamB)))
                    Teams.Add(new Team(teamB));

                Team a = Teams.Find(t => t.Name.Equals(teamA)) ?? throw new KeyNotFoundException();
                int sa = Int32.Parse(scoreA);

                Team b = Teams.Find(t => t.Name.Equals(teamB)) ?? throw new KeyNotFoundException();
                int sb = Int32.Parse(scoreB);

                GameMatch match = new(a, sa, b, sb);

                Matches.Add(match);
            }
        }

        public void Evaluate()
        {
            foreach (GameMatch match in Matches)
            {
                if(match.ScoreA > match.ScoreB)
                {
                    match.TeamA.Score += WinPoints;
                    match.TeamB.Score += LossPoints;
                }
                else if(match.ScoreB > match.ScoreA)
                {
                    match.TeamA.Score += LossPoints;
                    match.TeamB.Score += WinPoints;
                }
                else
                {
                    match.TeamA.Score += TiePoints;
                    match.TeamB.Score += TiePoints;
                }
            }
        }

        public void SortTeamPositions()
        {
            Teams.Sort(delegate (Team a, Team b)
            {
                return b.Score.CompareTo(a.Score);
            });
        }
    }
}
