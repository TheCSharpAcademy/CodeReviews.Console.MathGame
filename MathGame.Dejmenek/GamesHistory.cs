namespace MathGame.Dejmenek
{
    internal class GamesHistory
    {
        private readonly List<Game> _Games = new();

        public GamesHistory() { }

        public void Show() {
            if (IsAnyGame())
            {
                int index = 1;
                foreach (var game in _Games)
                {
                    Console.WriteLine($"Game {index}: Time: {game.FormattedTimeTaken}, Score: {game.Score}/{game.NumberOfQuestions}");
                    index++;
                }
            }
            else {
                Console.WriteLine("You haven't played any game yet");
            }
            
        }

        private bool IsAnyGame() {
            return _Games.Count > 0;
        }

        public void AddGame(Game game) { 
            _Games.Add(game);
        }
    }
}
