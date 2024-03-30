using CSharpAcademy_MathsGame.Models;

namespace CSharpAcademy_MathsGame;

public class Helpers
{
    internal static List<Game> gameScores = new()
    { // List copied from YouTube to learn about LINQ (Language integrated query)
        // new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5},
        // new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4},
        // new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4},
        // new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3},
        // new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1},
        // new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2},
        // new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3},
        // new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4},
        // new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4},
        // new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1},
        // new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0},
        // new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2},
        // new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5},
    };
    
    internal static void ShowScores()
    {
        Console.Clear();
        Console.WriteLine("============================================================================================");
        foreach (var game in gameScores)
        {
            Console.WriteLine($"{game.Date} - {game.Type}: Score = {game.Score}");
        }
        Console.WriteLine("============================================================================================");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
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

    internal static void CaptureScore(int gameScore, GameType gameType)
    {
        gameScores.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType,
        });
    }
}