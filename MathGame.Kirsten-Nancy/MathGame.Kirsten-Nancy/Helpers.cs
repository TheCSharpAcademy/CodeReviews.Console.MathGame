using MathGame.Models;

namespace MathGame;
internal class Helpers
{
    internal static List<Game> games = new List<Game> { };

    internal static void ShowHistory()
    {
        Console.Clear();

        if (games.Count == 0)
        {
            Console.WriteLine("No history, please play a game first.");
            Console.WriteLine("=====================================");
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadLine();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Game History");
            Console.WriteLine("=====================================");

            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts");
            }

            Console.WriteLine("=====================================");
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadLine();
        }
    }

    internal static void AddToHistory(int gameScore, GameType gameType)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Type = gameType,
            Score = gameScore
        });
    }

    internal static string GetName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name cannot be empty. Please try again.");
            GetName();
        }
        else
        {
            Console.WriteLine($"Welcome {name} to the Math Game!");
        }
        return name;
    }
}
