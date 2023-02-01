namespace MathGame
{
	internal class MultiplicationLevels
	{
		MultiplicationEngine multiplication = new();

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
						multiplication.EasyMultiplicationGame();
						break;
					case "m":
						multiplication.MediumMultiplicationGame();
						break;
					case "h":
						multiplication.HardMultiplicationGame();
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
