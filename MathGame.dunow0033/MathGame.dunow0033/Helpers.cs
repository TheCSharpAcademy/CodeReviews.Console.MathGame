using MathGame.dunow0033.Models;
using System.Text.RegularExpressions;

namespace MathGame
{
	internal class Helpers
	{
		internal static List<Game> gameHistory = new();

		internal static void AddToHistory(int gameScore, GameType gameType)
		{
			gameHistory.Add(new Game
			{
				Date = DateTime.Now,
				Score = gameScore,
				Type = gameType
			});
		}

		internal static void PrintGames(string name)
		{
			Console.Clear();

			if (gameHistory.Count > 0)
			{
				Console.WriteLine("Games History");
				Console.WriteLine("--------------------");
				foreach (var game in gameHistory)
				{

					Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} points");
				}
				Console.WriteLine("--------------------\n");
				Console.WriteLine("Press any key to return to main menu");
				Console.ReadKey();
				Console.Clear();
			}
			else
			{
				Console.WriteLine($"Sorry {name}, you have no game history yet");
				Console.WriteLine();
				Console.WriteLine("Press any key to return to main menu");
				Console.ReadKey();
				Console.Clear();
			}
		}

		internal static int[] GetDivisionNumbers()
		{
			var number = new Random();
			int[] numbers = new int[2];

			do
			{
				numbers[0] = number.Next(0, 20);
				numbers[1] = number.Next(1, 20);
			}
			while (numbers[0] % numbers[1] != 0);

			return numbers;
		}

		internal static string? ValidateNumber(string number)
		{
			while (string.IsNullOrEmpty(number) || !Int32.TryParse(number, out _))
			{
				// Input is not a valid integer.
				Console.WriteLine();
				Console.Write("Invalid input. Please enter only integers ('q' to quit):  ");
				number = Console.ReadLine();

				if (number.Trim().ToLower() == "q")
				{
					return number.Trim().ToLower();
				}
			}

			return number;
		}

		internal static string GetName()
		{
			Console.WriteLine("Hello, what is your name?");
			var name = Console.ReadLine();

			while (!Regex.IsMatch(name, "^[a-zA-Z]+$"))
			{
				Console.WriteLine("Sorry, name should only be letters.  Please try again:");
				name = Console.ReadLine();
			}

			while (string.IsNullOrEmpty(name))
			{
				Console.WriteLine("Sorry, name must not be empty.  Please try again:");
				name = Console.ReadLine();
			}

			name = char.ToUpper(name[0]) + name.Substring(1).ToLower();

			return name;
		}
	}
}
