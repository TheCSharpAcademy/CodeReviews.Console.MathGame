using System.Diagnostics;

const int PlayGameMenu = 1;
const int ViewScoresMenu = 2;
const int AdditionMenu = 1;
const int SubtractionMenu = 2;
const int MultiplicationMenu = 3;
const int DivisionMenu = 4;
const int RandomGameMenu = 5;
const int ExitMenu = 9;
const int NumberOfQuestions = 5;

int selectedMenu;
List<int> mainMenuNumbers = new List<int>{PlayGameMenu, ViewScoresMenu, ExitMenu};
List<string> mainMenuText = new List<string> {$"{PlayGameMenu} - Play the game", $"{ViewScoresMenu} - View score"};
List<ScoreHistory> scoreHistory = new List<ScoreHistory>();

do
{
    ListMenu(mainMenuText);

    selectedMenu = GetSelectedMenu(mainMenuNumbers);

    switch (selectedMenu)
    {
        case PlayGameMenu:
            PlayGame();
            break;
        case ViewScoresMenu:
            ListScores();
            break;
        case ExitMenu:
            break;
        default:
            break;
    }

} while (selectedMenu != ExitMenu);

void ListMenu(List<string> menuText)
{
    foreach (var menuElement in menuText)
    {
        System.Console.WriteLine(menuElement);
    }

    System.Console.WriteLine();
    System.Console.WriteLine($"{ExitMenu} - Exit");
    System.Console.WriteLine();
    System.Console.Write("Please select a menu number: ");
}

void PlayGame()
{
    int currentScore = 0;
    Stopwatch stopWatch = new Stopwatch();

    List <string> operationMenuText = new List<string>
    {
        $"{AdditionMenu} - Addition",
        $"{SubtractionMenu} - Subtraction",
        $"{MultiplicationMenu} - Multiplication",
        $"{DivisionMenu} - Division",
        $"{RandomGameMenu} - Random(All of the above)"
    };
    List<int> operationMenuNumbers = new List<int> 
    {
        AdditionMenu, SubtractionMenu, MultiplicationMenu, DivisionMenu, RandomGameMenu, ExitMenu
    };
    
    ListMenu(operationMenuText);

    int operationNumber = GetSelectedMenu(operationMenuNumbers);

    stopWatch.Start();

    if (operationNumber == RandomGameMenu)
    {
        Random random = new Random();
        for (int i = 0; i < NumberOfQuestions; i++)
        {
            operationNumber = random.Next(1, 5);
            OperationQuestion(operationNumber, ref currentScore);
        }
    }
    else
    {
        for (int i = 0; i < NumberOfQuestions; i++)
            OperationQuestion(operationNumber, ref currentScore);
    }

    stopWatch.Stop();

    scoreHistory.Add(new ScoreHistory { Score = currentScore, Time =  stopWatch.Elapsed});
    ListScores(scoreHistory.Count - 1);
}

void OperationQuestion(int operationNumber, ref int currentScore)
{
    Random random = new Random();
    const int easyAdditionSubtractionDivisionMax = 101;
    const int easyMultiplicationMaxNumber1 = 21;
    const int easyMultiplicationMaxNumber2 = 11;
    int numberFirst;
    int numberSecond;
    int correctAnswer;

    switch (operationNumber)
    {
        case AdditionMenu:
            numberFirst = random.Next(0, easyAdditionSubtractionDivisionMax);
            numberSecond = random.Next(0, easyAdditionSubtractionDivisionMax);

            System.Console.Write($"{numberFirst} + {numberSecond}?: ");
            correctAnswer = numberFirst + numberSecond;

            CheckAnswer(correctAnswer, ref currentScore);            
            break;
        case SubtractionMenu:
            numberFirst = random.Next(0, easyAdditionSubtractionDivisionMax);
            numberSecond = random.Next(0, easyAdditionSubtractionDivisionMax);

            System.Console.Write($"{numberFirst} - {numberSecond}?: ");
            correctAnswer = numberFirst - numberSecond;

            CheckAnswer(correctAnswer, ref currentScore);  
            break;
        case MultiplicationMenu:
            numberFirst = random.Next(0, easyMultiplicationMaxNumber1);
            numberSecond = random.Next(0, easyMultiplicationMaxNumber2);

            System.Console.Write($"{numberFirst} * {numberSecond}?: ");
            correctAnswer = numberFirst * numberSecond;

            CheckAnswer(correctAnswer, ref currentScore);  
            break;
        case DivisionMenu:
            numberFirst = random.Next(0, easyAdditionSubtractionDivisionMax);
            numberSecond = random.Next(1, numberFirst + 1);

            while (numberFirst % numberSecond != 0)
            {
                numberSecond = random.Next(1, numberFirst + 1);
            }

            System.Console.Write($"{numberFirst} / {numberSecond}?: ");
            correctAnswer = numberFirst / numberSecond;

            CheckAnswer(correctAnswer, ref currentScore);
            break;
        case ExitMenu:
            break;
        default:
            break;
    }
}

void CheckAnswer(int correctAnswer, ref int currentScore)
{
    string? input = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(input) && Int32.TryParse(input, out int number) && number == correctAnswer)
    {
        System.Console.WriteLine($"Correct! The answer is {correctAnswer}.\n");
        currentScore += 1;
    }
    else
        System.Console.WriteLine($"Incorrect! The answer is {correctAnswer}.\n");
}

void ListScores(int startScoreIndex = 0)
{
    for (int i = startScoreIndex; i < scoreHistory.Count; i++)
    {
        System.Console.WriteLine($"Score of game #{i+1}: {scoreHistory[i].Score}/{NumberOfQuestions} Time: {scoreHistory[i].FormatTime()}");
    }
    System.Console.WriteLine();
}

int GetSelectedMenu(List<int> validMenuNumbers)
{
    string? input = Console.ReadLine();
    int number;
    
    while (String.IsNullOrWhiteSpace(input) || !Int32.TryParse(input, out number) || !validMenuNumbers.Contains(number))
    {
        System.Console.Write("Please select a menu number: ");
        input = Console.ReadLine();
    }

    return number;
}