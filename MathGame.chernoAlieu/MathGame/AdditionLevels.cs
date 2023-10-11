namespace MathGame
{
	internal class AdditionLevels
	{
		AdditionEngine addition = new();
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
						addition.EasyAdditionGame();
						break;
					case "m":
						addition.MediumAdditionGame();
						break;
					case "h":
						addition.HardAdditionGame();
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
