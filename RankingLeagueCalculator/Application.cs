using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RankingLeagueCalculator
{
    public class Application(Game game, DataReader reader, DataWritter writter)
    {
        private readonly DataReader reader = reader;

        private readonly DataWritter writter = writter;
        
        private readonly Game game = game;

        public void Run() 
        {
            /*
             * Standard process for single console application with no options
             * Read if any, process data and output results
             */

            Read();
            Process();
            Write();
        }

        private void Read()
        {
            List<string[]> matches = reader.ReadUntilEmptyLine();
            game.LoadMatches(matches);
        }

        private void Process()
        {
            game.Evaluate();
        }

        private void Write()
        {
            game.SortTeamPositions();
            writter.Write(game.Teams);
        }
    }
}
