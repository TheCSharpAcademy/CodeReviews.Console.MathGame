using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathGame.frockett.Models;

namespace MathGame.frockett;

internal class AuxFunctions
{
    static List<Game> gameHistory = new();
    //Level difficultyLevel = new Level();

    internal static void PrintHistory()
    {
        Console.Clear();
        Console.WriteLine("Session History");
        Console.WriteLine("---------------");
        foreach (Game game in gameHistory)
        {
            Console.WriteLine($"{game.Date} - {game.Type} - {game.Difficulty}: {game.Score} points");
        }
        Console.WriteLine("\nPress any key to return to main menu");
        Console.ReadLine();
    }

    internal static void AddToHistory(int score, string gameType, Difficulty difficulty)
    {
        gameHistory.Add(new Game
        {
            Date = DateTime.Now,
            Score = score,
            Type = gameType,
            Difficulty = difficulty,
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

        while(string.IsNullOrEmpty(input) || !int.TryParse(input, out _) || int.Parse(input) > 4)
        {
            Console.WriteLine("Please input a valid numbered choice");
            input = Console.ReadLine();
        }
        
        switch (input)
        {
            case "1":
                level.maximum = 10;
                level.difficulty = Difficulty.Easy;
                return level;
            case "2":
                level.maximum = 25;
                level.difficulty = Difficulty.Medium;
                return level;
            case "3":
                level.maximum = 100;
                level.difficulty = Difficulty.Hard;
                return level;
            case "4":
                level.maximum = 1000;
                level.difficulty = Difficulty.Insane;
                return level;
            default:
                Console.WriteLine("You must input a number between 1 and 4");
                throw new ArgumentException("Invalid input");

        }
        
    }
}
