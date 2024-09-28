const int NumberOfRounds = 3;

var gameHistory = new List<string>();

// Entry point
Menu();

void PlayGame(string gameTitle, Func<int, int, int> operation, char operatorSymbol)
{
    int score = RunGameRounds(gameTitle, (first, second) =>
        operation(first, second), $"{operatorSymbol}");

    RecordGameResult(operatorSymbol, score);
    Menu();
}

void PlayDivisionGame()
{
    int score = RunGameRounds("Division game", (first, second) => first / second, "/");
    RecordGameResult('/', score);
    Menu();
}

int RunGameRounds(string gameTitle, Func<int, int, int> calculateResult, string operatorSymbol)
{
    int score = 0;
    var random = new Random();

    for (int round = 0; round < NumberOfRounds; round++)
    {
        Console.Clear();
        Console.WriteLine(gameTitle);

        var (firstNumber, secondNumber) = operatorSymbol == "/"
            ? GetValidDivisionPair(random)
            : (random.Next(1, 9), random.Next(1, 9));

        Console.WriteLine($"{firstNumber} {operatorSymbol} {secondNumber}");
        int userAnswer = GetValidIntegerInput();

        if (userAnswer == calculateResult(firstNumber, secondNumber))
        {
            Console.WriteLine("Your answer was correct! Press Enter to continue.");
            score++;
        }
        else
        {
            Console.WriteLine("Your answer was incorrect. Press Enter to continue.");
        }

        Console.ReadLine();

        if (round == NumberOfRounds - 1)
            Console.WriteLine($"Game over, your final score is {score}");
    }

    return score;
}

int GetValidIntegerInput()
{
    string input;
    while (!int.TryParse(input = Console.ReadLine(), out int parsedResult))
    {
        Console.WriteLine("Please enter a valid integer:");
    }
    return int.Parse(input);
}

(int, int) GetValidDivisionPair(Random random)
{
    int first, second;
    do
    {
        first = random.Next(1, 99);
        second = random.Next(1, 99);
    } while (first % second != 0);

    return (first, second);
}

void RecordGameResult(char operatorSymbol, int score)
{
    var gameType = operatorSymbol switch
    {
        '+' => "Addition",
        '-' => "Subtraction",
        '*' => "Multiplication",
        '/' => "Division",
        _ => "Unknown"
    };
    gameHistory.Add($"{DateTime.Now} - {gameType}: Score={score}");
}

void Menu()
{
    Console.Clear();
    Console.WriteLine(@"What would you like to play? Type one of the options below:
V - View previous games
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
    Console.WriteLine("------------------------");

    string choice = Console.ReadLine()?.ToUpper().Trim();

    switch (choice)
    {
        case "V":
            DisplayGameHistory();
            break;
        case "A":
            PlayGame("Addition Game", (a, b) => a + b, '+');
            break;
        case "S":
            PlayGame("Subtraction Game", (a, b) => a - b, '-');
            break;
        case "M":
            PlayGame("Multiplication Game", (a, b) => a * b, '*');
            break;
        case "D":
            PlayDivisionGame();
            break;
        case "Q":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid input. Press Enter to try again.");
            Console.ReadLine();
            Menu();
            break;
    }
}

void DisplayGameHistory()
{
    Console.Clear();
    Console.WriteLine("Previous games played:");
    if (gameHistory.Count == 0)
    {
        Console.WriteLine("No games have been played yet.");
    }
    else
    {
        foreach (var game in gameHistory)
        {
            Console.WriteLine(game);
        }
    }
    Console.WriteLine("------------------------\nPress Enter to return to the menu.");
    Console.ReadLine();
    Menu();
}
