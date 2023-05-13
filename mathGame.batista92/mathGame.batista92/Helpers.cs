using mathGame.batista92.Models;
using System.Security;

namespace mathGame.batista92;

internal class Helpers
{
    internal static List<Game> games = new();
    internal static void PrintGames()
    {
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("-------------------------------------------");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts");
        }
        Console.WriteLine("-------------------------------------------\n");
        Console.WriteLine("Press anu key to return to Main Menu");
        Console.ReadLine();
    }

    internal static void AddToHistory(int gameScore, GameType gameType)
    {
        games.Add(new Game 
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType
        });
    }

    internal static string? ValidadeResult(string result)
    {
        while(string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an interger. Try again.");
            result = Console.ReadLine();
        }
        return result;
    }

    internal static string GetName()
    {
        Console.Clear();
        Console.WriteLine("Please type your name");
        string name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty.");
            name = Console.ReadLine();
        }
        return name;
    }

    internal static int[] GetDivisionNumbers()
    {
        Random random = new Random();
        int firstNumber = random.Next(1, 99);
        int secondNumber = random.Next(1, 99);

        int[] result = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 99);
            secondNumber = random.Next(1, 99);
        }

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }
}
