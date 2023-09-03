using MathGame.AndreasGuy54.Models;

namespace MathGame.AndreasGuy54
{
    internal class Helpers
    {
        static List<Game> games = new List<Game>
        {
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
            //new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5 }
        };

        internal static void PrintGames()
        {
            //var gamesToPrint = games.Where(g => g.Date > new DateTime(2023, 09, 10))
            //                        .OrderByDescending(g => g.Score);

            Console.Clear();
            Console.WriteLine("Games History\n--------------------------------------------------------------");
            
            foreach (Game game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type} : {game.Score}pts");
            }

            Console.WriteLine("--------------------------------------------------------------\n");
            Console.WriteLine("Press any key to return to the Main Menu:");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }

        internal static string ValidateResult(string userAnswer)
        {
            while (string.IsNullOrEmpty(userAnswer) || !int.TryParse(userAnswer, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                userAnswer = Console.ReadLine();
            }

            return userAnswer;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            string name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty");
                name = Console.ReadLine();
            }

            return name;
        }

        internal static int[] GetDivisionNumbers()
        {
            Random random = new();
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
    }
}
