namespace MathGame;

public class Game
{
	public static int QuestionsCount { get; set; } = 5;
	public static void Start()
	{
		while(true)
		{
			Menu.ShowMenu();

			ChooseOption();
			// PlayGame(choice, QuestionsCount);
		}
    }

	private static void ChooseOption()
	{
		string? choice;
		do
		{
			choice = Console.ReadLine();
			if (Helper.GetAllOperations().Any(op => op.Symbol == choice))
			{
				PlayGame(choice);
				return;
			}
			else if (choice == "q")
			{
				Environment.Exit(0);
			}
		} while (true);
	}

	private static void PlayGame(string? op)
	{
		int score = 0;

		for (int i = 0; i < QuestionsCount; i++)
		{
			int firstNum = Helper.GetRandomNumber(), secondNum = Helper.GetRandomNumber();

			if (op == "/")
				Helper.ModifyNumbersForDivision(ref firstNum, ref secondNum);

			Menu.ShowEquation(firstNum, secondNum, op);
			int userInput = Helper.GetUserInput(); 

			DetermineAnswer(firstNum, secondNum, userInput, op, ref score);
		}

		Menu.ShowScore(score, QuestionsCount);
	}

	private static void DetermineAnswer(int firstNum, int secondNum, int userInput, string? op, ref int score)
	{
		switch (op)
		{
			case "+":
				if (userInput == firstNum + secondNum)
				{
					score++;
					Menu.ShowFeedbackCorrect();
				}
				else
				{
					Menu.ShowFeedbackWrong();
				}
				break;
			case "-":
				if (userInput == firstNum - secondNum)
				{
					score++;
					Menu.ShowFeedbackCorrect();
				}
				else
				{
					Menu.ShowFeedbackWrong();
				}
				break;
			case "*":
				if (userInput == firstNum * secondNum)
				{
					score++;
					Menu.ShowFeedbackCorrect();
				}
				else
				{
					Menu.ShowFeedbackWrong();
				}
				break;
			case "/":
				if (userInput == firstNum / secondNum)
				{
					score++;
					Menu.ShowFeedbackCorrect();
				}
				else
				{
					Menu.ShowFeedbackWrong();
				}
				break;
		}
	}
}
