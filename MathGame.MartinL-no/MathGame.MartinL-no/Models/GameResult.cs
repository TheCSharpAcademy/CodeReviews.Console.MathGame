namespace MathGame.MartinL_no.Models
{
    internal class GameResult
    {
        internal DateTime StartTime { get; set; }
        internal TimeSpan Duration { get; set; }
        internal GameType Type { get; set; }
        public Difficulty Difficulty { get; set; }
        public int Questions { get; set; }
        internal int Score { get; set; }

        public GameResult(DateTime startTime, TimeSpan duration, GameType type, Difficulty difficulty, int questions, int score)
        {
            StartTime = startTime;
            Duration = duration;
            Type = type;
            Difficulty = difficulty;
            Questions = questions;
            Score = score;
        }

        public override string ToString()
        {
            return $"{ StartTime.ToString("g").PadRight(21) }{ (Duration.ToString("%m") + "mins").PadRight(13) }{ Type.ToString().PadRight(18) }{ Difficulty.ToString().PadRight(11) }{ Questions.ToString().PadRight(14)}{ Score }";
        }
    }
}