using Maths_Game.Models;

namespace Maths_Game;

internal class Helpers
{
    static List<Game> games = new();

    internal static (int, int) GetDivisionNumbers()
    {
        Random random = new();
        int firstNumber;
        int secondNumber;

        do
        {
            firstNumber = random.Next(0, 99);
            secondNumber = random.Next(1, 99);
        }
        while (firstNumber % secondNumber != 0);

        return (firstNumber, secondNumber);
    }

    internal static void DisplayPreviousGames()
    {
        Console.WriteLine("GAME HISTORY");
        foreach (Game game in games)
        {
            Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}/5");
        }
        Console.WriteLine("\nPress any key to continue.");
        Console.ReadKey();
    }

    internal static void AddToHistory(GameType gameType, int score)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = score,
            Type = gameType
        });
    }

    internal static string GetName()
    {
        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine().ToUpper().Trim();

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name can't be empty");
            name = Console.ReadLine();
        }
        return name;
    }
}
