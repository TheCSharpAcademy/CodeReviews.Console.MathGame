﻿namespace MathGame
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

		internal static void AddToHistory(int gameScore, string gameType)
		{
			games.Add(new Game
			{
				Date = DateTime.Now,
				Score = gameScore,
				Type = gameType
			});
			//games.Add($"{DateTime.Now} - {gameType}: Score {gameScore}");

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
