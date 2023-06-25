namespace ConsoleMathsGame
{
    using Models;
    using System.Linq;

    internal class Helpers
    {
        const string lineBreaker = "--------------------------------------------------------";

        internal readonly static List<Game> games = new List<Game>();

        private static readonly Random random = new Random();

        internal static int[] GetDivisionNumbers(GameDifficulty difficulty)
        {
            var result = new int[2];

            int firstNumber = random.Next(1, 99) * GetRandomInt(difficulty);
            int secondNumber = random.Next(1, 99) * GetRandomInt(difficulty);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99) * GetRandomInt(difficulty);
                secondNumber = random.Next(1, 99) * GetRandomInt(difficulty);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static void HoldForEnter()
        {
            Console.Write(" Press enter to continue.");
            Console.ReadLine();
        }

        internal static void PrintGames()
        {
            // var gamesToPrint = games.Where(x => x.Date > new DateTime(2022, 11, 10) && x.Score > 3).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Game History");
            Console.WriteLine(lineBreaker);
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Difficulty} {game.Type}: Score={game.Score} pts");
            }
            Console.WriteLine(lineBreaker);

            PauseToMenu();
        }

        internal static void AddToHistory(int score, GameType gameType, GameDifficulty difficulty)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = score,
                Type = gameType,
                Difficulty = difficulty
            });
        }

        internal static void PauseToMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
        }

        internal static int GetUserAnswer()
        {
            string? answer;
            int result;

            answer = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(answer) || !int.TryParse(answer, out result))
            {
                Console.WriteLine("The given answer must be an int.");
                answer = Console.ReadLine();
            };

            return result;
        }

        internal static bool CheckAnswer(int userAnswer, int expectedAnswer)
        {

            if (userAnswer == expectedAnswer)
            {
                Console.WriteLine("Correct! Well done!");
                return true;
            }


            Console.WriteLine($"Incorrect, the answer was {expectedAnswer}");
            return false;
        }

        internal static string GetName()
        {
            string? name;

            do
            {
                Console.WriteLine("Please type your name");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

        internal static int GetRandomInt(GameDifficulty difficulty)
        {
            switch (difficulty)
            {
                case GameDifficulty.Beginner:
                    return random.Next(1, 9);

                case GameDifficulty.Intermediate:
                    return random.Next(5, 25);

                case GameDifficulty.Master:
                    return random.Next(20, 150);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
