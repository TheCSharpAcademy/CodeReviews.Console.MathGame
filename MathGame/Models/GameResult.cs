namespace MathGame.Models
{
    internal class GameResult
    {
        public int Result { get; set; }
        public GameMode GameMode { get; set; }
        public DateTime Date { get; set; }

        public GameResult(int result, GameMode gameMode)
        {
            Result = result;
            GameMode = gameMode;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return new string(
                $"On {Date.ToString()} you played a game of {GameMode.ToString()} and got the score {Result} "
            );
        }
    }
}
