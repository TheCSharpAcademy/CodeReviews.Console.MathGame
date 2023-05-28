namespace CalculatingGame.Models
{
    internal class GameDetailsModel
    {
        public string? Name { get; set; }
        public int Score;
        public DateTime Date;
        public GameType Type;
        internal enum GameType
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

    }
}
