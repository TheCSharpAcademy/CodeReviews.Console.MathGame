using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.jwhitt3r
{
    public class Score
    {
        private List<string> _gameScore;
        public Score() {
            this._gameScore = new List<string>();
        }

        public void AddScore(string Score)
        {
            this._gameScore.Add(Score);
        }

        public void PrintScores()
        {
            foreach(var score in this._gameScore) { Console.WriteLine(score);}
        }
    }
}
