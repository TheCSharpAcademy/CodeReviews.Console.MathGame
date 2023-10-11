namespace MyFirstProgram
{
	internal class Menu
	{
		GameEngine gameEngine = new();
		internal void ShowMenu(string name, DateTime date)
		{
			Console.Clear();
			Console.WriteLine(
				$"Hello {name}. It's {date.DayOfWeek}. This is your maths game.\n");
			Console.WriteLine("Press any key to show menu");
			Console.ReadLine();
			Console.WriteLine("\n");

			var isGameOn = true;

			do
			{
				Console.Clear();
				Console.WriteLine(@$"What game would you like to play today? Choose from the options below:

A - Addition
S - Subtraction
M - Multiplication
D - Division 


V - View Previous Games
Q - Quit the program");
				Console.WriteLine("----------------------------------------------");

				var gameSelected = Console.ReadLine().Trim().ToLower();

				switch (gameSelected)
				{
					case "v":
						Helpers.PrintGames();
						break;

					case "a":
						gameEngine.AdditionGame("Addition game");
						break;
					case "s":
						gameEngine.SubtractionGame("Subtraction game");
						break;
					case "m":
						gameEngine.MultiplicationGame("Multiplication game");
						break;
					case "d":
						gameEngine.DivisionGame("Division game");
						break;
					case "q":
						Console.WriteLine("Goodbye");
						isGameOn = false;
						break;
					default:
						Console.WriteLine("Invalid Input");
						break;
				}
			} while (isGameOn);
		}
	}
}
