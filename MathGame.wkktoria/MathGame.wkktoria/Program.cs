var previousGames = new List<string>();
var username = GetName();

Menu(username);

string GetName()
{
    Console.Write("Please type your name: ");
    var name = Console.ReadLine();
    return name;
}

void Menu(string name)
{
    Console.WriteLine(
        $"\nHello {Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name.ToLower())}. It's {DateTime.UtcNow.DayOfWeek}. This is math's game.\n");

    var isGameOn = true;

    do
    {
        Console.Clear();
        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
        Console.WriteLine("""
                          What would you like to play today? Choose from the options below:

                          V - View previous games
                          A - Addition
                          S - Subtraction
                          M - Multiplication
                          D - Division
                          Q - Quit the program
                          """);
        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
        Console.Write("> ");
        var gameSelected = Console.ReadLine();

        switch (gameSelected.Trim().ToLower())
        {
            case "v":
                GetPreviousGames();
                break;
            case "a":
                AdditionGame("Addition game");
                break;
            case "s":
                SubtractionGame("Subtraction game");
                break;
            case "m":
                MultiplicationGame("Multiplication game");
                break;
            case "d":
                DivisionGame("Division game");
                break;
            case "q":
                Console.WriteLine("Quiting...");
                isGameOn = false;
                break;
            default:
                Console.WriteLine("Invalid input.");
                break;
        }
    } while (isGameOn);
}

void GetPreviousGames()
{
    Console.Clear();
    Console.WriteLine("Games history");
    Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
    foreach (var game in previousGames) Console.WriteLine(game);
    Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
    Console.WriteLine("Press any key to return to the main menu.");
    Console.ReadLine();
}

void AddToHistory(string gameType, int gameScore)
{
    previousGames.Add($"{DateTime.Now} - {gameType}: Score={gameScore}");
}

void AdditionGame(string message)
{
    var random = new Random();

    var score = 0;

    for (var i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        var firstNumber = random.Next(1, 9);
        var secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} + {secondNumber} = ?");
        Console.Write("> ");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber + secondNumber)
        {
            Console.WriteLine("Your answer was correct.");
            score++;
            Console.WriteLine("Type any key for the next question.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Your answer was incorrect.");
            Console.WriteLine("Type any key for the next question.");
            Console.ReadLine();
        }
    }

    AddToHistory("Addition", score);

    Console.Clear();
    Console.WriteLine($"Game over. Your final score is {score}.");
    Console.WriteLine("Press any key to go back to the main menu.");
    Console.ReadLine();
}

void SubtractionGame(string message)
{
    var random = new Random();

    var score = 0;

    for (var i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        var firstNumber = random.Next(1, 9);
        var secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} - {secondNumber} = ?");
        Console.Write("> ");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber - secondNumber)
        {
            Console.WriteLine("Your answer was correct.");
            score++;
            Console.WriteLine("Type any key for the next question.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Your answer was incorrect.");
            Console.WriteLine("Type any key for the next question.");
            Console.ReadLine();
        }
    }

    AddToHistory("Subtraction", score);

    Console.Clear();
    Console.WriteLine($"Game over. Your final score is {score}.");
    Console.WriteLine("Press any key to go back to the main menu.");
    Console.ReadLine();
}

void MultiplicationGame(string message)
{
    var random = new Random();

    var score = 0;

    for (var i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        var firstNumber = random.Next(1, 9);
        var secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} * {secondNumber} = ?");
        Console.Write("> ");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber * secondNumber)
        {
            Console.WriteLine("Your answer was correct.");
            score++;
            Console.WriteLine("Type any key for the next question.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Your answer was incorrect.");
            Console.WriteLine("Type any key for the next question.");
            Console.ReadLine();
        }
    }

    AddToHistory("Multiplication", score);

    Console.Clear();
    Console.WriteLine($"Game over. Your final score is {score}.");
    Console.WriteLine("Press any key to go back to the main menu.");
    Console.ReadLine();
}

int[] GetDivisionNumbers()
{
    var random = new Random();

    var firstNumber = random.Next(1, 99);
    var secondNumber = random.Next(1, 99);

    var divisionNumbers = new int[2];

    while (firstNumber % secondNumber != 0)
    {
        firstNumber = random.Next(0, 99);
        secondNumber = random.Next(0, 99);
    }

    divisionNumbers[0] = firstNumber;
    divisionNumbers[1] = secondNumber;

    return divisionNumbers;
}

void DivisionGame(string message)
{
    var score = 0;

    for (var i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        var divisionNumbers = GetDivisionNumbers();
        var firstNumber = divisionNumbers[0];
        var secondNumber = divisionNumbers[1];

        Console.WriteLine($"{firstNumber} / {secondNumber} = ?");
        Console.Write("> ");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber / secondNumber)
        {
            Console.WriteLine("Your answer was correct.");
            score++;
            Console.WriteLine("Type any key for the next question.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Your answer was incorrect.");
            Console.WriteLine("Type any key for the next question.");
            Console.ReadLine();
        }
    }

    AddToHistory("Division", score);

    Console.Clear();
    Console.WriteLine($"Game over. Your final score is {score}.");
    Console.WriteLine("Press any key to go back to the main menu.");
    Console.ReadLine();
}