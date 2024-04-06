using MathGame.BBualdo;
using MathGame.BBualdo.Models;

GameEngine gameEngine = new GameEngine();

do
{
  gameEngine.CurrentGame = new Game();
  Console.Clear();
  GameConsole.ShowTitle();
  gameEngine.SelectMode();
  if (gameEngine.CurrentGame.IsGameOn)
  {
    gameEngine.SelectDifficulty();
    gameEngine.SelectNumberOfQuestions();
    gameEngine.CurrentGame.Run(gameEngine.MaxValue);
    gameEngine.GamesHistory.GamesList.Add(gameEngine.CurrentGame);
  }
} while (!gameEngine.CurrentGame.IsGameOn);