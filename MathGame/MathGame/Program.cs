using MathGame;

bool exitGame = false;
string? input;
List<GameRecord> games = [];
const int NumberOfQuestionsPerGame = 5;
const int ScorePerQuestion = 10;
const int MaximumScore = ScorePerQuestion * NumberOfQuestionsPerGame;

do
{
    Console.WriteLine("Main menu");
    Console.WriteLine("Please select a game mode or type \"exit\" to close the app:");
    Console.WriteLine("1. Addition game");
    Console.WriteLine("2. Substraction game");
    Console.WriteLine("3. Multiplication game");
    Console.WriteLine("4. Division game");
    Console.WriteLine("5. View past games");

    bool validSelection;
    do
    {
        input = Console.ReadLine();
        bool inputNotEmpty = input != null && input.Length > 0;
        validSelection = true;

        if (inputNotEmpty)
        {
            string userSelection = input.ToLower();
            int score;
            switch (userSelection)
            {
                case "exit":
                    exitGame = true;
                    break;
                case "1":
                    Console.Clear();
                    score = Game(Operations.ADDITION);
                    games.Add(new GameRecord(score,DateTime.Now,"Addition"));
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    score = Game(Operations.SUBSTRACTION);
                    games.Add(new GameRecord(score, DateTime.Now, "Substraction"));
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    score = Game(Operations.MULTIPLICATION);
                    games.Add(new GameRecord(score, DateTime.Now, "Multiplication"));
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    score = Game(Operations.DIVISION);
                    games.Add(new GameRecord(score, DateTime.Now, "Division"));
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "5":
                    PrintResults(games);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid selection please try again.");
                    validSelection = false;
                    break;
            }
        }
    } while (!validSelection);
} while (!exitGame);

static void PrintResults(List<GameRecord> gameResults)
{
    string header = $"{"Date",-28} | {"Operation",-16} | {"Score",-8}";
    Console.WriteLine(header);
    Console.WriteLine(new String('-',header.Length));

    foreach (GameRecord gameRecord in gameResults)
    {
        string row = $"{gameRecord.EndGameTime,-28} | {gameRecord.OperationName,-16} | {gameRecord.Score,-8}";
        Console.WriteLine(row);
    }
}

static List<int> GetFactors(int num)
{
    List<int> factors = [];

    for (int i = 1; i <= num; i++)
    {
        if (num % i == 0)
        {
            factors.Add(i);
        }
    }

    return factors;
}

static int Game(Operations operation)
{
    int score = 0;
    char operationSymbol = ((char)operation);
    int minNumber = 1;
    int maxNumber = 9;

    Random random = new Random();

    for (int i = 0; i < NumberOfQuestionsPerGame; i++)
    {
        int number1 = random.Next(minNumber, maxNumber + 1);
        int number2;
        int expectedResult;
        switch (operation)
        {
            case Operations.ADDITION:
                number2 = random.Next(minNumber, maxNumber + 1);
                expectedResult = number1 + number2;
                break;
            case Operations.SUBSTRACTION:
                number2 = random.Next(minNumber, maxNumber + 1);
                expectedResult = number1 - number2;
                break;
            case Operations.MULTIPLICATION:
                number2 = random.Next(minNumber, maxNumber + 1);
                expectedResult = number1 * number2;
                break;
            case Operations.DIVISION:
                List<int> number1Factors = GetFactors(number1);
                int number2PositionInFactors = random.Next(0, number1Factors.Count);
                number2 = number1Factors[number2PositionInFactors];

                expectedResult = number1 / number2;
                break;
            default:
                number1 = 1;
                number2 = 1;
                expectedResult = 0;
                break;
        }

        Console.WriteLine($"Question {i + 1}/{NumberOfQuestionsPerGame}\nWhat is {number1} {operationSymbol} {number2} ?");

        string? input = Console.ReadLine();
        int userAnswer;

        while (input == null || input.Length == 0 || !int.TryParse(input, out userAnswer))
        {
            Console.WriteLine("Your answer must be an integer number.");
            input = Console.ReadLine();
        }

        if (userAnswer == expectedResult)
        {
            score += ScorePerQuestion;
        }
        Console.Clear();
    }

    Console.WriteLine($"Your score was {score}/{MaximumScore}");

    return score;
}
enum Operations
{
    ADDITION = '+',
    SUBSTRACTION = '-',
    MULTIPLICATION = '*',
    DIVISION = '/'
}