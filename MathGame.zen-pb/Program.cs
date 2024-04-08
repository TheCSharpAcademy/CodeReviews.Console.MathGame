using System;

Random randomNumbers = new();

int x, y, answer, userAnswer;

bool validInput = false;

string? userInput;

Console.Clear();
Console.WriteLine("Welcome to MATH GAME!\n");
Console.WriteLine("Choose what type of game you want to play: ");
Console.WriteLine("1. Multiplication");
Console.WriteLine("2. Division");
Console.WriteLine("3. Addition");
Console.WriteLine("4. Subtraction");
Console.WriteLine("5. History\n");

userInput = Console.ReadLine();

if (userInput != null)
{
    validInput = int.TryParse(userInput, out int chosenGame);

    switch (chosenGame)
    {
        case 1:
            Multiplication();
            break;

        case 2:
            Division();
            break;

        case 3:
            Addition();
            break;

        case 4:
            Subtraction();
            break;

        case 5:
            ShowHistory();
            break;
    }
}


void Multiplication()
{
    Console.Clear();
    Console.WriteLine("Multiplication - Enter the correct answer!");
    x = GenerateRandomNumber();
    y = GenerateRandomNumber();

    answer = x * y;
    Console.WriteLine($"{x} x {y}");

    userInput = Console.ReadLine();

    if (userInput != null)
    {
        validInput = int.TryParse(userInput, out userAnswer);

        if (userAnswer == answer)
        {
            Console.WriteLine("Correct answer!");
        }
    }
}

void Division()
{
    Console.Clear();
    Console.WriteLine("Division - Enter the correct answer!");

    do
    {
        x = GenerateRandomNumber();
        y = GenerateRandomNumber();

        while (y == 0)
        {
            y = GenerateRandomNumber();
        }

    } while (y > x || x % y != 0);

    answer = x / y;
    Console.WriteLine($"{x} / {y}");

    userInput = Console.ReadLine();

    if (userInput != null)
    {
        validInput = int.TryParse(userInput, out userAnswer);

        if (userAnswer == answer)
        {
            Console.WriteLine("Correct answer!");
        }
    }
}

void Addition()
{
    Console.Clear();
    Console.WriteLine("Addition - Enter the correct answer!");
    x = GenerateRandomNumber();
    y = GenerateRandomNumber();
    answer = x + y;

    Console.WriteLine($"{x} + {y}");
    userInput = Console.ReadLine();

    if (userInput != null)
    {
        validInput = int.TryParse(userInput, out userAnswer);

        if (userAnswer == answer)
        {
            Console.WriteLine("Correct answer!");
        }
    }
}

void Subtraction()
{
    Console.Clear();
    Console.WriteLine("Subtraction - Enter the correct answer!");
    x = GenerateRandomNumber();
    y = GenerateRandomNumber();

    answer = x - y;
    Console.WriteLine($"{x} - {y}");

    userInput = Console.ReadLine();

    if (userInput != null)
    {
        validInput = int.TryParse(userInput, out userAnswer);

        if (userAnswer == answer)
        {
            Console.WriteLine("Correct answer!");
        }
    }
}

int GenerateRandomNumber()
{
    return randomNumbers.Next(0, 101);
}

void ShowHistory()
{
    Console.WriteLine("Under Construction...");
}