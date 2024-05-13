using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace RankingLeagueCalculator
{
    public class ApplicationBuilder : IApplicationBuilder
    {
        public static Application Build(Game game, DataReader reader, DataWritter writter)
        {
            return new Application(game, reader, writter);
        }

        public static DataReader BuildReader(string reader)
        {
            DataReader dataReader = reader switch
            {
                "Stdin" => new StdinReader(),
                _ => throw new NotImplementedException("Data reader {} not implemented!"),
            };

            return dataReader;
        }

        public static DataWritter BuildWritter(string writter)
        {
            DataWritter dataWritter = writter switch
            {
                "Stdout" => new StdoutWritter(),
                _ => throw new NotImplementedException("Data writter {} not implemented!"),
            };

            return dataWritter;
        }
    }
}

