using System;
using System.Collections.Generic;

class MathGame
{
    static void DisplayMenu()
    {
        Console.WriteLine("You can choose from these operations:");
        Console.WriteLine("1. ADDITION");
        Console.WriteLine("2. SUBTRACTION");
        Console.WriteLine("3. DIVISION");
        Console.WriteLine("4. MULTIPLICATION");
        Console.WriteLine("5. View Previous History");
        Console.WriteLine("6. View Menu");
        Console.WriteLine("7. EXIT");
    }

    static bool Game(ref List<string> history, char op)
    {
        Random guesser = new Random();
        int number1 = guesser.Next(0, 100);
        int number2 = guesser.Next(0, 100);
        if (op == '/')
        {
            while (number1 % number2 != 0 && number2 != 0)
                number2 = guesser.Next(-100, 100);
        }

        int answer = 0;
        string toLog = "";
        switch (op)
        {
            case '+':
                Console.WriteLine($"Guess the answer for {number1} plus {number2}");
                answer = number1 + number2;
                toLog = $"{number1} plus {number2} = {answer}";
                break;
            case '-':
                Console.WriteLine($"Guess the answer for {number1} subtract {number2}");
                answer = number1 - number2;
                toLog = $"{number1} minus {number2} = {answer}";
                break;
            case '*':
                Console.WriteLine($"Guess the answer for {number1} times {number2}");
                answer = number1 * number2;
                toLog = $"{number1} times {number2} = {answer}";
                break;
            case '/':
                Console.WriteLine($"Guess the answer for {number1} divided by {number2}");
                answer = number1 / number2;
                toLog = $"{number1} divided by {number2} = {answer}";
                break;
        }

        string userRes = Console.ReadLine();
        if (int.TryParse(userRes, out int res))
        {
            toLog += $" your answer: {res} verdict:";
            if (res == answer)
            {
                toLog += " correct";
                history.Add(toLog);
                return true;
            }
            else
            {
                toLog += " incorrect";
                history.Add(toLog);
                return false;
            }
        }
        else
        {
            toLog += $" your answer: {userRes} verdict: incorrect";
            history.Add(toLog);
            Console.WriteLine("Your entered result is not an integer");
        }
        return false;
    }

    public static void GameDriver()
    {
        Console.WriteLine("New Game has started");
        List<string> history = new List<string>();
        int correct = 0;
        DisplayMenu();
        Console.WriteLine("Enter your choice");
        string userChoice = Console.ReadLine();
        int choice;
        while (!int.TryParse(userChoice, out choice))
        {
            Console.WriteLine("Invalid choice... Please enter an integer");
            userChoice = Console.ReadLine();
        }
        while (choice > 0 && choice < 7)
        {
            switch (choice)
            {
                case 1: if (Game(ref history, '+')) correct++; break;
                case 2: if (Game(ref history, '-')) correct++; break;
                case 3: if (Game(ref history, '/')) correct++; break;
                case 4: if (Game(ref history, '*')) correct++; break;
                case 5:
                    {
                        Console.WriteLine("You answered " + history.Count + " questions and correctly answered " + correct + " of them");
                        foreach (string s in history) Console.WriteLine(s);
                        if(history.Count>0)Console.WriteLine("Correct percentage: " + correct * 100 / history.Count);
                        break;
                    }
                case 6: DisplayMenu(); break;
                default:                         
                    return;
                    break;
            }
            Console.WriteLine("Enter your choice");
            userChoice = Console.ReadLine();
            while (!int.TryParse(userChoice, out choice))
            {
                Console.WriteLine("Invalid choice... Please enter an integer");
                userChoice = Console.ReadLine();
            }
        }
        Console.WriteLine("You answered " + history.Count + " questions and correctly answered " + correct + " of them");
        if(history.Count>0)Console.WriteLine("Correct percentage: " + correct * 100 / history.Count);
        return;
    }
}

class Program
{
    static void Main(string[] args)
    {
        MathGame.GameDriver();
        Console.WriteLine("Would you like to start a new game: ENTER y");
        string contGame = Console.ReadLine();
        while (contGame.ToLower() == "y")
        {
            MathGame.GameDriver();
            Console.WriteLine("Would you like to start a new game: ENTER y");
            contGame = Console.ReadLine();
        }
        return;
    }
}
