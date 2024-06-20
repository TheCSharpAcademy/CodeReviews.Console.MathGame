namespace MathGame
{
	internal class Helpers
	{
		//static List<Game> games = new();
		internal static List<Game> games = new List<Game>
	{
		new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
		new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4 },
		new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4 },
		new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3 },
		new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
		new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2 },
		new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3 },
		new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4 },
		new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
		new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1 },
		new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0 },
		new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
		new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5 },
	};
		internal static void PrintGames()
		{
			var gamesToPrint = games.Where(x => x.Date > new DateTime(2022, 08, 09) && x.Score > 2).OrderByDescending(x => x.Score);
			Console.Clear();
			Console.WriteLine("Games History");
			Console.WriteLine("------------------------------------");
			foreach (Game game in gamesToPrint)
			{
				Console.WriteLine($"{game.Date} - {game.Type}: Score {game.Score}");
			}
			Console.WriteLine("------------------------------------\n");
			Console.Write("Press any key to return to main menu.");
			Console.ReadLine();
		}

		internal static void AddToHistory(int gameScore, GameType gameType)
		{
			games.Add(new Game
			{
				Date = DateTime.Now,
				Score = gameScore,
				Type = gameType
			});
		}

		internal static int[] GetDivisionNumbers()
		{
			Random random = new Random();
			int[] result = new int[2];

			result[0] = random.Next(1, 101);
			result[1] = random.Next(1, 101);

			while (result[0] % result[1] != 0)
			{
				result[0] = random.Next(1, 101);
				result[1] = random.Next(1, 101);
			}

			return result;
		}
	}
}
