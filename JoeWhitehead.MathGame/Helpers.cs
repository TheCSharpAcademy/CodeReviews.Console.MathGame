using ConsoleMathsGame.Models;

namespace ConsoleMathsGame
{
	internal class Helpers
	{
		internal static List<Game> games = new();

		internal static int[] GetNumbers(GameType gameType, Difficulty difficulty)
		{
			var random = new Random();
			int low = 0;
			int high = 0;
			int firstNumber;
			int secondNumber;
			
			switch (difficulty)
			{
				case Difficulty.Easy:
					low = 1;
					high = 10;
				break;

				case Difficulty.Medium:
					low = 0;
					high = 50;
				break;

				case Difficulty.Difficult:
					low = 70;
					high = 160;
				break;
			}

			firstNumber = random.Next(low, high);
			secondNumber = random.Next(low, high);

			if(gameType == GameType.Division)
			{
				while (firstNumber % secondNumber != 0)
				{
					firstNumber = random.Next(low, high);
					secondNumber = random.Next(low, high);
				}
			}
			return [firstNumber, secondNumber];
			
		}

		internal static int[] GetDivisionNumbers()
		{
			var random = new Random();
			var firstNumber = random.Next(0, 99);
			var secondNumber = random.Next(0, 99);

			var result = new int[2];

			while (firstNumber % secondNumber != 0)
			{
				firstNumber = random.Next(0, 99);
				secondNumber = random.Next(0, 99);
			}

			result[0] = firstNumber;
			result[1] = secondNumber;

			return result;
		}

		internal static char GetOperator(GameType gameType)
		{
			return gameType switch
			{
				GameType.Addition => '+',
				GameType.Subtraction => '-',
				GameType.Multiplication => '*',
				GameType.Division => '/',
				_ => throw new NotImplementedException()
			};
		}

		internal static void AddToHistory(int gameScore, GameType gameType, Difficulty difficulty, string timeElapsed, int rounds)
		{
			games.Add(new Game
			{
				Date = DateTime.Now,
				Score = gameScore,
				Type = gameType,
				Difficulty = difficulty,
				Elapsed = timeElapsed,
				Rounds = rounds
			});
		}

		internal static void PrintGames()
		{
			Console.Clear();
			Console.WriteLine("Games History");
			Console.WriteLine("-----------------------------------");
			foreach (var game in games)
			{
				Console.WriteLine($"""				
				{game.Date}
				{game.Type}({game.Difficulty}): {game.Score}pts
				Time: {game.Elapsed}
				Rounds: {game.Rounds}
				-----------------------------------
				""");
			}
			Console.WriteLine("Press any key to return to the Main Menu");
			Console.ReadKey(true);
			Console.Clear();
		}

		internal static string? ValidateResult(string result)
		{
			while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("Your answer needs to be a number. Try again: ");
				Console.ResetColor();
				result = Console.ReadLine();
			}
			return result;
		}		

		internal static string? ValidateMenu(string result)
		{
			string[] menuOptions = new[] { "v", "a", "s", "m", "d", "r", "q" };
			while (!menuOptions.Contains(result))
			{
				Console.Write("Invalid input. Try again: ");
				result = Console.ReadLine();
			}
			return result;
		}

		internal static string? ValidateDifficulty(string result)
		{
			string[] menuOptions = new[] { "e", "m", "d"};
			while (!menuOptions.Contains(result))
			{
				Console.Write("Invalid input. Try again: ");
				result = Console.ReadLine();
			}
			return result;
		}

		internal static string GetName()
		{
			Console.Write("Please type your name: ");

			var name = Console.ReadLine();

			while(string.IsNullOrEmpty(name))
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("Name can't be empty: ");
				Console.ResetColor();
				name = Console.ReadLine();
			}
			Console.Clear();
			return name;
		}

		internal static string TimeElapsed(DateTime start, DateTime end)
		{
			TimeSpan elapsed = end - start;
			return $"{elapsed.Hours}:{elapsed.Minutes}:{elapsed.Seconds}";	
		}
	}
}
