namespace MathGame {
  public class GameLogic {
    public List<string> GameHistory { get; set; } = new List<string>();

    public enum MathOperation
    {
      Addition,
      Subtraction,
      Multiplication,
      Division
    }

    public enum Difficulty
    {
      Easy,
      Medium,
      Hard
    }

    private int[] GenerateNumbers(Difficulty difficulty, MathOperation operation)
    {
      var rng = new Random();
      int maxValue;
      int[] operands = new int[2];

      switch (difficulty)
      {
        case Difficulty.Easy:
          maxValue = 20;
          break;
        case Difficulty.Medium:
          maxValue = 50;
          break;
        case Difficulty.Hard:
          maxValue = 100;
          break;
        default:
          return operands;
      }

      if (operation == MathOperation.Division)
      {
        operands[1] = (int)rng.NextInt64(100) + 1;
        operands[0] = (int)((rng.NextInt64(maxValue)+1) * operands[1]);
      }
      else
      {
        operands[0] = (int)rng.NextInt64(maxValue+1);
        operands[1] = (int)rng.NextInt64(maxValue+1);
      }

      return operands;
    }

    public void NewGame()
    {
      Console.Clear();
      //Get difficulty input
      Console.WriteLine("Please select a difficulty:");
      Console.WriteLine("[1] Easy");
      Console.WriteLine("[2] Medium");
      Console.WriteLine("[3] Hard");
      Console.WriteLine("[anykey] Exit Current Game");
      Difficulty difficulty;
      var input = Console.ReadKey();
      int score = 0;
      Console.WriteLine();

      switch (input.KeyChar)
      {
        case '1':
          difficulty = Difficulty.Easy;
          break;
        case '2':
          difficulty = Difficulty.Medium;
          break;
        case '3':
          difficulty = Difficulty.Hard;
          break;
        default:
          return;
      }

      Console.Clear();
      //Get operation input
      Console.WriteLine("Please select an operation:");
      Console.WriteLine("[1] Addition");
      Console.WriteLine("[2] Subtraction");
      Console.WriteLine("[3] Multiplication");
      Console.WriteLine("[4] Division");
      Console.WriteLine("[anykey] Exit Current Game");
      MathOperation operation;
      input = Console.ReadKey();
      Console.WriteLine();

      switch (input.KeyChar)
      {
        case '1':
          operation = MathOperation.Addition;
          break;
        case '2':
          operation = MathOperation.Subtraction;
          break;
        case '3':
          operation = MathOperation.Multiplication;
          break;
        case '4':
          operation = MathOperation.Division;
          break;
        default:
          return;
      };
      
      var opSign = operation switch
      {
        MathOperation.Addition => "+",
        MathOperation.Subtraction => "-",
        MathOperation.Multiplication => "*",
        MathOperation.Division => "/",
        _ => throw new ArgumentException("Invalid Operation")
      };

      for(int i = 0; i < 5; i++)
      {
        int[] operands = GenerateNumbers(difficulty, operation);

        string question = $"{operands[0]} {opSign} {operands[1]}";
        Console.WriteLine(question);
        var response = Console.ReadLine();

        int answer = operation switch
        {
          MathOperation.Addition => operands[0] + operands[1],
          MathOperation.Subtraction => operands[0] - operands[1],
          MathOperation.Multiplication => operands[0] * operands[1],
          MathOperation.Division => operands[0] / operands[1],
          _ => throw new ArgumentException("Invalid operation")
        };

        if (int.Parse(response) == answer)
        {
          score++;
          Console.WriteLine($"Correct! Your score is now {score}/{i+1}");
          GameHistory.Add(question + $" = {answer}");
        } else
        {
          Console.WriteLine($"Whoops! The correct answer was {answer}. Your score is now {score}/{i+1}");
          GameHistory.Add(question + $" =/= {response}\tINCORRECT");
        }

        if(i != 4) {
          for(int j = 3; j > 0; j--)
          {
            Console.Write($"\rNext question in {j}...");
            Thread.Sleep(700);
          }
        }
        Console.Clear();
      }

      Console.WriteLine($"You got {score}/5 questions correct.");
    }
  }
}