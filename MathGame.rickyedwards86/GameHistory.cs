namespace MathGame
{
    internal class GameHistory
    {
        static readonly GameHistory _instance = new GameHistory();
        static List<GameScore> GameScores { get; set; }

        static GameHistory() { }
        private GameHistory() { }

        public static GameHistory Instance { get { return _instance; } }

        public void SaveScore(GameScore gameScore)
        {
            if (GameScores == null) GameScores = new List<GameScore> { };

            GameScores.Add(gameScore);
        }

        public List<GameScore> Scores { get { return GameScores ?? new List<GameScore> { }; } }
    }
}
