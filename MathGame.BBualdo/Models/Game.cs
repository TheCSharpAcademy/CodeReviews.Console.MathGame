using MathGame.BBualdo.enums;
using MathGame.BBualdo.Helpers;

namespace MathGame.BBualdo.Models;

internal class Game
{
  public GameTypes Type { get; set; }
  public DateTime Date { get; set; }
  public DifficultyLevels DifficultyLevel { get; set; }
  public int Score { get; set; }
  public int NumberOfQuestions { get; set; }
  public int TimeInSeconds { get; set; }
  public bool IsGameOn { get; set; }

  public Game()
  {
    Date = DateTime.Now;
  }

  public void Run(int maxValue)
  {
    Console.Clear();
    GameConsole.ShowTitle();
    GameConsole.ShowMessage(@$"{Type} Game
--------------------");

    GameTimer gameTimer = new GameTimer();
    gameTimer.EnableTimer();

    char? currentOperator = OperatorChecker.CheckOperators(Type);

    for (int i = 0; i < NumberOfQuestions; i++)
    {
      if (Type == GameTypes.Random)
      {
        // Generating new operator for each question
        currentOperator = OperatorChecker.CheckOperators(Type);
      }

      int num1;
      int num2;

      if (currentOperator == '/')
      {
        int[] nums = DivisionNumbers.GetDivisionNumbers(maxValue);
        num1 = nums[0];
        num2 = nums[1];
      }
      else
      {
        Random random = new Random();

        // Decreased maxValue by one decimal to avoid huge numbers in * (did the same for /)
        if (currentOperator == '*')
        {
          maxValue /= 10;
        }

        num1 = random.Next(1, maxValue);
        num2 = random.Next(1, maxValue);
      }

      GameConsole.ShowMessage($"{num1} {currentOperator} {num2} ?");

      string? userAnswer = Console.ReadLine();

      if (string.IsNullOrEmpty(userAnswer))
      {
        GameConsole.ShowError("Wrong answer!");
        continue;
      }

      bool isCorrect = false;

      if (int.TryParse(userAnswer, out int result))
      {
        switch (currentOperator)
        {
          case '+':
            isCorrect = result == num1 + num2; break;
          case '-':
            isCorrect = result == num1 - num2; break;
          case '*':
            isCorrect = result == num1 * num2; break;
          case '/':
            if (num2 != 0)
            {
              isCorrect = result == num1 / num2;
            }
            break;
          default:
            GameConsole.ShowError("Invalid operator");
            break;
        }
      }
      else
      {
        GameConsole.ShowError("Wrong answer! Only numbers can be correct answer!");
      }

      if (isCorrect)
      {
        GameConsole.ShowMessage("Correct answer!");
        Score++;
      }
      else
      {
        GameConsole.ShowError("Wrong answer!");
      }
    }

    gameTimer.DisableTimer();
    TimeInSeconds = gameTimer.TimeInSeconds;
    GameConsole.ShowMessage($"Game over! You answered correctly for {Score} out of {NumberOfQuestions} questions. Time elapsed: {TimeInSeconds}s");
    GameConsole.ShowMessage("Please press any key to go back to main menu.");
    Console.ReadKey();
    IsGameOn = false;
  }
}