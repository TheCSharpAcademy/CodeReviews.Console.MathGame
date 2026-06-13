// Create welcome message
Console.WriteLine("Please enter your name: ");
string? name = Console.ReadLine();
string? result;
string? menuSelection = "";
var gameHistory = new List<string>();

do
{
    var date = DateTime.UtcNow;
    // Clear Old Console Messages
    Console.Clear();

    Console.WriteLine(@$"Hello, welcome {name}, right now it is {date}
Welcome to the most simple Math Game you can ever find!");
    Console.WriteLine("\n");

    Console.WriteLine(@"Currently, we have these games. What game would you want to play? Pick one from the options below: 
    1 - Addition
    2 - Subtraction
    3 - Multiplication
    4 - Division
    H - View The History Of Games played
    Exit (or exit) - Exit The Game");

    result = Console.ReadLine();

    if (result != null)
    {
        menuSelection = result.Trim().ToLower();
    }

    switch (menuSelection)
    {
        case "1":
            PlayAdditionGame(numberOfQuestion: 6);
            break;
        case "2":
            PlaySubtractionGame();
            break;
        case "3":
            PlayMultiplicationGame();
            break;
        case "4":
            PlayDivisionGame();
            break;
        case "r":
            //PlayAdditionGame();
            break;
        case "h":
            ShowGameHistory();
            break;
        default:
            if (menuSelection != "exit")
            {
                Console.WriteLine("Invalid input, press Enter to try again");
                result = Console.ReadLine();
            }
            break;
    }
}
while (menuSelection != "exit");
Console.WriteLine("Thank you for playing our game");

// Methods:
int[] GetNumbers()
{
    var random = new Random();
    int num1 = random.Next(1, 9);
    int num2 = random.Next(1, 9);
    var result = new int[2];

    result[0] = num1;
    result[1] = num2;

    return result;
}

int[] GetDivisionNumbers()
{
    var random = new Random();
    int num1 = random.Next(1, 99);
    int num2 = random.Next(1, 99);
    var result = new int[2];

    while (num1 % num2 != 0)
    {
        num1 = random.Next(1, 99);
        num2 = random.Next(1, 99);
    }

    result[0] = num1;
    result[1] = num2;

    return result;
}

int CorrectValueType(string? userInput)
{
    bool lmao = false;
    int userGuess = 0;
    // Handle situation where user typed incorrect data type
    while (lmao == false)
    {
        if (int.TryParse(userInput, out userGuess) == false)
        {
            Console.WriteLine("We accept number only. Try again");
            userInput = Console.ReadLine();
        }
        else
        {
            lmao = true;
        }
    }
    return userGuess;
}

void ShowGameHistory()
{
    Console.Clear();
    Console.WriteLine("Game History for this session: ");
    Console.WriteLine("------------------");
    if (gameHistory.Count == 0)
    {
        Console.WriteLine("History is empty, play some games and come back later");
    }
    else
    {
        foreach (var game in gameHistory)
        {
            Console.WriteLine(game);
        }
    }
    Console.WriteLine("------------------\n");
    BackToMenu();
}

void BackToMenu()
{
    Console.WriteLine("Press Enter to continue");
    result = Console.ReadLine();
}

void PlayAdditionGame(int numberOfQuestion = 5)
{
    var score = 0;
    var questionLeft = numberOfQuestion;

    for (int i = 0; i < numberOfQuestion; i++)
    {
        int[] numbers = GetNumbers();
        int userGuess = 0;
        var firstNumber = numbers[0];
        var secondNumber = numbers[1];

        Console.Clear();
        Console.WriteLine("Addition Game");
        Console.WriteLine($"What is the result of {firstNumber} + {secondNumber}");
        result = Console.ReadLine();
        userGuess = CorrectValueType(result);

        if (userGuess == firstNumber + secondNumber)
        {
            --questionLeft;
            Console.WriteLine($"Your anwser is correct! You have {questionLeft} question left.");
            score++;
            BackToMenu();
        }
        else
        {
            --questionLeft;
            Console.WriteLine($"Your anwser is incorrect! You have {questionLeft} question left.");
            BackToMenu();
        }
        if (i == numberOfQuestion - 1)
        {
            Console.WriteLine($"Game over. Your final score is {score}");
            BackToMenu();
        }
    }
    gameHistory.Add($"{DateTime.Now} - Addition Game: Score = {score}");
}

void PlaySubtractionGame(int numberOfQuestion = 5)
{
    var score = 0;
    var questionLeft = numberOfQuestion;

    for (int i = 0; i < numberOfQuestion; i++)
    {
        int[] numbers = GetNumbers();
        int userGuess = 0;
        var firstNumber = numbers[0];
        var secondNumber = numbers[1];

        Console.Clear();
        Console.WriteLine("Subtraction Game");
        Console.WriteLine($"What is the result of {firstNumber} - {secondNumber}");
        result = Console.ReadLine();
        userGuess = CorrectValueType(result);

        if (userGuess == firstNumber - secondNumber)
        {
            questionLeft--;
            Console.WriteLine($"Your anwser is correct! You have {questionLeft} question left.");
            score++;
            BackToMenu();
        }
        else
        {
            questionLeft--;
            Console.WriteLine($"Your anwser is incorrect! You have {questionLeft} question left.");
            BackToMenu();
        }
        if (i == numberOfQuestion - 1)
        {
            Console.WriteLine($"Game over. Your final score is {score}");
            BackToMenu();
        }
    }
    gameHistory.Add($"{DateTime.Now} - Subtraction Game: Score = {score}");

}

void PlayMultiplicationGame(int numberOfQuestion = 5)
{
    var score = 0;
    var questionLeft = numberOfQuestion;

    for (int i = 0; i < numberOfQuestion; i++)
    {
        int[] numbers = GetNumbers();
        int userGuess = 0;
        var firstNumber = numbers[0];
        var secondNumber = numbers[1];

        Console.Clear();
        Console.WriteLine("Multiplication Game");
        Console.WriteLine($"What is the result of {firstNumber} * {secondNumber}");
        result = Console.ReadLine();
        userGuess = CorrectValueType(result);

        if (userGuess == firstNumber * secondNumber)
        {
            Console.WriteLine($"Your anwser is correct! You have {questionLeft} question left.");
            score++;
            BackToMenu();
        }
        else
        {
            Console.WriteLine($"Your anwser is incorrect! You have {questionLeft} question left.");
            BackToMenu();
        }
        if (i == numberOfQuestion - 1)
        {
            Console.WriteLine($"Game over. Your final score is {score}");
            BackToMenu();
        }
    }
    gameHistory.Add($"{DateTime.Now} - Multiplication Game: Score = {score}");
}

void PlayDivisionGame(int numberOfQuestion = 5)
{
    var score = 0;
    var questionLeft = numberOfQuestion;

    for (int i = 0; i < numberOfQuestion; i++)
    {
        int[] numbers = GetDivisionNumbers();
        int userGuess = 0;
        var firstNumber = numbers[0];
        var secondNumber = numbers[1];

        Console.Clear();
        Console.WriteLine("Division Game");
        Console.WriteLine($"What is the result of {firstNumber} / {secondNumber}");
        result = Console.ReadLine();
        userGuess = CorrectValueType(result);

        if (userGuess == firstNumber / secondNumber)
        {
            Console.WriteLine($"Your anwser is correct! You have {questionLeft} question left.");
            score++;
            BackToMenu();
        }
        else
        {
            Console.WriteLine($"Your anwser is incorrect! You have {questionLeft} question left.");
            BackToMenu();
        }
        if (i == numberOfQuestion - 1)
        {
            Console.WriteLine($"Game over. Your final score is {score}");
            BackToMenu();
        }
    }
    gameHistory.Add($"{DateTime.Now} - Division Game: Score = {score}");
}
