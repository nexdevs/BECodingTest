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

string? reader = appSettings.Get("Reader");
ArgumentException.ThrowIfNullOrEmpty(reader);

string? writer = appSettings.Get("Writter");
ArgumentException.ThrowIfNullOrEmpty(writer);

/*
 * Initialize application and dependencies and run
 */
ApplicationBuilder builder = new();

builder.Reader = builder.BuildReader(reader);
builder.Writter = builder.BuildWritter(writer);

Game game = new(Int32.Parse(gameTiePoints), Int32.Parse(gameWinPoints), Int32.Parse(gamelossPoints));

Application application = builder.Build(game);

application.Run();

/*
 * Exit application processes
 */

Environment.Exit(Environment.ExitCode);
