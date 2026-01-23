using MathGame.Logic;
using MathGame.Utils;

namespace MathGame.Views
{
    public class ContestView
    {
        private readonly ContestResults _results = new();
        public void Display(List<HistoryRecord> history, Contest contest)
        {
            DateTime timeStart = DateTime.Now;
            int points = contest.Play();
            TimeSpan totalTime = DateTime.Now - timeStart;

            _results.Display(totalTime, points);
            
            string operation = contest.Config.Operator;
            Difficulty difficulty = contest.Config.Difficulty;

            string op = String.IsNullOrEmpty(operation) ? "R" : operation;

            history.Add(new(difficulty.ToString(), op, points, totalTime));
        }
    }
}

