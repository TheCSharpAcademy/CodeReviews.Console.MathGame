using MathGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame;
internal class Helpers
{
    internal static List<Game> games = new List<Game> { };
    //{
    //    new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
    //    new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Subtraction, Score = 5 },
    //    new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Multiplication, Score = 4 },
    //    new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Division, Score = 3 },
    //    new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
    //    new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Subtraction, Score = 2 },
    //    new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Multiplication, Score = 3 },
    //    new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Division, Score = 4 },
    //    new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
    //    new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Subtraction, Score = 1 },
    //    new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Multiplication, Score = 0 },
    //    new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
    //    new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Addition, Score = 5 },
    //};

    internal static void ShowHistory()
    {
        Console.Clear();

        if (games.Count == 0)
        {
            Console.WriteLine("No history, please play a game first.");
            Console.WriteLine("=====================================");
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadLine();
        }
        else
        {
            //var gamesToDisplay = games.Where(x => x.Type == GameType.Multiplication);
            // Search menu, to filter games by certain criteria
            //var gamesToDisplay = games.Where(x => x.Date > new DateTime(2025, 05, 31)).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Game History");
            Console.WriteLine("=====================================");

            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts");
            }

            Console.WriteLine("=====================================");
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadLine();
        }
    }

    internal static void AddToHistory(int gameScore, GameType gameType)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Type = gameType,
            Score = gameScore
        });
    }

    internal static string GetName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name cannot be empty. Please try again.");
            GetName();
        }
        else
        {
            Console.WriteLine($"Welcome {name} to the Math Game!");
        }
        return name;
    }
}
