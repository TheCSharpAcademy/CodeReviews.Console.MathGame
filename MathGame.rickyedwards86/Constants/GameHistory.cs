namespace MathGame.Constants
{
    internal class GameHistory
    {
        static readonly GameHistory _instance = new GameHistory();
        static List<GameScore> _gameScores { get; set; }

        static GameHistory() { }
        private GameHistory() { }

        public static GameHistory Instance { get { return _instance; } }

        public void SaveScore(GameScore gameScore)
        {
            if (_gameScores == null) _gameScores = new List<GameScore> { };

            _gameScores.Add(gameScore);
        }

        public List<GameScore> GameScores { get { return _gameScores??new List<GameScore> {  }; } }
    }
}
