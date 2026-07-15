using System;
using System.Collections.Generic;
using System.Text;
using static STUDY.MathGame.Enums;

namespace STUDY.MathGame
{
    public class GameResults
    {
        private DateOnly Date { get; set; }
        private Operation Operation { get; set; }
        private int CurrentScore { get; set; }
        private int TotalScore { get; set; }

        public GameResults(Operation operation, int currentScore, int totalScore)
        {
            Operation = operation;
            CurrentScore = currentScore;
            Date = DateOnly.FromDateTime(DateTime.Now.Date);
            TotalScore = totalScore;
        }

        public void Display()
        {
            Console.WriteLine($"{Date}:{Operation} - {CurrentScore}/{TotalScore}");

        }
    }
}
