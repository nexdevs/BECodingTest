using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RankingLeagueCalculator
{
    public partial class StdinReader : DataReader
    {
        public const string PlainTextMatchRegexExpression = "(?<team_a>[a-zA-Z ]+) (?<score_a>[0-9]+), (?<team_b>[a-zA-Z ]+) (?<score_b>[0-9]+)";

        private Regex plainTextMAtchRegex;

        public StdinReader()
        {
            plainTextMAtchRegex = PlainTextMatchRegex();
        }

        public override string[]? Read()
        {
            string? line = Console.ReadLine();
            
            if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
                return null;

            Match match = plainTextMAtchRegex.Match(line);
            string[] items = new string[4];

            for (int i = 1; i < match.Groups.Count; i++)
            {
                items[i - 1] = match.Groups[i].Value;
            }

            return items;
        }

        public override List<string[]> ReadUntilEmptyLine()
        {
            List<string[]> lines = [];
            string[]? items = Read();

            while (items != null) 
            {
                lines.Add(items);
                items = Read();
            }

            return lines;
        }

        [GeneratedRegex(PlainTextMatchRegexExpression, RegexOptions.Compiled)]
        private static partial Regex PlainTextMatchRegex();
    }
}
