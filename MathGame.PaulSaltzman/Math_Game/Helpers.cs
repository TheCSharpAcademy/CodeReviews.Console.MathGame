using Math_Game.Models;
using System.Drawing;
using static Math_Game.Models.Game;

namespace Math_Game
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>
        {
            //new Game  { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5},
            //new Game  { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4},
            //new Game  { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 3},
            //new Game  { Date = DateTime.Now.AddDays(4), Type = GameType.Subtracton, Score = 1},
            //new Game  { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 2},
            //new Game  { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 3},
            //new Game  { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 4},
            //new Game  { Date = DateTime.Now.AddDays(8), Type = GameType.Subtracton, Score = 4},
            //new Game  { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 1},
            //new Game  { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 0},
            //new Game  { Date = DateTime.Now.AddDays(11), Type = GameType.Subtracton, Score = 2},
            //new Game  { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 5},
            //new Game  { Date = DateTime.Now.AddDays(13), Type = GameType.Subtracton, Score = 5}
        };

        internal static string GetName()
        {
            Console.WriteLine("Please type your name");

            var name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }
            return name;
        }
        internal static void PrintGames()
        {
            //var gamesToPrint = games.Where(x => x.Date > new DateTime(2023,08,09)).OrderByDescending(x => x.Score); //first time using code like this at least where I understand what's happening

            Console.Clear();
            Console.WriteLine("Games History");
            
            foreach (var game in games)
            {
                Console.WriteLine("-----------------------------");
                Console.Write($"{game.Date} - {game.Type}:"); ColorPicker(game.Level); 
                Console.WriteLine($@": {game.Score}pts");
                Console.WriteLine("-----------------------------\n");
            }
            Console.WriteLine("Type any key to return to the menu.");
            Console.ReadLine();
        }
        internal static void AddToHistory(int gameScore, GameType gameType, DifficultyLevel difficulty)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Level = difficulty
            });
        }

        internal static int[] GetDivisionNumbers(DifficultyLevel difficulty)
        {
            var random = new Random();
            var firstNumber = random.Next(0, 99);
            var secondNumber = random.Next(1, 99); //can't divide by zero

            var result = new int[2];
            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(0, 30);
                        secondNumber = random.Next(1, 20); //1 because you can't divide by zero
                    }
                    break;
                case DifficultyLevel.Medium:
                    while (firstNumber % secondNumber != 0)
                    {
                    firstNumber = random.Next(50, 150);
                    secondNumber = random.Next(1, 99); //1 because you can't divide by zero
                    }
                    break;
                case DifficultyLevel.Hard:
                    while (firstNumber % secondNumber != 0)
                    {
                        firstNumber = random.Next(100, 200);
                        secondNumber = random.Next(1, 200); //1 because you can't divide by zero
                    }
                    break;
            }
            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine();
            }
            return result;  
        }

        internal static DifficultyLevel SetLevel(DifficultyLevel levelSelected)
        {
            var menuRuning = true;
            do
            {
                Console.Clear();
                Console.WriteLine("___________________________________________________________");
                Console.Write($@"The Current difficulty level: ");
                ColorPicker(levelSelected);
                Console.WriteLine($@"Select a difficulty:
E - Easy
M - Medium
H - Hard
R - Return to Main Menu");
                Console.WriteLine("___________________________________________________________");

                var difficultySelected = Console.ReadLine();

                switch (difficultySelected.Trim().ToLower())
                {
                    case "e":
                        levelSelected = DifficultyLevel.Easy;
                        Console.WriteLine("Easy");
                        break;
                    case "m":
                        levelSelected = DifficultyLevel.Medium;
                        Console.WriteLine("Medium");
                        break;
                    case "h":
                        levelSelected = DifficultyLevel.Hard;
                        Console.WriteLine("Hard");
                        break;
                    case "r":
                        menuRuning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection"); //This doesn't actually show.
                        break;
                }
            }while (menuRuning == true);
            return levelSelected;
        }

        internal static void ColorPicker(DifficultyLevel difficultyLevel)
        {
            switch (difficultyLevel)
            {
                case DifficultyLevel.Easy:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case DifficultyLevel.Medium:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case DifficultyLevel.Hard:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine($@" {difficultyLevel}");
            Console.ResetColor();
        }
    }
}
