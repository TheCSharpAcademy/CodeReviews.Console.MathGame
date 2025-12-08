namespace MathGame.Models
{
    internal class GameResult
    {
        public int Result { get; set; }
        public int Difficulty { get; set; }
        public GameMode GameMode { get; set; }
        public DateTime Date { get; set; }
        public long Time { get; set; }

        public GameResult(int result, GameMode gameMode, int difficulty, long time)
        {
            Result = result;
            GameMode = gameMode;
            Date = DateTime.Now;
            Difficulty = difficulty;
            Time = time;
        }

        public override string ToString()
        {
            return new string(
                $"On {Date.ToString()} you played a game of " +
                $"{GameMode.ToString()} on difficulty level {Difficulty} " +
                $"and got the score {Result} in {TimeSpan.FromMilliseconds(Time).TotalMinutes:N2} minutes"
            );
        }
    }
}
