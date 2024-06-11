
string name = GetName();
var games = new List<string>();
Menu(name);

void Menu(string playerName)
{
    bool isGameOn = true;

    do
    {
        Console.Clear();
        Console.WriteLine($"\nCurrent player: {playerName}");
        Console.Write(@"Choose game from the options bellow:
        A - Addition
        S - Subtraction
        M - Multiplication
        D - Division
        V - View Previous Games
        Q - Quit the program
        Selected action:  ");

        var selectedGame = Console.ReadLine();

        switch (selectedGame.Trim().ToLower())
        {
            case "a":
                AdditionGame("Addition game");
                break;
            case "s":
                SubtractionGame("S game");
                break;
            case "m":
                MultiplicationGame("M game");
                break;
            case "d":
                DivisionGame("D game");
                break;
            case "v":
                GetGames();
                break;
            case "q":
                Console.WriteLine("Program exit");
                isGameOn = false;
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }

    } while (isGameOn);
}

void GetGames()
{
    Console.Clear();
    Console.WriteLine("Games History");
    Console.WriteLine("---------------------");
    foreach(var game in games)
    {
        Console.WriteLine(game)
    }
    Console.WriteLine("---------------------");
    Console.WriteLine("Press any key to return to the Main Menu");
    Console.ReadLine();
}

string GetName()
{
    Console.WriteLine("Please type your name");
    var name = Console.ReadLine();
    return name;
}

void AdditionGame(string message)
{
    var random = new Random();
    var score = 0;
    int firstNumber;
    int secondNumber;

    for(int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} + {secondNumber}");
        var result = Console.ReadLine();

        if(int.Parse(result) == firstNumber + secondNumber)
        {
            score++;
            Console.WriteLine("Your answer was correct! Type any key for the next question.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
            Console.ReadLine();
        }      
    }
    Console.WriteLine($"Game over. Your final score is {score}");
    AddToHistory(score, "Addition");

}

void SubtractionGame(string message)
{
    var random = new Random();
    var score = 0;
    int firstNumber;
    int secondNumber;

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} - {secondNumber}");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber - secondNumber)
        {
            score++;
            Console.WriteLine("Your answer was correct! Type any key for the next question.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
            Console.ReadLine();
        }
    }
    Console.WriteLine($"Game over. Your final score is {score}");
    AddToHistory(score, "Subtraction");
}

void MultiplicationGame(string message)
{
    var random = new Random();
    var score = 0;
    int firstNumber;
    int secondNumber;

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} * {secondNumber}");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber * secondNumber)
        {
            score++;
            Console.WriteLine("Your answer was correct! Type any key for the next question.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
            Console.ReadLine();
        }
    }
    Console.WriteLine($"Game over. Your final score is {score}");
    AddToHistory(score, "Multiplication");
}

void DivisionGame(string message)
{
 
    var score = 0;

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        var divisionNumbers = GetDivisionNumbers();
        var firstNumber = divisionNumbers[0];
        var secondNumber = divisionNumbers[1];

        Console.WriteLine($"{firstNumber} / {secondNumber}");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber / secondNumber)
        {
            score++;
            Console.WriteLine("Your answer was correct! Type any key for the next question.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Your answer was incorrect. Type any key for the next question.");
            Console.ReadLine();
        }
    }
    
    Console.WriteLine($"Game over. Your final score is {score}");
    AddToHistory(score, "Division");
}

int[] GetDivisionNumbers()
{
    var random = new Random();
    var result = new int[2];

    var firstNumber = random.Next(0, 99);
    var secondNumber = random.Next(0, 99);

    while (firstNumber % secondNumber != 0)
    {
        firstNumber = random.Next(1, 99);
        secondNumber = random.Next(1, 99);

    }

    result[0] = firstNumber;
    result[1] = secondNumber;

    return result;
}

void AddToHistory(int gameScore, string gameType)
{
    games.Add($"{DateTime.Now} - {gameType} : {gameScore} pts");
}