using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class FileIO
    {
        public static void Save(SavedGame sg)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "games.txt";
            File.AppendAllText(path, sg.ToFileString());
        }

        public static List<SavedGame> RetrieveGames(string username)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + "games.txt";
            return File.ReadAllLines(path)
                .Select(SavedGame.ParseFromFile)
                .Where(s => s.Username == username)
                .ToList()
                ;
        }

        public static void PrintPastGames(string username, List<SavedGame> games)
        {
            Console.WriteLine($"All saved games for {username}:");
            games.ForEach(g => Console.WriteLine(g.ToGameString()));
        }
    }
}
