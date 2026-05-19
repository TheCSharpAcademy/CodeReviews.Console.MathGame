using System.Diagnostics;

const int playGameMenu = 1;
const int viewScoresMenu = 2;
const int additionMenu = 1;
const int subtractionMenu = 2;
const int multiplicationMenu = 3;
const int divisionMenu = 4;
const int randomGameMenu = 5;
const int exitMenu = 9;
const int numberOfQuestions = 5;

int selectedMenu;
List<int> mainMenuNumbers = new List<int>{playGameMenu, viewScoresMenu, exitMenu};
List<string> mainMenuText = new List<string> {$"{playGameMenu} - Play the game", $"{viewScoresMenu} - View score"};
List<ScoreHistory> scoreHistory = new List<ScoreHistory>();

do
{
    ListMenu(mainMenuText);

    selectedMenu = GetSelectedMenu(mainMenuNumbers);

    switch (selectedMenu)
    {
        case playGameMenu:
            PlayGame();
            break;
        case viewScoresMenu:
            ListScores();
            break;
        case exitMenu:
            break;
        default:
            break;
    }

} while (selectedMenu != exitMenu);

void ListMenu(List<string> menuText)
{
    foreach (var menuElement in menuText)
    {
        System.Console.WriteLine(menuElement);
    }

    System.Console.WriteLine();
    System.Console.WriteLine($"{exitMenu} - Exit");
    System.Console.WriteLine();
    System.Console.Write("Please select a menu number: ");
}

void PlayGame()
{
    int currentScore = 0;
    Stopwatch stopWatch = new Stopwatch();

    List <string> operationMenuText = new List<string>
    {
        $"{additionMenu} - Addition",
        $"{subtractionMenu} - Subtraction",
        $"{multiplicationMenu} - Multiplication",
        $"{divisionMenu} - Division",
        $"{randomGameMenu} - Random(All of the above)"
    };
    List<int> operationMenuNumbers = new List<int> 
    {
        additionMenu, subtractionMenu, multiplicationMenu, divisionMenu, randomGameMenu, exitMenu
    };
    
    ListMenu(operationMenuText);

    int operationNumber = GetSelectedMenu(operationMenuNumbers);

    stopWatch.Start();

    if (operationNumber == randomGameMenu)
    {
        Random random = new Random();
        for (int i = 0; i < numberOfQuestions; i++)
        {
            operationNumber = random.Next(1, 5);
            OperationQuestion(operationNumber, ref currentScore);
        }
    }
    else
    {
        for (int i = 0; i < numberOfQuestions; i++)
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
        case additionMenu:
            numberFirst = random.Next(0, easyAdditionSubtractionDivisionMax);
            numberSecond = random.Next(0, easyAdditionSubtractionDivisionMax);

            System.Console.Write($"{numberFirst} + {numberSecond}?: ");
            correctAnswer = numberFirst + numberSecond;

            CheckAnswer(correctAnswer, ref currentScore);            
            break;
        case subtractionMenu:
            numberFirst = random.Next(0, easyAdditionSubtractionDivisionMax);
            numberSecond = random.Next(0, easyAdditionSubtractionDivisionMax);

            System.Console.Write($"{numberFirst} - {numberSecond}?: ");
            correctAnswer = numberFirst - numberSecond;

            CheckAnswer(correctAnswer, ref currentScore);  
            break;
        case multiplicationMenu:
            numberFirst = random.Next(0, easyMultiplicationMaxNumber1);
            numberSecond = random.Next(0, easyMultiplicationMaxNumber2);

            System.Console.Write($"{numberFirst} * {numberSecond}?: ");
            correctAnswer = numberFirst * numberSecond;

            CheckAnswer(correctAnswer, ref currentScore);  
            break;
        case divisionMenu:
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
        case exitMenu:
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
        System.Console.WriteLine($"Score of game #{i+1}: {scoreHistory[i].Score}/{numberOfQuestions} Time: {scoreHistory[i].FormatTime()}");
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