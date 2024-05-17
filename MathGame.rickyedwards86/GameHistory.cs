namespace MathGame
{
    internal class GameHistory
    {
        static readonly GameHistory _instance = new GameHistory();
        static List<GameScore> _scores { get; set; }

        static GameHistory() { }
        private GameHistory() { }

        public static GameHistory Instance { get { return _instance; } }

        public void SaveScore(GameScore gameScore)
        {
            if (_scores == null) _scores = new List<GameScore> { };

            _scores.Add(gameScore);
        }

        public List<GameScore> Scores { get { return _scores ?? new List<GameScore> { }; } }
    }
}
