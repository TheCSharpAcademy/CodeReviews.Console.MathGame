// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Diagnostics;

class MathGame
{
    private List<string> log = new List<string>();
    private int num1, num2;
    private int choice;
    private int answer;
    private string? readResult;
    private int numberOfQuestions;
    private Stopwatch stopwatch = new Stopwatch();

    private void Run()
    {
        int gamesPlayed = 1;
        int i = 0;
        SetNumberOfQuestions();
        do
        {
            //To display Menu
            Menu();

            //To store calculated result of the two numbers
            int calculatedResult;

            //To generate random game
            if (choice == 5)
            {
                Random choiceGenerator = new Random();
                choice = choiceGenerator.Next(1, 5);
            }

            //To store game number
            if (choice < 5)
            {
                log.Add($"\nGame {gamesPlayed}");
                gamesPlayed++;
            }
            stopwatch.Start();

            switch (choice)
            {
                case 1:
                    Operation('+');
                    calculatedResult = num1 + num2;
                    break;
                case 2:
                    Operation('-');
                    calculatedResult = num1 - num2;
                    break;
                case 3:
                    Operation('*');
                    calculatedResult = num1 * num2;
                    break;
                case 4:
                    Operation('/');
                    calculatedResult = num1 / num2;
                    break;
                case 6:
                    LogHistory();
                    continue;
                case 7:
                    Console.WriteLine("\nExiting....\n");
                    continue;
                default:
                    Console.WriteLine("\nInvalid Choice\n");
                    continue;
            }

            Input();    //To get user input for the math question
            Compare(calculatedResult); //To compare user input with actual answer

            stopwatch.Reset();
            i++;


        } while (choice != 7 && i < numberOfQuestions);

        if (i == numberOfQuestions)
        {
            while(true)
            {
                Console.WriteLine("Do you want to view previous games (y/n)");
                readResult = Console.ReadLine();
                if (readResult == "y")
                {
                    LogHistory();
                     Console.WriteLine("\nExiting....\n");
                    break;
                }
                else if (readResult == "n")
                {
                    Console.WriteLine("\nExiting....\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter y or n");
                }
            }
        }
    }

    private int GetDifficulty()
    {
        while (true)
        {
            Console.Write($"\nEnter difficulty level (1-3): ");
            readResult = Console.ReadLine();
            if (int.TryParse(readResult, out int difficultyLevel))
            {
                if (difficultyLevel <= 0 || difficultyLevel > 3)
                {
                    Console.WriteLine("Invalid level");
                }
                else
                {
                    return difficultyLevel;
                }
            }
            else
            {
                Console.WriteLine("Enter integers");
            }
        }
    }

    private void SetNumberOfQuestions()
    {
        bool validInput = false;
        do
        {
            Console.Write("Enter the number of questions you want to answer: ");
            readResult = Console.ReadLine();
            if (int.TryParse(readResult, out numberOfQuestions) && numberOfQuestions > 0)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Enter a valid positive integer.");
            }
        } while (!validInput);
    }

    private void Menu()
    {
        while (true)
        {
            Console.WriteLine("\nOperation Menu: ");
            Console.WriteLine("1. Addition ");
            Console.WriteLine("2. Subtraction ");
            Console.WriteLine("3. Multiplication ");
            Console.WriteLine("4. Division ");
            Console.WriteLine("5. Random Game");
            Console.WriteLine("6. Log History ");
            Console.WriteLine("7. Exit");
            Console.Write("\nEnter your choice: ");

            readResult = Console.ReadLine();

            if (int.TryParse(readResult, out choice))
                break;
            else
                Console.WriteLine("\nEnter valid integer!!!");
        }

        if (choice < 6)
            GenerateNumbers(GetDifficulty());
    }

    private void GenerateNumbers(int difficultyLevel)
    {
        Random numGenerator = new Random();

        //Easy Level
        if (difficultyLevel == 1)
        {
            num1 = numGenerator.Next(1, 10);
            num2 = numGenerator.Next(1, num1);
        }
        //Moderate Level
        else if (difficultyLevel == 2)
        {
            num1 = numGenerator.Next(10, 101);
            num2 = numGenerator.Next(1, num1);
        }
        //Advanced Level
        else
        {
            num1 = numGenerator.Next(50, 101);
            num2 = numGenerator.Next(10, 50);
        }

        //Checking for remainder is zero 
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

    private void Input()
    {
        while (true)
        {
            Console.Write("Enter your ans: ");
            readResult = Console.ReadLine();

            if (int.TryParse(readResult, out answer))
                return;
            else
                Console.WriteLine("Enter valid Integer");
        }
    }


    private void Operation(char operation)
    {
        string question = $"\nWhat is {num1} {operation} {num2}?";
        Console.WriteLine(question);
        log.Add(question);
    }

    private void LogHistory()
    {
        if (log.Count == 0)
        {
            Console.WriteLine("\nNo games played yet!!");
            return;
        }

        foreach (string str in log)
        {
            Console.WriteLine(str);
        }
        Console.WriteLine();
    }

    private void Compare(int calculatedResult)
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

    public static void Main(string[] args)
    {
        MathGame ob = new MathGame();
        ob.Run();
    }

}
