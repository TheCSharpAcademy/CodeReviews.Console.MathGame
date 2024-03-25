using MyFirstProject.Models;
using static MyFirstProject.Models.Game;

namespace MyFirstProject;
     internal class Helpers
    {
        internal static List<Game> games = new() {
        //new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
        //new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4 },
        //new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4 },
        //new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3 },
        //new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
        //new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2 },
        //new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3 },
        //new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4 },
        //new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
        //new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1 },
        //new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0 },
        //new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
        //new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5 },
        };
        internal static void AddToHistory(int gameScore, GameType gameType, GameDifficulty gameDifficulty, int playTimeInSeconds, int numberOfQuestions)
        {
            games.Add( new Game{ Date = DateTime.Now, Score = gameScore, Type = gameType, Difficulty = gameDifficulty, PlayTime = playTimeInSeconds, Questions = numberOfQuestions } );
        }
        internal static void PrintGames()
        {
            var gamesToPrint = games.Where(x => x.Date > new DateTime(2022, 08, 09)).OrderByDescending(x => x.Score);
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---------------------------");
            foreach (var game in gamesToPrint)
            {
                Console.WriteLine($"{game.Date} - {game.Type} - Level: {game.Difficulty} - {game.Score}pts - Time:{game.PlayTime}s - Number of Questions:{game.Questions}");
            }
            Console.WriteLine("---------------------------\n");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
        }
        internal static int[] GetDivisionNumbers(int difficultyUpperBound)
        {
            int divisionUpperBound = difficultyUpperBound * 11;
            var random = new Random();
            var firstNumber = random.Next(1, divisionUpperBound);
            var secondNumber = random.Next(1, divisionUpperBound);

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, divisionUpperBound);
                secondNumber = random.Next(1, divisionUpperBound);
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
        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }

            return name;
        }
        internal static GameDifficulty GetDifficulty(out int difficultyUpperBound)
        {
            Console.WriteLine("Choose difficulty: Easy/Medium/Hard");  
            Console.WriteLine("If no difficulty mode is chosen, then the default mode is Easy");

            string userChoice = Console.ReadLine();
            GameDifficulty difficulty = GameDifficulty.Easy;

            userChoice = userChoice.Trim().ToLower();

            switch (userChoice)
            {
                case "easy":
                    difficulty = GameDifficulty.Easy;
                    difficultyUpperBound = 9;
                    break;
                case "medium":
                    difficulty = GameDifficulty.Medium;
                    difficultyUpperBound = 99;
                    break;
                case"hard":
                    difficulty = GameDifficulty.Hard;
                    difficultyUpperBound = 999;
                    break;
                default:
                    difficulty = GameDifficulty.Easy;
                    difficultyUpperBound = 9;
                    break;
            }

            return difficulty;
        }
        internal static int GetNumbersOfQuestions()
        {
            Console.WriteLine("Choose how many questions to answer");

            string userInput = Console.ReadLine();
            int numberOfQuestions = 0;
            while (!int.TryParse(userInput, out numberOfQuestions) || numberOfQuestions <= 0)
            {
                Console.WriteLine("Enter a integer number greater than 0");
                userInput = Console.ReadLine();
            }

            return numberOfQuestions;
        }
     }

