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
    string name = Console.ReadLine();
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
int CalculateAnswer(int num1, int num2, string operation)
{
    return operation switch
    {
        "+" => num1 + num2,
        "-" => num1 - num2,
        "*" => num1 * num2,
        "/" => num1 / num2,
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
    int userScore = 0;
    for (int i = 0; i < 5; i++)
    {
        int num1 = randomSeed.Next(1, 101);
        int num2 = randomSeed.Next(1, 101);
        string operation = mode == "mixed" ? GetRandomOperation(randomSeed) : mode;
        if (operation == "/")
        {
            // By multiplying them, we guarantee that (product / num2) is perfectly equal to num1
            int product = num1 * num2;

            // Re-assign num1 to the product so the question asks "product / num2 = ?"
            num1 = product;
        }
        int correctAnswer = CalculateAnswer(num1, num2, operation);
        Console.WriteLine($"Question {i + 1}: {num1} {operation} {num2} = ?");

        string userAnswer = Console.ReadLine();

        if (int.TryParse(userAnswer, out int userAnswerInt) && userAnswerInt == correctAnswer)
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

    // 6. Add the result to the leaderboard history list
    gamesHistory.Add($"{date:dd/MM/yyyy HH:mm} - {mode}: {userScore}/5");
}

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