using MyFirstProgram.Models;
using MyFirstProgram;


namespace MathGame
{
	internal class DivisionEngine
	{
		internal void EasyDivisionGame()
		{
			Helpers.SetNumberOfQuestions();

			Console.Clear();
			var random = new Random();
			var score = 0;

			int firstNumber;
			int secondNumber;
			

			for (int j = 0; j < Helpers.GetNumberOfQuestions(); j++)
			{
				firstNumber = random.Next(1, 9);
				secondNumber = random.Next(1, 9);
				var product = firstNumber * secondNumber;

				Console.WriteLine($"{product} / {secondNumber}");
				var result = Console.ReadLine();

				result = Helpers.ValidationResult(result);


				if (int.Parse(result) == product / secondNumber)
				{
					Console.WriteLine("Your answer is correct! Type any key for next question");
					score++;
					Console.ReadLine();
				}

				else
				{
					Console.WriteLine("Your answer is incorrect. Type any key for next question");
					Console.ReadLine();
				}

			}

			Console.WriteLine(
				$"Game over. Your final score is {score}. Press any key to go back to main menu.");
			Console.ReadLine();
			Helpers.AddToHistory(score, GameType.Division);

		}


		internal void MediumDivisionGame()
		{
			Helpers.SetNumberOfQuestions();

			Console.Clear();
			var random = new Random();
			var score = 0;

			int firstNumber;
			int secondNumber;

			for (int j = 0; j < Helpers.GetNumberOfQuestions(); j++)
			{
				firstNumber = random.Next(10, 99);
				secondNumber = random.Next(10, 99);
				var product = firstNumber * secondNumber;

				Console.WriteLine($"{product} / {secondNumber}");
				var result = Console.ReadLine();

				result = Helpers.ValidationResult(result);

				if (int.Parse(result) == product / secondNumber)
				{
					Console.WriteLine("Your answer is correct! Type any key for next question");
					score++;
					Console.ReadLine();
				}

				else
				{
					Console.WriteLine("Your answer is incorrect. Type any key for next question");
					Console.ReadLine();
				}

			}

			Console.WriteLine(
				$"Game over. Your final score is {score}. Press any key to go back to main menu.");
			Console.ReadLine();
			Helpers.AddToHistory(score, GameType.Division);

		}


		internal void HardDivisionGame()
		{
			Helpers.SetNumberOfQuestions();

			Console.Clear();
			var random = new Random();
			var score = 0;

			int firstNumber;
			int secondNumber;

			for (int j = 0; j < Helpers.GetNumberOfQuestions(); j++)
			{
				firstNumber = random.Next(100, 999);
				secondNumber = random.Next(100, 999);
				var product = firstNumber * secondNumber;

				Console.WriteLine($"{product} / {secondNumber}");
				var result = Console.ReadLine();

				result = Helpers.ValidationResult(result);

				if (int.Parse(result) == product / secondNumber)
				{
					Console.WriteLine("Your answer is correct! Type any key for next question");
					score++;
					Console.ReadLine();
				}

				else
				{
					Console.WriteLine("Your answer is incorrect. Type any key for next question");
					Console.ReadLine();
				}

			}

			Console.WriteLine(
				$"Game over. Your final score is {score}. Press any key to go back to main menu.");
			Console.ReadLine();
			Helpers.AddToHistory(score, GameType.Division);

		}
	}
}
