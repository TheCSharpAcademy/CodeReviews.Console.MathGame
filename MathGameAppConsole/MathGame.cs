public class MathGame
{
	public MathGame()
	{
		bool playAgain = true;

		this.Game(playAgain);
	}

	private void Game(bool again)
	{
        List<string> gameHistory = new List<string>();

        while (again)
		{
            Console.WriteLine("\nChoose an operation:");
            Console.WriteLine("1 - Addition");
            Console.WriteLine("2 - Subtraction");
            Console.WriteLine("3 - Multiplication");
            Console.WriteLine("4  - Division");
            Console.WriteLine("5 - Exit");

			string choice = Console.ReadLine();

			if (choice == "5" || !again)
			{
				again = false;
				continue;
			}
			
			Random random = new Random();
			int number1 = random.Next(1, 101);
			int number2 = random.Next(1, 101);
			int correctAnswer = 0;
			string operation = "";

            switch (choice)
            {
                case "1":
                    operation = "+";
                    correctAnswer = number1 + number2;
                    break;
                case "2":
                    operation = "-";
                    correctAnswer = number1 - number2;
                    break;
                case "3":
                    operation = "*";
                    correctAnswer = number1 * number2;
                    break;
                case "4":
                    // Generate numbers until the division is exact
                    while (number1 % number2 != 0)
                    {
                        number1 = random.Next(1, 101);
                        number2 = random.Next(1, 101);
                    }
                    operation = "/";
                    correctAnswer = number1 / number2;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            Console.WriteLine($"\nWhat is {number1} {operation} {number2}?");
            string userAnswer = Console.ReadLine();

            int answer;
            if (int.TryParse(userAnswer, out answer) && answer == correctAnswer)
            {
                Console.WriteLine("Correct answer!");
                gameHistory.Add($"{number1} {operation} {number2} = {correctAnswer} (Correct)");
            }
            else
            {
                Console.WriteLine($"Wrong answer. The correct answer is {correctAnswer}.");
                gameHistory.Add($"{number1} {operation} {number2} = {correctAnswer} (Wrong)");
            }

            Console.WriteLine("\n5 - View game history");
            Console.WriteLine("Do you want to play again? (y/n)");
            string playAgainResponse = Console.ReadLine();

            if (playAgainResponse == "5")
            {
                ShowHistoryGame(gameHistory);
                Console.WriteLine("\nDo you want to play again? (y/n)");
                playAgainResponse = Console.ReadLine();
            }

            again = playAgainResponse.ToLower() == "y";
        }
    }

	private void ShowHistoryGame(List<string> gameHistory)
	{
        Console.WriteLine("\nGame History:\n");
		if (gameHistory.Count == 0)
		{
            Console.WriteLine("No games recorded. :(");
        }
		else
		{
            foreach (var game in gameHistory)
            {
                Console.WriteLine(game);
            }
        }
    }
}
