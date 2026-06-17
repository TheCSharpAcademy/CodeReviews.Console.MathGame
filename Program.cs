using System;
using System.Collections.Generic; 

var date = DateTime.UtcNow.AddHours(7);
Console.WriteLine($"Welcome to Math game - {date}");
string userName = GetUserName();
// Store games history in a list
List<string> gamesHistory = new List<string>();

bool isGameOn = true;
while (isGameOn)
{
    StartMenu(userName);
}
string GetUserName()
{
    Console.WriteLine("Please enter your name:");
    string? name = Console.ReadLine();
    if (name == null || name.Trim() == "")
    {
        Console.WriteLine("Invalid input. Please enter a valid name.");
        return GetUserName();
    }
    return name;
}

void StartMenu(string userName)
{
    Console.Clear();
    Console.WriteLine($"Welcome, {userName}!");
    Console.WriteLine($"Today is {date:dd/MM/yyyy HH:mm}");
    Console.WriteLine("Please select a game mode:");
    Console.WriteLine($@"+-----------------------------+
    | 1. Addition                  |
    | 2. Subtraction               |
    | 3. Multiplication            |
    | 4. Division                  |
    | 5. Mixed                     |
    | 6. See leaderboard           |
    | 7. Quit                      |");
    Console.WriteLine("+-----------------------------+");

    var randomSeed = new Random();

    var modeSelected = Console.ReadLine();
    switch (modeSelected)
    {
        case "1":
            Console.WriteLine("You selected Addition mode.");
            GameMode("+", randomSeed);
            break;
        case "2":
            Console.WriteLine("You selected Subtraction mode.");
            GameMode("-", randomSeed);
            break;
        case "3":
            Console.WriteLine("You selected Multiplication mode.");
            GameMode("*", randomSeed);
            break;
        case "4":
            Console.WriteLine("You selected Division mode.");
            GameMode("/", randomSeed);
            break;
        case "5":
            Console.WriteLine("You selected Mixed mode.");
            GameMode("mixed", randomSeed);
            break;
        case "6":
            Console.WriteLine("You selected See leaderboard mode.");
            SeeLeaderboard();
            break;
        case "7":
            Console.WriteLine("Thank you for playing! Goodbye!");
            isGameOn = false;
            return;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ReadKey();
}
long CalculateAnswer(long[] numbers, string operation)
{
    long result = numbers[0];
    for (int i = 1; i < numbers.Length; i++)
    {
        result = operation switch
        {
            "+" => result + numbers[i],
            "-" => result - numbers[i],
            "*" => result * numbers[i],
            "/" => result / numbers[i],
            _ => throw new InvalidOperationException("Invalid operation")
        };
    }
    return result;
}

string GetRandomOperation(Random randomSeed)
{
    string[] operations = { "+", "-", "*", "/" };
    int index = randomSeed.Next(operations.Length);
    return operations[index];
}

void GameMode(string mode, Random randomSeed)
{
    Console.Clear();
    Console.WriteLine($"Starting {mode} game mode...");
    int userScore = 0;
    Console.WriteLine("Select difficulty level:");
    Console.WriteLine("-------------------------------");
    Console.WriteLine("1. Easy (numbers between 1 and 10) and 2 numbers");
    Console.WriteLine("2. Medium (numbers between 1 and 50) and 3 numbers");
    Console.WriteLine("3. Hard (numbers between 1 and 100) and 4 numbers");
    Console.WriteLine("4. Impossible (numbers between 1 and 1000) and 5 numbers");
    Console.WriteLine("-------------------------------");

    int difficultyLevel;
    // Invalid input handling: default to Easy (1)
    if (!int.TryParse(Console.ReadLine(), out difficultyLevel) || difficultyLevel < 1 || difficultyLevel > 4)
    {
        difficultyLevel = 1;
        Console.WriteLine("Invalid selection. Defaulting to Easy difficulty.");
    }
    // 2. We set these variables based on the difficulty chosen
    int numberCount = 2;
    int maxNumber = 10;
    string diffName = "Easy";

    switch (difficultyLevel)
    {
        case 1: numberCount = 2; maxNumber = 10; diffName = "Easy"; break;
        case 2: numberCount = 3; maxNumber = 50; diffName = "Medium"; break;
        case 3: numberCount = 4; maxNumber = 100; diffName = "Hard"; break;
        case 4: numberCount = 5; maxNumber = 1000; diffName = "Impossible"; break;
    }
    Console.Clear();
    Console.WriteLine($"You selected {diffName} difficulty.");

    for (int i = 0; i < 5; i++)
    {
        string operation = mode == "mixed" ? GetRandomOperation(randomSeed) : mode;

        long[] numbers = new long[numberCount];
        for (int j = 0; j < numberCount; j++)
        {
            numbers[j] = randomSeed.Next(1, maxNumber + 1);
        }
        if (operation == "/")
        {
            long product = 1;
            for (int j = 1; j < numberCount; j++)
            {
                product *= numbers[j];
            }
            numbers[0] = numbers[0] * product;
        }
        long correctAnswer = CalculateAnswer(numbers, operation);

        // string.Join dynamically stitches all numbers together with the operator (e.g. "5 + 10 + 15")
        string questionStr = string.Join($" {operation} ", numbers);
        Console.WriteLine($"Question {i + 1}: {questionStr} = ?");
        string? userAnswer = Console.ReadLine();
        if (long.TryParse(userAnswer, out long userAnswerInt) && userAnswerInt == correctAnswer)
        {
            Console.WriteLine("Correct!");
            userScore++;
        }
        else
        {
            Console.WriteLine($"Wrong! The correct answer is {correctAnswer}.");
        }
    }

    Console.WriteLine($"\nGame over! Your score for this round is: {userScore}/5");
    gamesHistory.Add($"{date:dd/MM/yyyy HH:mm} - {diffName} - {mode}: {userScore}/5");
}

// 6. Add the result to the leaderboard history list
void SeeLeaderboard()
{
    Console.Clear();
    Console.WriteLine("-------------------");
    Console.WriteLine("Displaying leaderboard...");
    if (gamesHistory.Count == 0)
    {
        Console.WriteLine("No games played yet!");
    }
    else
    {
        foreach (var record in gamesHistory)
        {
            Console.WriteLine(record);
        }
    }
    Console.WriteLine("-------------------\n");
}