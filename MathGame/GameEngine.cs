namespace MathGame
{
	internal class GameEngine
	{
		// Addition Game
		internal void AdditionGame(string message)
		{

			Random random = new Random();
			int firstNumber;
			int secondNumber;
			int score = 0;

			for (int i = 0; i < 5; i++)
			{
				Console.Clear();
				Console.WriteLine(message + $" (Question {i + 1})");
				firstNumber = random.Next(1, 11);
				secondNumber = random.Next(1, 11);
				Console.Write($"{firstNumber} + {secondNumber} = ");
				string? result = Console.ReadLine();

				if (int.Parse(result!) == firstNumber + secondNumber)
				{
					Console.WriteLine("Correct! Press any key for next question.");
					score++;
					Console.ReadLine();
				}
				else
				{
					Console.WriteLine("Bzzzt!!! Incorrect! Press any key for next question.");
					Console.ReadLine();
				}
			}

			Console.WriteLine($"Game over. Your score is {score} ({(score / 5.0):P2})");
			Helpers.AddToHistory(score, "Addition");


			Console.Write("Press any key to return to main menu.");
			Console.ReadLine();
		}

		// Subtraction Game
		internal void SubtractionGame(string message)
		{

			Random random = new Random();
			int firstNumber;
			int secondNumber;
			int score = 0;

			for (int i = 0; i < 5; i++)
			{
				Console.Clear();
				Console.WriteLine(message + $" (Question {i + 1})");
				firstNumber = random.Next(1, 11);
				secondNumber = random.Next(1, 11);
				Console.Write($"{firstNumber} - {secondNumber} = ");
				string? result = Console.ReadLine();

				if (int.Parse(result!) == firstNumber - secondNumber)
				{
					Console.WriteLine("Correct! Press any key for next question.");
					score++;
					Console.ReadLine();
				}
				else
				{
					Console.WriteLine("Bzzzt!!! Incorrect! Press any key for next question.");
					Console.ReadLine();
				}
			}

			Console.WriteLine($"Game over. Your score is {score} ({(score / 5.0):P2})");
			Helpers.AddToHistory(score, "Subtraction");
			Console.Write("Press any key to return to main menu.");
			Console.ReadLine();
		}

		// Multiplication Game
		internal void MultiplicationGame(string message)
		{

			Random random = new Random();
			int firstNumber;
			int secondNumber;
			int score = 0;

			for (int i = 0; i < 5; i++)
			{
				Console.Clear();
				Console.WriteLine(message + $" (Question {i + 1})");
				firstNumber = random.Next(1, 11);
				secondNumber = random.Next(1, 11);
				Console.Write($"{firstNumber} x {secondNumber} = ");
				string? result = Console.ReadLine();

				if (int.Parse(result!) == firstNumber * secondNumber)
				{
					Console.WriteLine("Correct! Press any key for next question.");
					score++;
					Console.ReadLine();
				}
				else
				{
					Console.WriteLine("Bzzzt!!! Incorrect! Press any key for next question.");
					Console.ReadLine();
				}
			}

			Console.WriteLine($"Game over. Your score is {score} ({(score / 5.0):P2})");
			Helpers.AddToHistory(score, "Multiplication");
			Console.Write("Press any key to return to main menu.");
			Console.ReadLine();
		}

		// Divsion Game
		internal void DivisionGame(string message)
		{


			int score = 0;

			for (int i = 0; i < 5; i++)
			{
				Console.Clear();
				Console.WriteLine(message + $" (Question {i + 1})");
				int[] divisionNumbers = Helpers.GetDivisionNumbers();
				int firstNumber = divisionNumbers[0];
				int secondNumber = divisionNumbers[1];

				Console.Write($"{firstNumber} / {secondNumber} = ");
				string? result = Console.ReadLine();

				if (int.Parse(result!) == firstNumber / secondNumber)
				{
					Console.WriteLine("Correct! Press any key for next question.");
					score++;
					Console.ReadLine();
				}
				else
				{
					Console.WriteLine("Bzzzt!!! Incorrect! Press any key for next question.");
					Console.ReadLine();
				}
			}

			Console.WriteLine($"Game over. Your score is {score} ({(score / 5.0):P2})");
			Helpers.AddToHistory(score, "Division");
			Console.Write("Press any key to return to main menu.");
			Console.ReadLine();

		}

		// Random Game
		internal void RandomGame(string message)
		{
			Console.WriteLine(message);
		}
	}
}
