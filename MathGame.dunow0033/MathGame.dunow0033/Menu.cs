namespace MathGame.dunow0033;

class Menu
{
	private string answer;
	private int number1;
	private int number2;
	private int score = 0;

	internal void ShowMenu(string name)
	{
		var isGameOn = true;
		do
		{
			Console.WriteLine("------------------------------");
			Console.WriteLine($"Hello {name}. It's {DateTime.Now.ToString("MM/dd/yyyy")}. It's your math game!!\n");
			Console.WriteLine("Press any key to show menu");
			Console.ReadKey();
			Console.Clear();
			Console.WriteLine($@"Please choose a subject:
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
			Console.WriteLine("------------------------------");

			var gameSelected = Console.ReadLine();

			switch (gameSelected.Trim().ToLower())
			{
				case "v":
					Helpers.PrintGames(name);
					break;
				case "a":
					GameChoices.AdditionGame(name);
					break;
				case "s":
					GameChoices.SubtractionGame(name);
					break;
				case "m":
					GameChoices.MultiplicationGame(name);
					break;
				case "d":
					GameChoices.DivisionGame(name);
					break;
				case "q":
					Console.Write("Goodbye");
					isGameOn = false;
					Environment.Exit(1);
					break;
				default:
					Console.WriteLine("Invalid input");
					break;
			}
		}
		while (isGameOn);
	}

}
