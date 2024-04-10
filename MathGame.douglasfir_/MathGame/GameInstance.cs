using MathGame.Models;

namespace MathGame;

internal class GameInstance
{
    GameEngine gameEngine = new();
    Helpers util = new();
    internal static List<MiniGame> gameHistory = new List<MiniGame>();
    internal void Run()
    {
        string userInput;
        MiniGame gameResult;

        while (true)
        {
            Console.Clear();
            Menu.PrintMainMenu();
            userInput = util.ReadMainMenuInput();
            string key = userInput.Trim().ToLower();

            switch (key)
            {
                case "a":
                    gameResult = gameEngine.RunFixedLengthMode(QuestionType.Addition);
                    AddGameToHistory(gameResult);
                    break;
                case "s":
                    gameResult = gameEngine.RunFixedLengthMode(QuestionType.Subtraction);
                    AddGameToHistory(gameResult);
                    break;
                case "m":
                    gameResult = gameEngine.RunFixedLengthMode(QuestionType.Multiplication);
                    AddGameToHistory(gameResult);
                    break;
                case "d":
                    gameResult = gameEngine.RunFixedLengthMode(QuestionType.Division);
                    AddGameToHistory(gameResult);
                    break;
                case "e":
                    gameResult = gameEngine.RunEndlessMode();
                    AddGameToHistory(gameResult);
                    break;
                case "v":
                    Menu.PrintGameHistoryMenu(gameHistory);
                    break;
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine($"Press any key to reselect an option....");
                    Console.ReadKey();
                    break;
            }
        }
    }
    internal void AddGameToHistory(MiniGame game)
    {
        gameHistory.Add(game);
    }
}
