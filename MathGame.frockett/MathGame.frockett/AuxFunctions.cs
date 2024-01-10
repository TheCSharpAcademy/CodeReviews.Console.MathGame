using MathGame.frockett.Models;

namespace MathGame.frockett;

internal class AuxFunctions
{
    static List<Game> gameHistory = new();

    internal static void PrintHistory()
    {
        Console.Clear();
        Console.WriteLine("Session History");
        Console.WriteLine("---------------");
        foreach (Game game in gameHistory)
        {
            Console.WriteLine($"{game.Date} - {game.Type} - {game.Difficulty}: {game.Score} points in {game.Time:F2} seconds");
        }
        Console.WriteLine("\nPress any key to return to main menu");
        Console.ReadLine();
    }

    internal static void AddToHistory(int score, string gameType, Difficulty difficulty, double time)
    {
        gameHistory.Add(new Game
        {
            Date = DateTime.Now,
            Score = score,
            Type = gameType,
            Difficulty = difficulty,
            Time = time,
        });
    }

    internal static Level ProcessDifficulty()
    {
        Level level = new Level();
        string? input;

        Console.WriteLine("\nSelect Difficulty:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");
        Console.WriteLine("4. Insane\n");
        
        input = Console.ReadLine();

        // This while loop condition is really ugly, is there a better way to validate the input?
        while(string.IsNullOrEmpty(input) || !int.TryParse(input, out _) || int.Parse(input) > 4 || int.Parse(input) < 1)
        {
            Console.WriteLine("Please input a valid numbered choice");
            input = Console.ReadLine();
        }
        
        // Switch statement matches the selection with the level struct
        switch (input)
        {
            case "1":
                level.Maximum = 10;
                level.Difficulty = Difficulty.Easy;
                return level;
            case "2":
                level.Maximum = 25;
                level.Difficulty = Difficulty.Medium;
                return level;
            case "3":
                level.Maximum = 100;
                level.Difficulty = Difficulty.Hard;
                return level;
            case "4":
                level.Maximum = 1000;
                level.Difficulty = Difficulty.Insane;
                return level;
            default:
                Console.WriteLine("You must input a number between 1 and 4");
                throw new ArgumentException("Invalid input");

        }
        
    }
}
