using mathGame.batista92.Models;

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

    internal static void AddToHistory(int gameScore, string gameType)
    {
        games.Add(new Game 
        {
            Date = DateTime.Now,
            Type = gameType,
            Score = gameScore
        });
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
