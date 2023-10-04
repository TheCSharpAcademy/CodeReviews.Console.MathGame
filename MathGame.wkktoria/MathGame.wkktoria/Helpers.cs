using MathGame.wkktoria.Models;

namespace MathGame.wkktoria;

internal static class Helpers
{
    private static readonly List<Game> PreviousGames = new();

    internal static string GetName()
    {
        Console.Write("Please type your name: ");
        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name cannot be empty.");
            name = Console.ReadLine();
        }

        return name;
    }

    internal static void PrintPreviousGames()
    {
        var gamesToPrint = PreviousGames.OrderByDescending(game => game.Score);

        Console.Clear();
        Console.WriteLine("Games history");
        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
        foreach (var game in gamesToPrint) Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} points");
        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadLine();
    }

    internal static void AddToHistory(int gameScore, GameType gameType)
    {
        PreviousGames.Add(new Game { Date = DateTime.Now, Score = gameScore, Type = gameType });
    }


    internal static int[] GetDivisionNumbers()
    {
        var random = new Random();

        var firstNumber = random.Next(1, 99);
        var secondNumber = random.Next(1, 99);

        var divisionNumbers = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(0, 99);
            secondNumber = random.Next(0, 99);
        }

        divisionNumbers[0] = firstNumber;
        divisionNumbers[1] = secondNumber;

        return divisionNumbers;
    }

    private static string ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !int.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again.");
            Console.Write("> ");
            result = Console.ReadLine();
        }

        return result;
    }

    internal static int GetResult()
    {
        Console.Write("> ");
        var result = Console.ReadLine();
        result = ValidateResult(result);

        return int.Parse(result);
    }
}