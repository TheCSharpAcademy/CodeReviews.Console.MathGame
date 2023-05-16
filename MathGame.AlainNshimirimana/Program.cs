var date = DateTime.Now; 

string name = GetName();

Menu(name);

string GetName()
{
    Console.WriteLine("Please type your name");
    var name = Console.ReadLine();
    return name;
}
void Menu(string name)
{
    Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math's game. That's great that you're working on improving yourself\n");

    var isGameOn = true;

    do
    {
        Console.Clear();
        Console.WriteLine($@"What game would you like to play today? Choose from the options below:
                            A - Addition 
                            S - Subtraction
                            M - Multiplication
                            D - Division
                            Q - Quit the program");
        Console.WriteLine("-----------------------------");

        var gameSelected = Console.ReadLine();

        switch (gameSelected.Trim().ToLower())
        {
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
                Console.WriteLine("Goodbye!");
                isGameOn = false;
                break;
            default:
                Console.WriteLine("Invalid Input");
                break;
        }
    } while (isGameOn);
}
void AdditionGame(string message)
{
    Console.Clear();
    Console.WriteLine(message);

    var random = new Random();
    var score = 0;

    int firstNumber;
    int secondNumber;

    for(int i = 0; i < 5; i++)
    {
        firstNumber = random.Next(1,9);
        secondNumber = random.Next(1, 9);
        Console.WriteLine($"{firstNumber} + {secondNumber}");

        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber + secondNumber)
        {
            Console.WriteLine("Your answer is correct! Type any key for the next question");
            Console.ReadLine();
            score++;
        }
        else
        {
            Console.WriteLine("Your answer is incorrect. Type any key for the next question");
            Console.ReadLine();
        }
        if (i == 4)
        {
            Console.WriteLine($"Game over. Your final score is {score}. Press any key to return to main menu");
            Console.ReadLine();
        }
    }
}
void SubtractionGame(string message)
{
    Console.Clear();
    Console.WriteLine(message);

    var random = new Random();
    var score = 0;

    int firstNumber;
    int secondNumber;

    for (int i = 0; i < 5; i++)
    {
        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);
        Console.WriteLine($"{firstNumber} - {secondNumber}");

        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber - secondNumber)
        {
            Console.WriteLine("Your answer is correct! Type any key for the next question");
            Console.ReadLine();
            score++;
        }
        else
        {
            Console.WriteLine("Your answer is incorrect. Type any key for the next question");
            Console.ReadLine();
        }
        if (i == 4)
        {
            Console.WriteLine($"Game over. Your final score is {score}. Press any key to return to main menu");
            Console.ReadLine();
        }
    }
}

void MultiplicationGame(string message)
{
    Console.Clear();
    Console.WriteLine(message);

    var random = new Random();
    var score = 0;

    int firstNumber;
    int secondNumber;

    for (int i = 0; i < 5; i++)
    {
        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);
        Console.WriteLine($"{firstNumber} * {secondNumber}");

        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber * secondNumber)
        {
            Console.WriteLine("Your answer is correct! Type any key for the next question");
            Console.ReadLine();
            score++;
        }
        else
        {
            Console.WriteLine("Your answer is incorrect. Type any key for the next question");
            Console.ReadLine();
        }
        if (i == 4)
        {
            Console.WriteLine($"Game over. Your final score is {score}. Press any key to return to main menu");
            Console.ReadLine();
        }
    }
}

void DivisionGame(string message)
{
    Console.Clear();
    Console.WriteLine(message);
    var score = 0;

    for (int i = 0; i < 5; i++)
    {
        var divisionNumbers = GetDivisionNumbers();
        var firstNumber = divisionNumbers[0];
        var secondNumber = divisionNumbers[1];

        Console.WriteLine($"{firstNumber} / {secondNumber}");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber / secondNumber)
        {
            Console.WriteLine("Your answer is correct! Type any key for the next question");
            score++; 
            
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Your answer is incorrect. Type any key for the next question");
            Console.ReadLine();
        }
        if (i == 4)
        {
            Console.WriteLine($"Game over. Your final score is {score}. Press any key to return to main menu");
            Console.ReadLine();
        }
    }

}

int[] GetDivisionNumbers()
{
    var random = new Random();
    var firstNumber = random.Next(1, 99);
    var secondNumber = random.Next(1, 99);

    var result = new int[2];

    while (firstNumber % secondNumber != 0)
    {
        firstNumber = random.Next(1, 99);
        secondNumber = random.Next(1, 99);
    }
    result[0] = firstNumber; 
    result[1] = secondNumber;

    return result;
}
