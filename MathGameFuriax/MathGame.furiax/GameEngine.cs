using MathGame.furiax.Models;

namespace MathGame.furiax
{
	internal class GameEngine
	{
		internal void AdditionGame(string message)
		{
			var random = new Random();
			var score = 0;

			int firstNumber;
			int secondNumber;

			for (int i = 0; i < 5; i++)
			{
				Console.Clear();
				Console.WriteLine(message);

				firstNumber = random.Next(1, 9);
				secondNumber = random.Next(1, 9);

				Console.Write($"{firstNumber} + {secondNumber} = ");
				var result = Console.ReadLine();
				result = Helpers.ValidateResult(result);


				if (int.Parse(result) == firstNumber + secondNumber)
				{
					Console.WriteLine("Your answer is correct. Type any key for the next question");
					score++;
					Console.ReadLine();
				}
				else
				{
					Console.WriteLine("Your answer is incorrect. Type any key for the next question");
					Console.ReadLine();
				}
				if (i == 4)
				{
					Console.WriteLine($"Game finished, your score is: {score}/5");
					Console.WriteLine("Press any key to go back to the main menu.");
					Console.ReadLine();
				}
			}

			Helpers.AddToHistory(score, GameType.Addition);
		}
		internal void SubstractionGame(string message)
		{
			var random = new Random();
			var score = 0;

			int firstNumber;
			int secondNumber;

			for (int i = 0; i < 5; i++)
			{
				Console.Clear();
				Console.WriteLine(message);

				firstNumber = random.Next(1, 9);
				secondNumber = random.Next(1, 9);

				Console.Write($"{firstNumber} - {secondNumber} = ");
				var result = Console.ReadLine();
				result = Helpers.ValidateResult(result);

				if (int.Parse(result) == firstNumber - secondNumber)
				{
					Console.WriteLine("Your answer is correct. Type any key for the next question");
					score++;
					Console.ReadLine();
				}
				else
				{
					Console.WriteLine("Your answer is incorrect. Type any key for the next question");
					Console.ReadLine();
				}
				if (i == 4) Console.WriteLine($"Game finished, your score is: {score}/5");
			}
			Helpers.AddToHistory(score, GameType.Subtraction);
		}
		internal void MultiplicationGame(string message)
		{
			var random = new Random();
			var score = 0;

			int firstNumber;
			int secondNumber;

			for (int i = 0; i < 5; i++)
			{
				Console.Clear();
				Console.WriteLine(message);

				firstNumber = random.Next(1, 9);
				secondNumber = random.Next(1, 9);

				Console.Write($"{firstNumber} * {secondNumber} = ");
				var result = Console.ReadLine();
				result = Helpers.ValidateResult(result);

				if (int.Parse(result) == firstNumber * secondNumber)
				{
					Console.WriteLine("Your answer is correct. Type any key for the next question");
					score++;
					Console.ReadLine();
				}
				else
				{
					Console.WriteLine("Your answer is incorrect. Type any key for the next question");
					Console.ReadLine();
				}
				if (i == 4) Console.WriteLine($"Game finished, your score is: {score}/5");
			}
			Helpers.AddToHistory(score, GameType.Multiplication);
		}
		internal void DivisionGame(string message)
		{
			var score = 0;
			for (int i = 0; i < 5; i++)
			{
				Console.Clear();
				Console.WriteLine(message);

				var divisionNumbers = Helpers.GetDivisionNumbers();
				var firstNumber = divisionNumbers[0];
				var secondNumber = divisionNumbers[1];

				Console.Write($"{firstNumber} / {secondNumber} = ");
				var result = Console.ReadLine();
				result = Helpers.ValidateResult(result);

				if (int.Parse(result) == firstNumber / secondNumber)
				{
					Console.WriteLine("Your answer is correct. Type any key for the next question");
					score++;
					Console.ReadLine();
				}
				else
				{
					Console.WriteLine("Your answer is incorrect. Type any key for the next question");
					Console.ReadLine();
				}
				if (i == 4) Console.WriteLine($"Game finished, your score is: {score}/5");
			}
			Helpers.AddToHistory(score, GameType.Division);
		}
	}
}
