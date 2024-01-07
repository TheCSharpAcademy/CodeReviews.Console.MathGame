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

    internal static void PrintHistory()
    {
        Console.Clear();
        Console.WriteLine("Session History");
        Console.WriteLine("---------------");
        foreach (Game game in gameHistory)
        {
            Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} points");
        }
        Console.WriteLine("\nPress any key to return to main menu");
        Console.ReadLine();
    }

    internal static void AddToHistory(int score, string gameType)
    {
        gameHistory.Add(new Game
        {
            Date = DateTime.Now,
            Score = score,
            Type = gameType,
        });
    }

    internal static int ProcessDifficulty()
    {
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
        return int.Parse(input);
        
        /*
        switch (input)
        {
            case "1":
                break;
            case "2":
                break;
            case "3":
                break;
            case "4":
                break;
            default:
                break;

        }
        */
    }
}
