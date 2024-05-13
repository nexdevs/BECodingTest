using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingLeagueCalculator
{
    public abstract class DataReader
    {
        public abstract string[]? Read();

        public abstract List<string[]> ReadUntilEmptyLine();
    }
}
