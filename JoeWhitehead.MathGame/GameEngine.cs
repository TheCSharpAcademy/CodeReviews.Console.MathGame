using ConsoleMathsGame.Models;

namespace ConsoleMathsGame
{
	internal class GameEngine
	{
		internal void RunGame(GameType gameType, Difficulty difficulty, int rounds)
		{			
			char operation = Helpers.GetOperator(gameType);
			string timeElapsed;
			int firstNumber;
			int secondNumber;
			int score = 0;
			DateTime start = DateTime.Now;
			DateTime end;
			
			for (int i = 0; i < rounds; i++)
			{
				Console.Clear();
				int[] numbers = Helpers.GetNumbers(gameType, difficulty);
				firstNumber = numbers[0];
				secondNumber = numbers[1];
				Console.WriteLine($"""
                 Game: {gameType}
                 Level: {difficulty} 
                 Rounds: {rounds}
                 """);
				Console.WriteLine($"{firstNumber} {operation} {secondNumber}");
				string? result = Console.ReadLine();
				result = Helpers.ValidateResult(result);

				if (int.Parse(result) == operation switch
				{
					'+' => firstNumber + secondNumber,
					'-' => firstNumber - secondNumber,
					'*' => firstNumber * secondNumber,
					'/' => firstNumber / secondNumber,
					_ => throw new NotImplementedException()
				})
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Correct!");
					Console.ResetColor();
					Console.WriteLine("Press any key for the next question");
					Console.ReadKey(true);
					score++;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Incorrect");
					Console.ResetColor();
					Console.WriteLine("Press any key for the next question");
					Console.ReadKey(true);
				}

				if (i == rounds -1)
				{
					Console.WriteLine($"Game Over - Your final score is: {score}");
					Console.WriteLine("Press any key to go back to the main menu");
					Console.ReadKey(true);
					Console.Clear();
				}
			}
			end = DateTime.Now;
			timeElapsed = Helpers.TimeElapsed(start, end);
			Helpers.AddToHistory(score, gameType, difficulty, timeElapsed, rounds);
		}		
	}
}
