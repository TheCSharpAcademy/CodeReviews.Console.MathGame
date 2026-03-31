namespace MathGame;
using MathGame.Models;

internal class Helpers
{
    internal static List<Score> scores = new();
    
    internal static string GetName()
    {
        Console.WriteLine("Please enter a name for the game");
        return Console.ReadLine();
    }

    internal static void AddToScores(Score score)
    {
        scores.Add(score);
    }

    internal static void PrintScores()
    {
        foreach (var score in scores)
        {
            Console.WriteLine($"{score.Date} - {score.Type}, {score.Points}");
        }
    }
}