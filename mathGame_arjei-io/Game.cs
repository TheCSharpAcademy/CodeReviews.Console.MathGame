
namespace mathGame_arjei_io
{
    internal class Game
    {
        public GameType Type { get; set; }
        public int Score { get; set; }
        public required string Seconds { get; set; }
        public required string Difficulty { get; set; }
    }

    internal enum GameType
    {
        Addition,
        Subtraction,
        Division,
        Multiplication,
        Random
    }
}
