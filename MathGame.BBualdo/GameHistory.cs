using MathGame.BBualdo.Models;

namespace MathGame.BBualdo;

internal class GameHistory
{
  public List<Game> GamesList { get; set; } = new List<Game>();

  public void GetGamesHistory()
  {
    Console.Clear();
    GameConsole.ShowTitle();

    GameConsole.ShowMessage(@"Games History
--------------------");
    if (GamesList.Count == 0)
    {
      GameConsole.ShowMessage("There are no games played yet.");
      GameConsole.ShowMessage("Please press any key to get back to main menu.");
      Console.ReadKey();
      return;
    }

    foreach (Game game in GamesList)
    {
      GameConsole.ShowMessage($"{nameof(Game.Date)}: {DateTime.Parse(game.Date.ToString())} | {nameof(Game.Type)}: {game.Type} | {nameof(Game.DifficultyLevel)}: {game.DifficultyLevel} | {nameof(Game.Score)}: {game.Score}/{game.NumberOfQuestions} | {nameof(Game.TimeInSeconds)}: {game.TimeInSeconds}s");
    }

    GameConsole.ShowMessage("Please press any key to get back to main menu.");
    Console.ReadKey();
  }
}