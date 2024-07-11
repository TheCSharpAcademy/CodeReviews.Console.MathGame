using System;
using System.Collections.Generic;

namespace MathGame;

class Program
{
    public static void Main()
    {
        Console.Clear();

        DisplayNameAndTime();

        Console.WriteLine("Are you ready to SHARPEN your Maths Skills?");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();

        MainMenuOptions();
        InitaializeGame();
    }
    public static void DisplayNameAndTime()
    {
        string? name;
        bool validEntry = false;
        do
        {
            Console.WriteLine("Please type your name: ");
            name = Console.ReadLine();
            if (name == null || name.Trim().Length == 0)
            {
                validEntry = false;
            }
            else
            {
                validEntry = true;
                Console.WriteLine("\n----------------------------------------------------\n");
                Console.WriteLine("Hello " + name.Trim() + ", " + "Welcome to our Math Game!");
            }

        } while (validEntry == false);

        var date = DateTime.UtcNow;
        Console.WriteLine("Time: " + date);
        Console.WriteLine("\n----------------------------------------------------\n");
    }
    public static void MainMenuOptions()
    {
        Console.Clear();
        Console.WriteLine("Choose a game from the next options to begin: \n");
        Console.WriteLine("---------------------Menu---------------------");
        Console.WriteLine(@$"1-Addition
2-Subtraction
3-Multiplication
4-Division
5-Game History
6-Exit");
        Console.WriteLine("----------------------------------------------------\n");
    }
    public static void InitaializeGame()
    {
        // Generating random numbers for different games 
        Random random = new Random();

        // Choosing Menu Options and initializing the game
        Console.WriteLine("Number of menu option: ");

        int score = 0;
        //int finalScore = 0;

        bool exit = false;

        while (exit == false)
        {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            switch (consoleKey.KeyChar)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Start training on \"Addition\" , Press Enter to continue...");
                    Console.ReadLine();

                    int addNum = random.Next(0, 100);
                    int addNum2 = random.Next(0, 100);
                    Calculator add = new Calculator(addNum, '+', addNum2);
                    // Calculating game score
                    if (add.correctAnswer == true)
                        score++;

                    Console.WriteLine("\n....................................");
                    Console.WriteLine("Your total score = " + score);
                    Console.WriteLine("....................................\n");
                    Console.WriteLine("\nPress Enter for the Main Menu");
                    Console.ReadLine();
                    break;

                case '2':
                    Console.Clear();
                    Console.WriteLine("Start training on \"Subtraction\" , Press Enter to continue...");
                    Console.ReadLine();

                    int subtractNum = random.Next(0, 100);
                    int subtractNum2 = random.Next(0, 100);

                    Calculator subtract = new Calculator(subtractNum, '-', subtractNum2);
                    if (subtract.correctAnswer == true)
                        score++;

                    Console.WriteLine("\n....................................");
                    Console.WriteLine("Your total score = " + score);
                    Console.WriteLine("....................................\n");
                    Console.WriteLine("\nPress Enter for the Main Menu");
                    Console.ReadLine();
                    break;

                case '3':
                    Console.Clear();
                    Console.WriteLine("Start training on \"Multiplication\" , Press Enter to continue...");
                    Console.ReadLine();

                    int multiplyNum = random.Next(0, 100);
                    int multiplyNum2 = random.Next(0, 100);

                    Calculator multiply = new Calculator(multiplyNum, '*', multiplyNum2);
                    if (multiply.correctAnswer == true)
                        score++;

                    Console.WriteLine("\n....................................");
                    Console.WriteLine("Your total score = " + score);
                    Console.WriteLine("....................................\n");
                    Console.WriteLine("\nPress Enter for the Main Menu");
                    Console.ReadLine();
                    break;

                case '4':
                    Console.Clear();
                    Console.WriteLine("Start training on \"Division\" , Press Enter to continue...");
                    Console.ReadLine();

                    int dividend, divisor;
                    bool invalidDivisionNumbers;
                    do
                    {
                        dividend = random.Next(0, 100);
                        divisor = random.Next(1, 100);
                        invalidDivisionNumbers = dividend % divisor != 0;
                    } while (invalidDivisionNumbers);

                    Calculator divide = new Calculator(dividend, '/', divisor);
                    if (divide.correctAnswer == true)
                        score++;

                    Console.WriteLine("\n....................................");
                    Console.WriteLine("Your total score = " + score);
                    Console.WriteLine("....................................\n");
                    Console.WriteLine("\nPress Enter for the Main Menu");
                    Console.ReadLine();
                    break;

                case '5':
                    Console.Clear();
                    Console.WriteLine("Press Enter to show your Game History!");
                    Console.ReadLine();
                    foreach (var game in Calculator.gameHistory)
                    {
                        Console.WriteLine(game);
                    }
                    Console.WriteLine("\n...........................................");
                    Console.WriteLine($"Total Score: {score}");
                    Console.WriteLine(".............................................\n");
                    Console.WriteLine("\nPress Enter for the Main Menu\n");
                    Console.ReadLine();
                    break;

                case '6':
                    Console.Clear();
                    Console.WriteLine("Exiting the game....");
                    Console.Clear();
                    exit = true;
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Option...Please choose an option number from 1-6");
                    Console.WriteLine("\nPress Enter for the Main Menu");
                    Console.ReadLine();
                    break;
            }

            MainMenuOptions();
        }
    }
}
public class Calculator
{
    public int num1 { get; set; }
    public int num2 { get; set; }
    public char myOperator { get; set; }
    public int result { get; set; }
    public bool correctAnswer { get; set; }
    public static List<string> gameHistory = new List<string>();

    public Calculator(int num1, char myOperator, int num2)
    {
        this.num1 = num1;
        this.num2 = num2;
        this.myOperator = myOperator;

        switch (myOperator)
        {
            case '+':
                result = num1 + num2;
                break;

            case '-':
                result = num1 - num2;
                break;

            case '*':
                result = num1 * num2;
                break;

            case '/':
                result = num1 / num2;
                break;
        }
        GameQA();
    }
    // Displaying game Questions & Answers + Game History 
    public void GameQA()
    {
        string question = $"Q: {num1} {myOperator} {num2} = -------?";
        Console.WriteLine(question);

        int solutionNumber;

        string gameResult = "";
        string? answer = Console.ReadLine();

        gameResult = int.TryParse(answer?.Trim(), out solutionNumber) ? (solutionNumber == result ? "Bravo!" : "Try harder!") : "Invalid number!";
        Console.WriteLine(@$"----------------------------------------------------
{gameResult}
Your answer = {answer?.Trim()}
The correct answer = {result}
----------------------------------------------------");
        correctAnswer = solutionNumber == result ? true : false;

        gameHistory.Add(@$"
        Time: {DateTime.UtcNow}

Question:         {question}
Your Answer:      {answer?.Trim()}
Correct Answer:   {result}

**********************************************
");
    }
}




