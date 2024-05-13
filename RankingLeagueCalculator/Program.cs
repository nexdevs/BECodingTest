// See https://aka.ms/new-console-template for more information
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection.Metadata;
using RankingLeagueCalculator;

/*
 * Read global appliaction settings
 */
NameValueCollection appSettings = ConfigurationManager.AppSettings;

string? gameTiePoints = appSettings.Get("GameTiePoints");
ArgumentException.ThrowIfNullOrEmpty(gameTiePoints);

string? gameWinPoints = appSettings.Get("GameWinPoints");
ArgumentException.ThrowIfNullOrEmpty(gameWinPoints);

string? gamelossPoints = appSettings.Get("GameLossPoints");
ArgumentException.ThrowIfNullOrEmpty(gamelossPoints);

string? readerString = appSettings.Get("Reader");
ArgumentException.ThrowIfNullOrEmpty(readerString);

string? writerString = appSettings.Get("Writter");
ArgumentException.ThrowIfNullOrEmpty(writerString);

/*
 * Initialize application and dependencies and run
 */

DataReader reader = ApplicationBuilder.BuildReader(readerString);
DataWritter writter = ApplicationBuilder.BuildWritter(writerString);

Game game = new(Int32.Parse(gameTiePoints), Int32.Parse(gameWinPoints), Int32.Parse(gamelossPoints));

Application application = ApplicationBuilder.Build(game, reader, writter);

application.Run();

/*
 * Exit application processes
 */

Environment.Exit(Environment.ExitCode);
