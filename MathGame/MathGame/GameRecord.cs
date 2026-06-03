using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame
{
    internal class GameRecord (int score, DateTime endGameTime, string operationName)
    {
        public int Score { get; set; } = score;
        public DateTime EndGameTime { get; set; } = endGameTime;
        public string OperationName { get; set; } = operationName;
    }
}
