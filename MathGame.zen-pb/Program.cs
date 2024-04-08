using System;

Random randomNumbers = new();

int x, y, answerToProblem, userAnswer;

bool validInput = false;
bool isDone = false;

string? userInput;

do
{
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
        if (userInput.ToLower() == "exit")
        {
            isDone = true;
        }

        validInput = int.TryParse(userInput, out int chosenGame);

        if (validInput)
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

} while (isDone == false);

void Multiplication()
{
    string answerStatement = "Enter the correct answer";

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine($"Multiplication({i + 1}/5) - {answerStatement}!");
        x = GenerateRandomNumber();
        y = GenerateRandomNumber();

        answerToProblem = x * y;
        Console.WriteLine($"{x} x {y}");

        answerStatement = CheckAnswer(answerToProblem);
    }

    Console.Clear();
    Console.WriteLine($"Multiplication(5/5) - {answerStatement}!");
    Console.WriteLine("\n\rPress Enter to return to the Main menu.");
    Console.ReadLine();
}

void Division()
{
    string answerStatement = "Enter the correct answer";

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine($"Division({i + 1}/5) - {answerStatement}!");

        do
        {
            x = GenerateRandomNumber();
            y = GenerateRandomNumber();

            while (y == 0)
            {
                y = GenerateRandomNumber();
            }

        } while (y > x || x % y != 0);

        answerToProblem = x / y;
        Console.WriteLine($"{x} / {y}");

        answerStatement = CheckAnswer(answerToProblem);
    }

    Console.Clear();
    Console.WriteLine($"Division(5/5) - {answerStatement}!");
    Console.WriteLine("\n\rPress Enter to return to the Main menu.");
    Console.ReadLine();
}

void Addition()
{
    string answerStatement = "Enter the correct answer";

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine($"Addition({i + 1}/5) - {answerStatement}!");
        x = GenerateRandomNumber();
        y = GenerateRandomNumber();
        answerToProblem = x + y;

        Console.WriteLine($"{x} + {y}");

        answerStatement = CheckAnswer(answerToProblem);
    }

    Console.Clear();
    Console.WriteLine($"Addition(5/5) - {answerStatement}!");
    Console.WriteLine("\n\rPress Enter to return to the Main menu.");
    Console.ReadLine();

}

void Subtraction()
{
    string answerStatement = "Enter the correct answer";

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine($"Subtraction({i + 1}/5) - {answerStatement}!");
        x = GenerateRandomNumber();
        y = GenerateRandomNumber();

        answerToProblem = x - y;
        Console.WriteLine($"{x} - {y}");

        answerStatement = CheckAnswer(answerToProblem);
    }

    Console.Clear();
    Console.WriteLine($"Subtraction(5/5) - {answerStatement}!");
    Console.WriteLine("\n\rPress Enter to return to the Main menu.");
    Console.ReadLine();
}

int GenerateRandomNumber()
{
    return randomNumbers.Next(0, 101);
}

void ShowHistory()
{
    Console.WriteLine("Under Construction...Press Enter to return to Main menu.");
    Console.ReadLine();
}

string CheckAnswer(int answerToProblem)
{
    string answerStatement = "";
    
    userInput = Console.ReadLine();

        if (userInput != null)
        {
            validInput = int.TryParse(userInput, out userAnswer);

            if (userAnswer == answerToProblem)
            {
                answerStatement = "Correct";
            }
            else
                answerStatement = "Incorrect";
        }

    return answerStatement;
}