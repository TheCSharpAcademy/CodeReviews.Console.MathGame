namespace MathGame
{
	internal class Helpers
	{
		static List<Game> games = new();

		internal static void PrintGames()
		{

			Console.Clear();
			Console.WriteLine("Games History");
			Console.WriteLine("------------------------------------");
			foreach (Game game in games)
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

		internal static string? ValidateResult(string result, string message)
		{
			while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
			{
				Console.WriteLine("Your answer must be an integer. Please try again.");
				Console.Write(message);
				result = Console.ReadLine()!;
			}
			return result;
		}

		internal static string? GetName()
		{
			Console.Write("Please enter your name: ");
			string? name = Console.ReadLine()!;

			while (string.IsNullOrEmpty(name))
			{
				Console.WriteLine("Name cannot be empty.");
				Console.Write("Please enter your name: ");
				name = Console.ReadLine()!;
			}
			return name;
		}
	}
}
