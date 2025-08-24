using MyFirstProgram.Models;

namespace MyFirstProgram
{
    internal class Helpers
    {
        internal static List<Game> list = new List<Game>
        {
            // new Game {Date = DateTime.Now.AddDays(1),Type=GameType.Addition,Score=5},
            // new Game {Date = DateTime.Now.AddDays(2),Type=GameType.Subtraction,Score=2},
            // new Game {Date = DateTime.Now.AddDays(3),Type=GameType.Multiplication,Score=4},
            // new Game {Date = DateTime.Now.AddDays(4),Type=GameType.Division,Score=3},
            // new Game {Date = DateTime.Now.AddDays(5),Type=GameType.Multiplication,Score=5},
            // new Game {Date = DateTime.Now.AddDays(6),Type=GameType.Addition,Score=5},
            // new Game {Date = DateTime.Now.AddDays(7),Type=GameType.Division,Score=1},
            // new Game {Date = DateTime.Now.AddDays(8),Type=GameType.Subtraction,Score=1},
            // new Game {Date = DateTime.Now.AddDays(9),Type=GameType.Addition,Score=3},
            // new Game {Date = DateTime.Now.AddDays(10),Type=GameType.Multiplication,Score=3},
            // new Game {Date = DateTime.Now.AddDays(11),Type=GameType.Addition,Score=3},
            // new Game {Date = DateTime.Now.AddDays(12),Type=GameType.Division,Score=5},
            // new Game {Date = DateTime.Now.AddDays(13),Type=GameType.Subtraction,Score=5},
        };

        internal static void AddToHistory(int gameScore, GameType gameType, DifficultyLevel difficulty)
        {
            list.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Difficulty = difficulty,
            }
                    );
        }

        internal static void ViewGameResults()
        {
            Console.Clear();
            foreach (Game game in list)
            {
                Console.WriteLine($"{game.Date} - Difficulty: {game.Difficulty} - {game.Type}: {game.Score} points");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }


        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty. Please write your name:");
                name = Console.ReadLine();
            }
            return name;
        }
    }
}
