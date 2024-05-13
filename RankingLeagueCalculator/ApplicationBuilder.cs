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
        public DataReader Reader { get; set; }
        public DataWritter Writter { get; set; }

        public Application Build(Game game)
        {
            return new Application(game, Reader, Writter);
        }

        public DataReader BuildReader(string reader)
        {
            DataReader dataReader = reader switch
            {
                "Stdin" => new StdinReader(),
                _ => throw new NotImplementedException("Data reader {} not implemented!"),
            };

            return dataReader;
        }

        public DataWritter BuildWritter(string writter)
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

