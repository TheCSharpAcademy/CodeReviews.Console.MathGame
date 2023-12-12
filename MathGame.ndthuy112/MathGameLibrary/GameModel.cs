using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameLibrary
{
    public class GameModel
    {
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public string GameType { get; set; }
        public DateTime TimePlayed { get; set; }
        public GameModel(int score, int totalQuestions, string gameType, DateTime timePlayed) 
        {
            Score = score;
            TotalQuestions = totalQuestions;
            GameType = gameType;
            TimePlayed = timePlayed;
        }
    }
}
