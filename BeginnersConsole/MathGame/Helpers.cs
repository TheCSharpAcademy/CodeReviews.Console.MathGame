using MathGame.Models;

namespace MathGame;

internal class Helpers
{
    internal static List<Game> games = new();

    internal static void PrintGames()
    {
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("--------------------");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.Date} - {game.Type} ({game.Difficulty}): {game.Score}pts - Time taken: {game.TimeTaken.Minutes}m {game.TimeTaken.Seconds}s");
        }
        Console.WriteLine("---------------------\n");
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
    }

    internal static void GetGames()
    {
        Console.Clear();
        Console.WriteLine("Games Historsy");
        Console.WriteLine("---------------------------------");
        foreach (var game in games)
        {
            Console.WriteLine(game);
        }
        Console.WriteLine("----------------------------------\n");
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
    }

    internal static void AddToHistory(byte gameScore, GameType gameType, TimeSpan timeTaken, DifficultyLevel difficulty)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType,
            TimeTaken = timeTaken,
            Difficulty = difficulty
        });
    }

    internal static int[] GetDivisionNumbers(int min, int max)
    {
        Random rnd = new Random();

        int secondN = rnd.Next(min, max + 1);
        int multiplier = rnd.Next(2, 10);
        int firstN = secondN * multiplier;

        return new int[2] { firstN, secondN };
    }

    internal static string? ValidateResult(string res)
    {
        while (string.IsNullOrEmpty(res) || !Int32.TryParse(res, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again.");
            res = Console.ReadLine();
        }
        return res;
    }

    internal static string GetName()
    {
        Console.Write("Your name: ");
        string name = Console.ReadLine();
        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty");
            name = Console.ReadLine();
        }
        return name;
    }

    internal static bool IsValidInput(string input, params string[] validOptions)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;
        return validOptions.Contains(input.Trim().ToLower());
    }
}