using System.Diagnostics;

namespace MathGame;

public class Game
{
	public static int QuestionsCount { get; set; } = 5;
	public static int Difficulty { get; set; }
	public static List<History> GameHistory = new List<History>();

	public static void Start()
	{
		while(true)
		{
			ChooseOption();
		}
    }

	private static void ChooseOption()
	{
		string? option;
		do
		{
			Menu.ShowMenu();
			option = Console.ReadLine();

            if (option == "r")
			{
				Menu.Clear();
				UpdatePreGameOptions();

				Stopwatch watch = Stopwatch.StartNew();
				PlayRandomGame();
				watch.Stop();

				Menu.ShowElapsedTime(watch.ElapsedMilliseconds);
				return;
			}
			else if (option == "n")
			{
				Menu.ShowOperators();

				string? choice;
				choice = Console.ReadLine();
				if (Helper.GetAllOperators().Any(op => op.Symbol == choice))
				{
					UpdatePreGameOptions();

					Stopwatch watch = Stopwatch.StartNew();
					PlayNormalGame(choice);
					watch.Stop();

					Menu.ShowElapsedTime(watch.ElapsedMilliseconds);

					return;
				}
			}
			else if (option == "q")
			{
				Environment.Exit(0);
			}
			else if (option == "l")
			{
				Menu.ShowHistory(GameHistory);
				return;
			}
		} while (true);
	}

	private static void UpdatePreGameOptions()
	{
		QuestionsCount = Helper.GetNumberInput("Enter number of questions:");
		Difficulty = Helper.GetDifficultyInput();
	}

	private static void PlayNormalGame(string? op)
	{
		int score = 0;

		for (int i = 0; i < QuestionsCount; i++)
		{
			int firstNum = Helper.GetRandomNumber((Difficulty)Difficulty), secondNum = Helper.GetRandomNumber((Difficulty)Difficulty);

			if (op == "/")
				Helper.ModifyNumbersForDivision(ref firstNum, ref secondNum, (Difficulty)Difficulty);

			Menu.ShowEquation(firstNum, secondNum, op);
			int userInput = Helper.GetNumberInput(); 

			DetermineAnswer(firstNum, secondNum, userInput, op, ref score);
		}

		Menu.ShowScore(score, QuestionsCount);
		GameHistory.Add(new History
		{
			Operator = op,
			DateTime = DateTime.Now,
			Score = score
		});
	}

	private static void PlayRandomGame()
	{
		int score = 0;

		List<Operator> allOperators = Helper.GetAllOperators();
		int randIdx = new Random().Next(allOperators.Count);
		string op = allOperators[randIdx].Symbol;

		for (int i = 0; i < QuestionsCount; i++)
		{
			int firstNum = Helper.GetRandomNumber((Difficulty)Difficulty), secondNum = Helper.GetRandomNumber((Difficulty)Difficulty);

			if (op == "/")
				Helper.ModifyNumbersForDivision(ref firstNum, ref secondNum, (Difficulty)Difficulty);

			Menu.ShowEquation(firstNum, secondNum, op);
			int userInput = Helper.GetNumberInput();

			DetermineAnswer(firstNum, secondNum, userInput, op, ref score);
		}

		Menu.ShowScore(score, QuestionsCount);
		GameHistory.Add(new History
		{
			Operator = op,
			DateTime = DateTime.Now,
			Score = score
		});
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
