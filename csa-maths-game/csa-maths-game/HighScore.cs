using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csa_maths_game
{
    public static class HighScore
    {
        private static readonly int MaxScores = 5;
        static List<(int score, string name)> highScores = new List<(int score, string name)>(MaxScores);
        static readonly Dictionary<int, string> Positional = new Dictionary<int, string>()
        {
            { 1, "1st" },
            { 2, "2nd" },
            { 3, "3rd" },
            { 4, "4th" },
            { 5, "5th" }
        };

        public static void Add(int score, string op)
        {
            highScores.Add((score, op));
            highScores.Sort(ScoreComparator);
            if (highScores.Count > MaxScores)
            {
                highScores.RemoveAt(MaxScores);
            }
        }
        public static void DisplayHighScores()
        {
            if (highScores.Count == 0)
            {
                Console.WriteLine("No scores recorded");
            }
            else
            {
                int i = 1;
                foreach (var score in highScores)
                {
                    Console.WriteLine("{0} : {1} in {2}", Positional[i], score.score, score.name);
                    i++;
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static int ScoreComparator((int score, string name) a, (int score, string name) b)
        {
            if (a.score < b.score)
            {
                return 1;
            }
            else if (a.score > b.score)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
}
