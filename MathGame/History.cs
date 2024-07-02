using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public class History
    {
        List<string> history = new List<string>();

        public void AddGame(string gameName)
        {
            
            history.Add(gameName);
        }

        public List<string> GetGames()
        {
            return history;
        }

        public void PrintHistory()
        {
            if (history.Count == 0)
            {
                Console.WriteLine("No games played yet");
                Console.WriteLine("\n");
                return;
            }
            foreach(var game in history)
            {
                Console.WriteLine(game);

            }
            Console.WriteLine("\n");
        }

    }
}
