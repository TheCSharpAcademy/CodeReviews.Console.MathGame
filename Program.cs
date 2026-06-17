using System;
using System.Collections.Generic; // Required to use List<T>

var date = DateTime.UtcNow;
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
    string name = Console.ReadLine();
    return name;
}

void StartMenu(string userName)
{
    Console.WriteLine($"Welcome, {userName}!");
    Console.WriteLine($"Today is {DateTime.UtcNow:dd MM, yyyy}");
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
            break;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
}

int CalculateAnswer(int num1, int num2, string operation)
{
    return operation switch
    {
        "+" => num1 + num2,
        "-" => num1 - num2,
        "*" => num1 * num2,
        "/" => num2 != 0 ? num1 / num2 : 0,
        _ => throw new InvalidOperationException("Invalid operation")
    };
}

string GetRandomOperation(Random randomSeed)
{
    string[] operations = { "+", "-", "*", "/" };
    int index = randomSeed.Next(operations.Length);
    return operations[index];
}

void GameMode(string mode, Random randomSeed)
{
    Console.WriteLine($"Starting {mode} game mode...");
    for (int i = 0; i < 5; i++)
    {
        int num1 = randomSeed.Next(1, 101);
        int num2 = randomSeed.Next(1, 101);
        string operation = mode == "mixed" ? GetRandomOperation(randomSeed) : mode;
        int correctAnswer = CalculateAnswer(num1, num2, operation);
        Console.WriteLine($"Question {i + 1}: {num1} {operation} {num2} = ?");
        string userAnswer = Console.ReadLine();
        if (int.TryParse(userAnswer, out int userAnswerInt) && userAnswerInt == correctAnswer)
        {
            Console.WriteLine("Correct!");
            score++;
        }
        else
        {
            Console.WriteLine($"Wrong! The correct answer is {correctAnswer}.");
        }
    }
}

void SeeLeaderboard()
{
    Console.WriteLine("Displaying leaderboard...");
}