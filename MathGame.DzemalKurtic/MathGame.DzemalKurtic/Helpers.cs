using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame.DzemalKurtic
{
    internal class Helpers
    {
        internal static List<string> games = new List<string>();
        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Game History");
            Console.WriteLine("----------------");
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("----------------");
            Console.WriteLine("Press any key to go back to main menu.");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, string gameType)
        {
            games.Add($"{DateTime.Now} - {gameType}: {gameScore} pts");
        }

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(0, 99);
            var secondNumber = random.Next(0, 99);

            var result = new int[2];

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
