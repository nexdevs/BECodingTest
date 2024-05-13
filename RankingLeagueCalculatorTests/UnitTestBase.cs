using RankingLeagueCalculator;

namespace RankingLeagueCalculatorTests
{
    [TestClass]
    public class UnitTestBase
    {
        [TestMethod]
        public void TestApplicationGameTie()
        {
            Game game = new(1, 3, 0);

            Team a = new("a");
            Team b = new("b");
            game.Matches.Add(new GameMatch(a, 0, b, 0));
            game.Evaluate();

            Assert.AreEqual(1, game.Matches.Count);
            Assert.AreEqual(1, a.Score);
            Assert.AreEqual(1, b.Score);
        }

        [TestMethod]
        public void TestApplicationGameWin()
        {
            Game game = new(1, 3, 0);

            Team a = new("a");
            Team b = new("b");
            game.Matches.Add(new GameMatch(a, 1, b, 0));
            game.Evaluate();

            Assert.AreEqual(1, game.Matches.Count);
            Assert.AreEqual(3, a.Score);
            Assert.AreEqual(0, b.Score);
        }

        [TestMethod]
        public void TestApplicationGameLoss()
        {
            Game game = new(1, 3, 0);

            Team a = new("a");
            Team b = new("b");
            game.Matches.Add(new GameMatch(a, 0, b, 2));
            game.Evaluate();

            Assert.AreEqual(1, game.Matches.Count);
            Assert.AreEqual(0, a.Score);
            Assert.AreEqual(3, b.Score);
        }

        [TestMethod]
        public void TestApplicationBuilderReader()
        {
            ApplicationBuilder builder = new();
            DataReader dataReader = builder.BuildReader("Stdin");
            Assert.IsInstanceOfType<StdinReader>(dataReader);
        }

        [TestMethod]
        public void TestApplicationBuilderWritter()
        {
            ApplicationBuilder builder = new();
            DataWritter dataWritter = builder.BuildWritter("Stdout");
            Assert.IsInstanceOfType<StdoutWritter>(dataWritter);
        }
    }
}