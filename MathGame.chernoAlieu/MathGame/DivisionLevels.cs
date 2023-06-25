namespace MathGame
{
	internal class DivisionLevels
	{
		DivisionEngine division = new();

		internal void selectDifficultyLevel()
		{
			var isGameOn = true;
			do
			{
				Console.Clear();
				Console.WriteLine($@"Select a difficulty level
E - Easy
M - Medium
H - Hard


B - Back to Main Menu");

				var levelSelected = Console.ReadLine().Trim().ToLower();



				Console.Clear();
				switch (levelSelected)
				{
					case "e":
						division.EasyDivisionGame();
						break;
					case "m":
						division.MediumDivisionGame();
						break;
					case "h":
						division.HardDivisionGame();
						break;
					case "b":
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
