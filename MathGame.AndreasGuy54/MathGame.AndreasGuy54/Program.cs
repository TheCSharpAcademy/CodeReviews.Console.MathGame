DateTime date = DateTime.UtcNow;

string? name = GetName();

Menu(name);

string? GetName()
{
    Console.WriteLine("Please type your name");

    string? name = Console.ReadLine();
    return name;
}

void AdditionGame(string message)
{
    //Clear console once at beginning of game and display message
    Console.Clear();
    Console.WriteLine(message);

    Random random = new();
    int score = 0;
    int firstNumber;
    int secondNumber;

    for (int i = 1; i <= 5; i++)
    {
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
            Console.WriteLine($"Game over. Your final score is {score}/{i}");
    }
}

void SubtractionGame(string message)
{
    Console.Clear();
    Console.WriteLine(message);

    Random random = new();
    int score = 0;
    int firstNumber;
    int secondNumber;

    for (int i = 1; i <= 5; i++)
    {
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
            Console.WriteLine($"Game over. Your final score is {score}/{i}");
    }
}

void MultiplicationGame(string message)
{
    Console.Clear();
    Console.WriteLine(message);

    Random random = new();
    int score = 0;
    int firstNumber;
    int secondNumber;

    for (int i = 1; i <= 5; i++)
    {
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
            Console.WriteLine($"Game over. Your final score is {score}/{i}");
    }
}

void DivisionGame(string message)
{
    Console.Clear();
    Console.WriteLine(message);

    int score = 0;

    for (int i = 1; i <= 5; i++)
    {
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
            Console.WriteLine($"Game over. Your final score is {score}/{i}");

    }
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
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math's game\n");
    Console.WriteLine($@"What game would you like to play today? Chooose from the options below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
    Console.WriteLine("-----------------------------------------");

    string gameSelected = Console.ReadLine().Trim().ToLower();

    switch (gameSelected)
    {
        case "a":
            AdditionGame("Addition Game");
            break;
        case "s":
            SubtractionGame("Subtraction Game");
            break;
        case "m":
            MultiplicationGame("Multiplication Game");
            break;
        case "d":
            DivisionGame("Division Game");
            break;
        case "q":
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }
}

