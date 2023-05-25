
namespace MathGame.furiax
{
	internal class Menu
	{
		GameEngine gameEngine = new();
		internal void ShowMenu(string name, DateTime date)
		{
			Console.Clear();
			Console.WriteLine($"Hello {name.ToUpper()} the time is {date}");
			Console.Write("Press any key to show menu");
			Console.ReadLine();
			Console.WriteLine("\n");

			bool isGameOn = true;

			do
			{
				Console.Clear();
				Console.WriteLine("This is your Math Game");
				Console.WriteLine(@$"What do you want to do ?
A - Addition
S - Substraction
M - Multiplication
D - Division
V - View Previous Games
Q - Quit the program");
				Console.WriteLine("----------------------------------");

				var selected = Console.ReadLine();

				switch (selected.Trim().ToUpper())
				{
					case "A":
						gameEngine.AdditionGame("Addition game");
						break;
					case "S":
						gameEngine.SubstractionGame("Substraction game");
						break;
					case "M":
						gameEngine.MultiplicationGame("Muliplication game");
						break;
					case "D":
						gameEngine.DivisionGame("Division game");
						break;
					case "Q":
						Console.WriteLine($"Goodbye {name}");
						isGameOn = false;
						break;
					case "V":
						Helpers.PrintGames();
						break;
					default:
						Console.WriteLine("Invalid Input");

						break;
				}
			} while (isGameOn);

		}

	}
}
