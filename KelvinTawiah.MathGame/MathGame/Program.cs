enum MathOperation
{
  Multiplication,
  Addition,
  Subtraction,
  Division
}

class Program
{
  private const int QUESTIONS_PER_GAME = 5;
  private const int MIN_DIGIT_LENGTH = 1;
  private const int MAX_DIGIT_LENGTH = 9;
  private const int DIVISION_MIN_DIVISOR = 1;
  private const int DIVISION_MAX_DIVISOR = 10;
  private const int DIVISION_MIN_QUOTIENT = 0;
  private const int DIVISION_MAX_QUOTIENT = 10;

  private static readonly Dictionary<MathOperation, (string Name, char Symbol)> OperationMetadata = new()
  {
    { MathOperation.Multiplication, ("Multiplication", '*') },
    { MathOperation.Addition, ("Addition", '+') },
    { MathOperation.Subtraction, ("Subtraction", '-') },
    { MathOperation.Division, ("Division", '/') }
  };

  private const string MENU_MULTIPLICATION = "M";
  private const string MENU_ADDITION = "A";
  private const string MENU_SUBTRACTION = "S";
  private const string MENU_DIVISION = "D";
  private const string MENU_HISTORY = "H";
  private const string MENU_EXIT = "X";

  private record GameResult(MathOperation Operation, int Correct, int TotalQuestions, DateTime PlayedAt);
  private static List<GameResult> history = new();
  private static readonly Random random = new();
  static void Main(string[] args)
  {
    PlayGame();
  }

  private static void PlayGame()
  {
    Console.WriteLine("Hey! Welcome to today math game. What would you like to practice today?🙃");
    while (true)
    {
      string menuChoice = GetMenuChoice();
      if (menuChoice == MENU_EXIT)
      {
        Console.WriteLine("Have a great day, buddy. See you soon!!!");
        return;
      }
      if (menuChoice == MENU_HISTORY)
      {
        ShowHistory();
        continue;
      }

      MathOperation operation = MenuChoiceToOperation(menuChoice);
      PlayGameSession(operation);
    }
  }

  private static void PlayGameSession(MathOperation operation)
  {
    int numLength = (operation != MathOperation.Division) ? GetNumberLength(operation) : 0;

    int correct = 0;
    for (int i = 1; i <= QUESTIONS_PER_GAME; i++)
    {
      var (firstNumber, secondNumber) = GenerateNumbers(operation, numLength);
      var (userAnswer, expectedAnswer) = AskQuestion(firstNumber, secondNumber, operation);

      bool isCorrect = userAnswer == expectedAnswer;
      if (isCorrect) correct++;

      DisplayQuestionResult(firstNumber, secondNumber, operation, userAnswer, expectedAnswer, isCorrect);
    }

    PersistGame(operation, correct, QUESTIONS_PER_GAME);
    Console.WriteLine($"Session complete: {OperationMetadata[operation].Name} — Score: {correct}/{QUESTIONS_PER_GAME}\n");
  }

  private static int GetNumberLength(MathOperation operation)
  {
    string? num;
    int res;
    do
    {
      Console.WriteLine($"Enter the number({MIN_DIGIT_LENGTH} - {MAX_DIGIT_LENGTH}) length for {OperationMetadata[operation].Name}. For instance 2 for 2 digit numbers");
      num = Console.ReadLine();
    } while (!int.TryParse(num, out res) || res < MIN_DIGIT_LENGTH || res > MAX_DIGIT_LENGTH);
    return res;
  }

  private static void PersistGame(MathOperation operation, int correct, int totalQuestions)
  {
    history.Add(new GameResult(operation, correct, totalQuestions, DateTime.Now));
  }

  private static (int, int) GenerateNumbers(MathOperation operation, int digitLength)
  {
    if (operation == MathOperation.Division)
    {
      int divisor = random.Next(DIVISION_MIN_DIVISOR, DIVISION_MAX_DIVISOR + 1);
      int quotient = random.Next(DIVISION_MIN_QUOTIENT, DIVISION_MAX_QUOTIENT + 1);
      int dividend = divisor * quotient;
      return (dividend, divisor);
    }
    else
    {
      int min = (int)Math.Pow(10, digitLength - 1);
      int max = (int)Math.Pow(10, digitLength);
      int firstNumber = random.Next(min, max);
      int secondNumber = random.Next(min, max);
      return (firstNumber, secondNumber);
    }
  }

  private static int CalculateAnswer(int firstNumber, int secondNumber, MathOperation operation)
  {
    return operation switch
    {
      MathOperation.Multiplication => firstNumber * secondNumber,
      MathOperation.Addition => firstNumber + secondNumber,
      MathOperation.Subtraction => firstNumber - secondNumber,
      MathOperation.Division => firstNumber / secondNumber,
      _ => throw new InvalidOperationException("Invalid operation")
    };
  }

  private static (int userAnswer, int expectedAnswer) AskQuestion(int firstNumber, int secondNumber, MathOperation operation)
  {
    int expectedAnswer = CalculateAnswer(firstNumber, secondNumber, operation);
    char symbol = OperationMetadata[operation].Symbol;

    int userAnswer;
    string? input;
    do
    {
      Console.Write($"{firstNumber} {symbol} {secondNumber} = ");
      input = Console.ReadLine();
    } while (!int.TryParse(input, out userAnswer));

    return (userAnswer, expectedAnswer);
  }

  private static void DisplayQuestionResult(int firstNumber, int secondNumber, MathOperation operation, int userAnswer, int expectedAnswer, bool isCorrect)
  {
    char symbol = OperationMetadata[operation].Symbol;
    string result = isCorrect ? "Correct" : "Wrong";
    Console.WriteLine($"{firstNumber} {symbol} {secondNumber} => Your Answer: {userAnswer}, Expected: {expectedAnswer} => {result}");
  }

  private static void ShowHistory()
  {
    if (history.Count == 0)
    {
      Console.WriteLine("No previous games recorded.");
      return;
    }

    for (var i = 0; i < history.Count; i++)
    {
      var h = history[i];
      Console.WriteLine($"{i + 1}. {OperationMetadata[h.Operation].Name} — Score: {h.Correct}/{h.TotalQuestions} — Played: {h.PlayedAt}");
    }
  }

  private static string GetMenuChoice()
  {
    HashSet<string> validChoices = [MENU_MULTIPLICATION, MENU_DIVISION, MENU_ADDITION, MENU_SUBTRACTION, MENU_HISTORY, MENU_EXIT];
    string? choice;
    do
    {
      Console.WriteLine("Enter M: Multiplication, S: Subtraction, A: Addition, D: Division, H: View History, or X: Exit Program");
      choice = Console.ReadLine();
    } while (!validChoices.Contains(choice ?? "") || choice == null);
    return choice!;
  }

  private static MathOperation MenuChoiceToOperation(string menuChoice)
  {
    return menuChoice switch
    {
      MENU_MULTIPLICATION => MathOperation.Multiplication,
      MENU_ADDITION => MathOperation.Addition,
      MENU_SUBTRACTION => MathOperation.Subtraction,
      MENU_DIVISION => MathOperation.Division,
      _ => throw new InvalidOperationException($"Invalid menu choice: {menuChoice}")
    };
  }
}