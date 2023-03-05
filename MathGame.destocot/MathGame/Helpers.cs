using MathGame.Models;
using System.Diagnostics;

namespace MathGame
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>();

        internal static int DisplayProblems(int score, int num1, int num2, string operatorSymbol, Func<int, int, int> operation)
        {
            var question = $"{num1} {operatorSymbol} {num2} = ";

            Console.Write(question);

            var ans = Console.ReadLine();
            ans = Validations.ValidateAns(ans, question);

            if (int.Parse(ans) == operation(num1, num2))
            {
                Console.WriteLine("Correct!\n");
                score++;
            }
            else
                Console.WriteLine("Incorrect!\n");
            return score;
        }

        internal static void StartGame(string message)
        {
            Console.Clear();
            Console.WriteLine("Press [enter] to begin..");
            Console.ReadLine();
            GameEngine.stopWatch.Start();
            Console.WriteLine(message);
            Console.WriteLine("-------------------------");
        }

        internal static void GameResults(string message, string diffLevel, string numOfQuestions, int score)
        {
            GameEngine.stopWatch.Stop();
            AddToHistory(message, diffLevel, numOfQuestions, score, GameEngine.stopWatch.ElapsedMilliseconds / 1000);
            GameEngine.stopWatch.Reset();

            Console.WriteLine($"Your final score is {score}");
            Console.WriteLine("Press [enter] to return to Main Menu..");
            Console.ReadLine();
        }

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine($"Game History");
            Console.WriteLine("--------------------------------------------------");

            foreach (var game in games)
                Console.WriteLine($"{game.Type.PadRight(19)} | {game.Difficulty.PadRight(6)} | {game.Questions} Q(s) - {game.Score}pts [{game.Time}s]");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Press [enter] to return to Main Menu..");
            Console.ReadLine();
        }

        internal static void AddToHistory(string gameType, string gameDifficulty, string numOfQuestions, int score, long time)
        {
            games.Add(new Game
            {
                Type = gameType,
                Difficulty = gameDifficulty,
                Questions = numOfQuestions,
                Score = score,
                Time = time
            });
        }

        internal static int[] GetDivisionNumbers(int adjustment)
        {
            Random random = new Random();
            var num1 = random.Next(0, 100 + adjustment);
            var num2 = random.Next(1, 100 + adjustment);

            int[] result = new int[2];

            while (num1 % num2 != 0)
            {
                num1 = random.Next(0, 100 + adjustment);
                num2 = random.Next(1, 100 + adjustment);
            }

            result[0] = num1;
            result[1] = num2;

            return result;
        }

        internal static void DisplayQuestionsPrompt()
        {
            Console.Clear();
            Console.WriteLine("Select number of questions:\t[1]\t[2]\t[3]");
            Console.WriteLine("-------------------------");
            Console.Write(".. ");
        }

        internal static void DisplayDifficulties()
        {
            Console.Clear();
            Console.WriteLine("Select a difficulty:");
            Console.WriteLine("1 - Easy\t2 - Medium\t3 - Hard");
            Console.WriteLine("-------------------------");
            Console.Write(".. ");
        }

        internal static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Select a game mode:");
            Console.WriteLine(@"0 - History
1 - Addition
2 - Subtraction
3 - Multiplication
4 - Division
5 - Random
6 - Quit Program");
            Console.WriteLine("-------------------------");
            Console.Write(".. ");
        }
    }
}
