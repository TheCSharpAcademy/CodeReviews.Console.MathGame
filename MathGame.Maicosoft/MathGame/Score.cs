using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Score
    {
        public string? Name { get; set; }
        public int FinalScore { get; set; } = 0;
        public DateTime Date { get; set; } = new DateTime();
        public static List<Score>? Scores = new List<Score>();
    }
}
