using MyFirstProgram.Models;
using MyFirstProgram;
namespace MathGame
{
	internal class SubtractionEngine
	{
		internal void EasySubtractionGame()
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

				Console.WriteLine($"{firstNumber} - {secondNumber}");
				var result = Console.ReadLine();

				result = Helpers.ValidationResult(result);

				if (int.Parse(result) == firstNumber - secondNumber)
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
			Helpers.AddToHistory(score, GameType.Subtraction);
		}


		internal void MediumSubtractionGame()
		{
			Console.Clear();
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

				Console.WriteLine($"{firstNumber} - {secondNumber}");
				var result = Console.ReadLine();

				result = Helpers.ValidationResult(result);

				if (int.Parse(result) == firstNumber - secondNumber)
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
			Helpers.AddToHistory(score, GameType.Subtraction);


		}

		internal void HardSubtractionGame()
		{
			Console.Clear();
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

				Console.WriteLine($"{firstNumber} - {secondNumber}");
				var result = Console.ReadLine();

				result = Helpers.ValidationResult(result);

				if (int.Parse(result) == firstNumber - secondNumber)
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
			Helpers.AddToHistory(score, GameType.Subtraction);

		}
	}
}
