namespace Math_Game_lib.Model
{
    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    internal enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }

    internal class Game
    {
        internal DateTime DateTime { get; set; }
        internal GameType GameType { get; set; }
        internal GameDifficulty GameDifficulty { get; set; }
        internal TimeSpan GameDuration { get; set; }
        internal int NumberOfQuestion { get; set; }
        internal int Score { get; set; }
    }
}
