using System;
using System.Collections.Generic;
using AdityaVaidya.MathGame.Models;

namespace AdityaVaidya.MathGame
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>();
        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 99);
            var secondNumber = random.Next(1, 99);
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

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type} : {game.Score} pts");
            }
            Console.WriteLine("Press any key to go back to the main menu");
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

        internal static int ValidateInput()
        {
            var input = Console.ReadLine();
            int result;
            while (!int.TryParse(input, out result))
            {
                Console.WriteLine("Please enter a valid number");
                input = Console.ReadLine();
            }
            return result;
        }

        internal static void PublishScore(int score)
        {
            Console.WriteLine($"Your score is: {score}/5 ", score);
            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadLine();
        }

        internal static string GetName()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Hello pls type your name : ");
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input)){
                Console.WriteLine("The input string is empty.Pls enter a valid name: ");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
