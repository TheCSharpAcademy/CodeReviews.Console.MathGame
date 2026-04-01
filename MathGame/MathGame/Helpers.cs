namespace MathGame;
using MathGame.Models;

internal class Helpers
{
    internal static List<Score> scores = new();
    
    internal static string GetName()
    {
        Console.WriteLine("Please enter a name for the game");
        string? name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Please enter a name for the game");
            name = Console.ReadLine();
        }
        
        return name;
    }

    internal static void AddToScores(int gameScore, GameType type)
    {
        scores.Add(new Score {Date = DateTime.Now, Type = type, Points = gameScore});
    }

    internal static void PrintScores()
    {
        foreach (var score in scores)
        {
            Console.WriteLine($"{score.Date} - {score.Type}, {score.Points}");
        }
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    internal static int[] GetDivisionNumbers()
    {
        int[] divisionNumbers = new int[2];
        Random random = new();
        divisionNumbers[0] = random.Next(1, 99);
        divisionNumbers[1] = random.Next(1, 99);

        while (divisionNumbers[0] % divisionNumbers[1] != 0)
        {
            divisionNumbers[0] = random.Next(1, 99);
            divisionNumbers[1] = random.Next(1, 99);
        }
        
        return divisionNumbers;
        
    }
}