using MyFirstProgram.Models;
namespace MyFirstProgram
{
	internal class Helpers
	{
		internal static List<Game> games = new List<Game>();
		internal static int[] GetDivisionNumbersEasyGame()
		{
			var random = new Random();
			var firstNumber = random.Next(0, 99);
			var secondNumber = random.Next(0, 99);

			var result = new int[2];


			while (firstNumber % secondNumber != 0)
			{
				firstNumber = random.Next(1, 99);
				secondNumber = random.Next(1, 99);
			}

			result[0] = firstNumber;
			result[1] = secondNumber;

			return result;
		}

		internal static int[] GetDivisionNumbersMediumGame()
		{
			var random = new Random();
			var firstNumber = random.Next(10, 99);
			var secondNumber = random.Next(10, 99);

			var result = new int[2];


			while (firstNumber % secondNumber != 0)
			{
				firstNumber = random.Next(10, 99);
				secondNumber = random.Next(10, 99);
			}

			result[0] = firstNumber;
			result[1] = secondNumber;

			return result;
		}

		internal static int[] GetDivisionNumbersHardGame()
		{
			var random = new Random();
			var firstNumber = random.Next(100, 999);
			var secondNumber = random.Next(100, 999);

			var result = new int[2];


			while (firstNumber % secondNumber != 0)
			{
				firstNumber = random.Next(100, 999);
				secondNumber = random.Next(100, 999);
			}

			result[0] = firstNumber;
			result[1] = secondNumber;

			return result;
		}

		internal static void PrintGames()
		{
			Console.Clear();
			Console.WriteLine("Games History");
			Console.WriteLine("---------------------------------");
			foreach (var game in games)
			{
				Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}pts");
			}
			Console.WriteLine("---------------------------------\n");
			Console.WriteLine("Press any key to go back to the main menu");
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

		internal static string? ValidationResult(string result)
		{
			while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
			{
				Console.WriteLine("Your answer needs to be an integer. Try again.");
				result = Console.ReadLine();
			}
			return result;
		}

		internal static string GetName()
		{
			Console.WriteLine("Please type your name");
			var name = Console.ReadLine();

			while (string.IsNullOrEmpty(name))
			{
				Console.WriteLine("Name can't be empty");
				name = Console.ReadLine();
			}

			return name;
		}

		internal static void SetNumberOfQuestions()
		{
			Console.WriteLine("How many questions do you want to answer?");
			var questions = Convert.ToInt32(Console.ReadLine());
			Game.NumberOfQuestions = questions;
		}

		internal static int GetNumberOfQuestions()
		{
			return Game.NumberOfQuestions;
		}
	}
}
