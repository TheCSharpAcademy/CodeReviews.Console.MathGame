using static System.Formats.Asn1.AsnWriter;

DateTime date = DateTime.UtcNow;

List<string> games = new();

string? name = GetName();

Menu(name);

string? GetName()
{
    Console.WriteLine("Please type your name");

    string? name = Console.ReadLine();
    return name;
}

void GetGames()
{
    Console.Clear();
    Console.WriteLine("Games History\n--------------------------------------------------------------");
    foreach (var game in games)
    {
        Console.WriteLine(game);
    }
    Console.WriteLine("--------------------------------------------------------------\n");
    Console.WriteLine("Press any key to return to the Main Menu:");
    Console.ReadLine();
}

void AddToHistory(int gameScore, string gameType)
{
    games.Add($"{DateTime.Now} - {gameType}: {gameScore}pts");
}

void AdditionGame(string message)
{
    Random random = new();
    int score = 0;
    int firstNumber;
    int secondNumber;

    for (int i = 1; i <= 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);
        int result = firstNumber + secondNumber;

        Console.WriteLine($"{firstNumber} + {secondNumber}");
        int userAnswer = int.Parse(Console.ReadLine());

        if (userAnswer == result)
        {
            Console.WriteLine("Correct! Type any key for the next question:");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Incorrect! Type any key for the next question:");
            Console.ReadLine();
        }

        if (i == 5)
        {
            Console.WriteLine($@"Game over. Your final score is {score}/{i}
Press any key to go back to the game menu:");
            Console.ReadLine();
        }
    }

    AddToHistory(score, "Addition");
}

void SubtractionGame(string message)
{
    Random random = new();
    int score = 0;
    int firstNumber;
    int secondNumber;

    for (int i = 1; i <= 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);
        int result = firstNumber - secondNumber;

        Console.WriteLine($"{firstNumber} - {secondNumber}");
        int userAnswer = int.Parse(Console.ReadLine());

        if (userAnswer == result)
        {
            Console.WriteLine("Correct! Type any key for the next question:");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Incorrect! Type any key for the next question:");
            Console.ReadLine();
        }

        if (i == 5)
        {
            Console.WriteLine($@"Game over. Your final score is {score}/{i}
Press any key to go back to the game menu:");
            Console.ReadLine();
        }
    }

    AddToHistory(score, "Subtraction");
}

void MultiplicationGame(string message)
{
    Random random = new();
    int score = 0;
    int firstNumber;
    int secondNumber;

    for (int i = 1; i <= 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);
        int result = firstNumber * secondNumber;

        Console.WriteLine($"{firstNumber} * {secondNumber}");
        int userAnswer = int.Parse(Console.ReadLine());

        if (userAnswer == result)
        {
            Console.WriteLine("Correct! Type any key for the next question:");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Incorrect! Type any key for the next question:");
            Console.ReadLine();
        }

        if (i == 5)
        {
            Console.WriteLine($@"Game over. Your final score is {score}/{i}
Press any key to go back to the game menu:");
            Console.ReadLine();
        }
    }

    AddToHistory(score, "Multiplication");
}

void DivisionGame(string message)
{
    int score = 0;

    for (int i = 1; i <= 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        int[] divisionNumbers = GetDivisionNumbers();
        int firstNumber = divisionNumbers[0];
        int secondNumber = divisionNumbers[1];
        int result = firstNumber / secondNumber;
        
        Console.WriteLine($"{firstNumber} / {secondNumber}");
        int userAnswer = int.Parse(Console.ReadLine());

        if (userAnswer == result)
        {
            Console.WriteLine("Correct! Type any key for the next question:");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Incorrect! Type any key for the next question:");
            Console.ReadLine();
        }

        if (i == 5)
        {
            Console.WriteLine($@"Game over. Your final score is {score}/{i}
Press any key to go back to the game menu:");
            Console.ReadLine();
        }
    }

    AddToHistory(score, "Division");
}

int[] GetDivisionNumbers()
{
    Random random = new();
    int firstNumber = random.Next(1, 99);
    int secondNumber = random.Next(1, 99);

    int[] result = new int[2];

    while (firstNumber % secondNumber != 0)
    {
        firstNumber = random.Next(1, 99);
        secondNumber = random.Next(1, 99);
    }

    result[0] = firstNumber;
    result[1] = secondNumber;

    return result;

}

void Menu(string? name)
{
    Console.WriteLine("---------------------------------------------------");
    Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math's game\n");

    bool isGameOn = true;

    do
    {
        Console.WriteLine($@"What game would you like to play today? Chooose from the options below:

                        V - View History
                        A - Addition
                        S - Subtraction
                        M - Multiplication
                        D - Division
                        Q - Quit Game");
        Console.WriteLine("\n---------------------------------------------------");

        string gameSelected = Console.ReadLine().Trim().ToLower();

        switch (gameSelected)
        {
            case "v":
                GetGames();
                Console.Clear();
                break;
            case "a":
                AdditionGame("Addition Game");
                Console.Clear();
                break;
            case "s":
                SubtractionGame("Subtraction Game");
                Console.Clear();
                break;
            case "m":
                MultiplicationGame("Multiplication Game");
                Console.Clear();
                break;
            case "d":
                DivisionGame("Division Game");
                Console.Clear();
                break;
            case "q":
                Console.WriteLine("Goodbye!");
                isGameOn = false;
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    } while (isGameOn);
    
    
}