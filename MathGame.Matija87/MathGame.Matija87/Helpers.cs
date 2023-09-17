using MathGame.Matija87.Models;
using static MathGame.Matija87.Models.Game;

namespace MathGame.Matija87
{
    internal static class Helpers
    {
        internal static List<Game> games = new();
        internal static string GetName()
        {
            Console.Write("Enter your name: ");
            string? name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
                Console.WriteLine("Enter your name: ");
                name = Console.ReadLine();
            }
            return name;
        }

        internal static int[] GetDivisionNumbers(int min, int max)
        {
            Random random = new();
            int firstNumber = random.Next(min, max);
            int secondNumber = random.Next(min, max); 

            int[] result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(min, max);
                secondNumber = random.Next(min, max);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }
              
        internal static void GetGames()
        {
            Console.Clear();
            Console.WriteLine("Games History:");
            Console.WriteLine("---------------------------");
            
            foreach (Game game in games) 
            {
                Console.WriteLine($"{game.DateTime} - {game.Type}: {game.Difficulty}: {game.Time}s: {game.Score}/{game.NumberOfQuestions} pts");
            }

            Console.WriteLine("---------------------------");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void AddToHistory(int gameScore, int numberOfQuestions, GameType gameType, DifficultyLevel difficuly, double time)
        {
            games.Add(new Game
            {
                DateTime = DateTime.Now,
                Score = gameScore,
                NumberOfQuestions = numberOfQuestions,
                Type = gameType,
                Difficulty = difficuly,
                Time = time
            }) ;
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Answer needs to be an integer. Try again!");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static DifficultyLevel Difficulty()
        {
            Console.WriteLine("Choose difficulty: ");
            Console.WriteLine("Easy (E)\nMedium (M)\nHard(H)");

            char difficultyChoice;
                        
            difficultyChoice = Console.ReadKey().KeyChar;
            difficultyChoice = Char.ToLower(difficultyChoice);

            while (true)
            {
                switch (difficultyChoice) 
                {
                    case 'e':
                        Console.WriteLine();
                        return DifficultyLevel.Easy;
                    case 'm':
                        Console.WriteLine();
                        return DifficultyLevel.Medium;
                    case 'h':
                        Console.WriteLine();
                        return DifficultyLevel.Hard;
                    default:
                        Console.WriteLine("\nWrong input! Try again!\n");
                        difficultyChoice = Console.ReadKey().KeyChar;
                        break;
                }
            };
            
        }

        internal static int NumberOfQuestions ()
        {
            Console.WriteLine("How many questions do you want:");
            string input = Console.ReadLine();

            while (string.IsNullOrEmpty(input) || !Int32.TryParse(input, out _) || Convert.ToInt32(input) < 1)
            {                
                Console.WriteLine("Answer needs to be positive integer. Try again!");
                input = Console.ReadLine();
            }
            return Convert.ToInt32(input);            
        }

    }
}