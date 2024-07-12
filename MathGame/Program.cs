// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics;

List<string> log = new List<string>();
int num1 = 0, num2 = 0;
int choice = 0;
int answer = 0;
string? readResult;
int gamesPlayed = 1;
Stopwatch stopwatch = new Stopwatch();


void Menu()
{
    Random numGenerator = new Random();

    bool validOption = false;
    do
    {
        Console.WriteLine("\nOperation Menu: ");
        Console.WriteLine("1. Addition ");
        Console.WriteLine("2. Subtraction ");
        Console.WriteLine("3. Multiplication ");
        Console.WriteLine("4. Division ");
        Console.WriteLine("5. Log History ");
        Console.WriteLine("6. Exit");
        Console.Write("\nEnter choice ");
        readResult = Console.ReadLine();
        if (int.TryParse(readResult, out choice))
        {
            validOption = true;
        }
        else    
           Console.WriteLine("\nEnter valid integer!!!");
    } while (!validOption);
    if (choice < 5)
    {
        num1 = numGenerator.Next(1, 101);
        num2 = numGenerator.Next(1, num1);
        if (choice == 4)
        {
            while (true)
            {
                if (num1 % num2 == 0)
                    break;
                num2 = numGenerator.Next(1, num1);
            }
        }
    }
}

void Input()
{
    bool incorrectInput = true;
    do
    {
        Console.Write("Enter you ans: ");
        readResult = Console.ReadLine();

        if (int.TryParse(readResult, out answer))
            incorrectInput = false;
        else
            Console.WriteLine("Enter valid Integer");
    } while (incorrectInput);
}

int Add(int x, int y)
{
    int result = 0;

    string question = $"What is {num1} + {num2}?";
    Console.WriteLine(question);
    result = num1 + num2;
    log.Add(question);
    return result;
}

int Subtract(int x, int y)
{
    int result = 0;
    string question = $"What is {num1} - {num2}?";
    Console.WriteLine(question);
    result = num1 - num2;
    log.Add(question);
    return result;
}

int Multiply(int x, int y)
{
    int result = 0;
    string question = $"What is {num1} * {num2}?";
    Console.WriteLine(question);
    result = num1 * num2;
    log.Add(question);
    return result;
}

int Division(int x, int y)
{
    int result = 0;
    string question = $"What is {num1} / {num2}?";
    Console.WriteLine(question);
    result = num1 / num2;
    log.Add(question);
    return result;

}

void LogHistory()
{
    if (log.Count == 0)
    {
        Console.WriteLine("\nNo games played yet!!");
        return;
    }
    // Console.WriteLine("");
    foreach (string str in log)
    {
        Console.WriteLine(str);
    }
    Console.WriteLine();
}

void Compare(int calculatedResult)
{
    log.Add($"Your answer: {answer}");
    if (calculatedResult == answer)
    {
        log.Add("Congrats! Your answer is correct");
        Console.WriteLine("Congrats! Your answer is correct");
    }
    else
    {
        log.Add("Sorry your answer is wrong");
        Console.WriteLine("Sorry your answer is wrong");
    }
    stopwatch.Stop();
    TimeSpan timeTaken = stopwatch.Elapsed;
    log.Add($"Time taken: {timeTaken.Seconds} seconds and {timeTaken.Milliseconds} milliseconds.");
    Console.WriteLine($"Time taken: {timeTaken.Seconds} seconds and {timeTaken.Milliseconds} milliseconds.");
}

int i = 0;
do
{

    Menu();
    int calculatedResult;

    

    switch (choice)
    {
        case 1:
            log.Add($"\nGame {gamesPlayed}");
            gamesPlayed++;
            calculatedResult = Add(num1, num2);
            stopwatch.Start();
            Input();
            Compare(calculatedResult);
            break;
        case 2:
            log.Add($"\nGame {gamesPlayed}");
            gamesPlayed++;
            calculatedResult = Subtract(num1, num2);
            stopwatch.Start();
            Input();
            Compare(calculatedResult);
            break;
        case 3:
            log.Add($"\nGame {gamesPlayed}");
            gamesPlayed++;
            calculatedResult = Multiply(num1, num2);
            stopwatch.Start();
            Input();
            Compare(calculatedResult);
            break;
        case 4:
            log.Add($"\nGame {gamesPlayed}");
            gamesPlayed++;
            calculatedResult = Division(num1, num2);
            stopwatch.Start();
            Input();
            Compare(calculatedResult);
            break;
        case 5:
            LogHistory();
            break;
        case 6:
            Console.WriteLine("\nExiting....\n");
            break;
        default:
            Console.WriteLine("\nInvalid Choice\n");
            break;
    }
    stopwatch.Reset();


} while (choice != 6 && i < 100);

