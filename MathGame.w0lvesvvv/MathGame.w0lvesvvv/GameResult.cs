using System.Diagnostics;

namespace MathGame.w0lvesvvv
{
    public class GameResult
    {

        #region CTOR
        public GameResult(string typeSymbol)
        {
            switch (typeSymbol)
            {
                case "A":
                    type = "Addition";
                    break;
                case "S":
                    type = "Subtraction";
                    break;
                case "M":
                    type = "Multiplication";
                    break;
                case "D":
                    type = "Division";
                    break;
                case "R":
                    type = "Random Game";
                    break;
            }
        }
        #endregion

        private string type { get; set; }
        private int points { get; set; } = 0;
        private Stopwatch timer { get; set; } = new Stopwatch();
        private TimeSpan time { get { return new DateTime(timer.ElapsedTicks).TimeOfDay; } }

        #region PUBLIC METHODS
        public void StartTimer() { timer.Start(); }
        public void StopTimer() { timer.Stop(); }
        public void IncreasePoint() { points++; }   
        public void DisplayResult() {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{type} - {points} - {time} ");
        }
        #endregion


    }
}
