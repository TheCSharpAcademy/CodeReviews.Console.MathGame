using ConsoleMathsGame.Models;
namespace ConsoleMathsGame;

internal class Menu
{
	GameEngine gameEngine = new();
	internal void ShowMenu(string name, DateTime date)
	{
		bool isGameOn = true;
		do
		{
			Console.Clear();
			Console.WriteLine($"""
					-----------------------------------
					Hello {name}. It's {date:g}. This is your maths game.
					What game would you like to play today?:
					V - View Previous games
					A - Addition
					S - Subtraction
					M - Multiplication
					D - Division
					R - Random Game
					Q - Quit the program
					-----------------------------------
					""");			        

			string? gameSelected = Console.ReadLine();
			gameSelected = Helpers.ValidateMenu(gameSelected.Trim().ToLower());

			if (gameSelected == "v")
			{
				Helpers.PrintGames(); 
				continue;
			}
			else if (gameSelected == "q")
			{
				Console.WriteLine("Goodbye");
				isGameOn = false;
				continue;
			}
			else if (gameSelected == "r")
			{
				var random = new Random();
				string[] types = new[] { "a", "s", "m", "d" };
				string[] diffs = new[] { "e", "m", "d" };
				string randomType = types[random.Next(types.Length-1)];
				string randomDiff = diffs[random.Next(diffs.Length-1)];
				int rnds = random.Next(0, 15);

				gameEngine.RunGame(randomType switch
				{
					"a" => GameType.Addition,
					"s" => GameType.Subtraction,
					"m" => GameType.Multiplication,
					"d" => GameType.Division,
				}, randomDiff switch
				{
					"e" => Difficulty.Easy,
					"m" => Difficulty.Medium,
					"d" => Difficulty.Difficult
				}, rnds);
			}				

			Console.Clear();
			Console.WriteLine("""
				Choose your difficulty:
				E - Easy
				M - Medium
				D - Difficult
				-----------------------------------
				""");

			string? difficulty = Console.ReadLine();
			difficulty = Helpers.ValidateDifficulty(difficulty);

			Console.Clear();

			Console.Write("How many rounds?: ");
			string? rounds = Console.ReadLine();
			rounds = Helpers.ValidateResult(rounds);

			gameEngine.RunGame(gameSelected switch
			{
				"a" => GameType.Addition,
				"s" => GameType.Subtraction,
				"m" => GameType.Multiplication,
				"d" => GameType.Division,
			}, difficulty switch
			{
				"e" => Difficulty.Easy,
				"m" => Difficulty.Medium,
				"d" => Difficulty.Difficult
			}, int.Parse(rounds));				
		} while (isGameOn);
	}
}
