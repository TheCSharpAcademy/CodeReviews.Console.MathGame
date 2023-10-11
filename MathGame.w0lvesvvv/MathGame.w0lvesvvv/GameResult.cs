using System.Diagnostics;

namespace MathGame.w0lvesvvv
{
    public class GameResult
    {

        #region CTOR
        public GameResult(string typeSymbol, int questions, int difficulty)
        {
            switch (typeSymbol)
            {
                case "a":
                    type = "Addition";
                    break;
                case "s":
                    type = "Subtraction";
                    break;
                case "m":
                    type = "Multiplication";
                    break;
                case "d":
                    type = "Division";
                    break;
                case "r":
                    type = "Random Game";
                    break;
            }

            this.questions = questions;

            this.difficulty = difficulty == 1 ? "Easy" : "Hard";

            this.gameTime = DateTime.Now.ToString();
        }
        #endregion

        private string type { get; set; }
        private int questions { get; set; }
        private int points { get; set; } = 0;
        private string difficulty { get; set; }
        private Stopwatch timer { get; set; } = new Stopwatch();
        private TimeSpan time { get { return new DateTime(timer.ElapsedTicks).TimeOfDay; } }
        private string gameTime { get; set; }

        #region PUBLIC METHODS
        public void StartTimer() { timer.Start(); }
        public void StopTimer() { timer.Stop(); }
        public void IncreasePoint() { points++; }
        public void DisplayResult(bool header)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            if (header) { Console.WriteLine("{0,-25} {1,-23} {2,-10} {3,-10}", "Game Time", "Type", "Points", "Time"); }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0,-25} {1,-23} {2,-10} {3,-10}", $"{gameTime}", $"{type} ({difficulty})", $"{points}/{questions}", $"{time}");
        }
        #endregion


    }
}
