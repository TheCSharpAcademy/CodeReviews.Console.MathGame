using idrisKurtar.Math_game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idrisKurtar.Math_game
{
    internal class Helpers
    {
        internal static List<Game> games = new List<Game>();
        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---------------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts");

            }
            Console.WriteLine("----------------------------\n");
            Console.WriteLine("Press any key to go back to the main menu.");
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
        internal static int[] GetDivisonNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(1, 99);
            var SecondNumber = random.Next(1, 99);

            var result = new int[2];


            while (firstNumber % SecondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                SecondNumber = random.Next(1, 99);
            }
            result[0] = firstNumber;
            result[1] = SecondNumber;

            return result;
        }
    }
}
