namespace MathGame
{
	internal class Menu
	{
		GameEngine gameEngine = new();

		// Menu
		internal void ShowMenu(string name, DateTime date)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine($"Welcome to The Math Game, {name}.\nThe time is {date.Hour}:{date.Minute} on {date.DayOfWeek}.\n");
			bool firstRun = true;
			bool playGame = true;
			do
			{
				if (!firstRun)
					Console.Clear();
				firstRun = false;
				Console.WriteLine($@"Please select a game to play from the list below:
V - View Game History
A - Addition
S - Subtraction
M - Multiplication
D - Division
R - Random
Q - Quit");
				Console.WriteLine("------------------------------------------------------");
				Console.Write("Game Selection: ");

				string? gameSelected = Console.ReadLine();
				if (gameSelected != null)
					switch (gameSelected.Trim().ToLower())
					{
						case "v":
							Helpers.GetGames();
							break;
						case "a":
							gameEngine.AdditionGame("Addition Game");
							break;
						case "s":
							gameEngine.SubtractionGame("Subtraction Game");
							break;
						case "m":
							gameEngine.MultiplicationGame("Multiplication Game");
							break;
						case "d":
							gameEngine.DivisionGame("Division Game");
							break;
						case "r":
							gameEngine.RandomGame("Random Game");
							break;
						case "q":
							Console.WriteLine("You selected quit the game.");
							playGame = false;

							break;
						default:
							Console.WriteLine("Invalid Input. Press any key to select a valid entry.");
							Console.ReadLine();

							break;
					}
			} while (playGame);
		}
	}
}
