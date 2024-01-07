using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.frockett
{
    internal class AuxFunctions
    {
        static List<string> gameHistory = new();

        internal static void PrintHistory()
        {
            Console.Clear();
            Console.WriteLine("Session History");
            Console.WriteLine("---------------");
            foreach (string game in gameHistory)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("\nPress any key to return to main menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int score, string gameType)
        {
            gameHistory.Add($"{DateTime.Now} - {gameType}: {score} points");
        }
    }
}
