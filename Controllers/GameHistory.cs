namespace MathGame
{
    internal class GameHistory
    {
        internal List<Game> games = new List<Game>
        {
            new Game {Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 3},
            new Game {Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 2},
            new Game {Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 5},
        };

        internal void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType
            });
        }

        internal void PrintGames()
        {
            // IEnumerable<Game> gamesToPrint = games.Where(x => x.Type == GameType.Division && x.Score > 2).OrderByDescending(x => x.Score);

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-------------");

            foreach (Game game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts");
            }

            Console.WriteLine("-------------\n");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
        }
    }
}