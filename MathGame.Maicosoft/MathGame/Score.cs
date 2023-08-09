namespace MathGame
{
    internal class Score
    {
        public string? Name { get; set; }
        public int FinalScore { get; set; };
        public DateTime Date { get; set; } = new DateTime();
        public static List<Score>? Scores = new List<Score>();
    }
}
