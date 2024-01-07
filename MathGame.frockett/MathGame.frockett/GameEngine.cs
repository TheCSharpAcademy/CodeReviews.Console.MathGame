﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.frockett;

internal class GameEngine
{
    char[] operations = { '+', '-', '*', '/' };
    string[] gameTitle = { "Addition", "Subtraction", "Multiplication", "Division" };

    internal void MainGameLoop(char operation, int difficulty = 1)
    {
        int index;
        string? result;
        int score = 0;

        Random random = new Random();
        int firstNum;
        int secondNum;
        
        string? difficultySelect;
        int upperBound;

        upperBound = AuxFunctions.ProcessDifficulty();


        Console.Clear();
        if (operations.Contains(operation))
        {
            index = Array.IndexOf(operations, operation);
            Console.WriteLine($"{gameTitle[index]} Game\n");
        }
        else
        {
            throw new ArgumentException("Unexpected operator char: " + operation);
        }


        //Console.Clear();
        //Console.WriteLine($"{gameTitle[index]} Game\n");

        for (int i = 0; i < 5; i++)
        {
            if (operation == '/')
            {
                do // This do while loop ensures that division operations only result in integers while keeping game logic modular
                {
                    firstNum = random.Next(1, 10);
                    secondNum = random.Next(1, 10);
                } while (firstNum % secondNum != 0);
            }
            else
            {
                firstNum = random.Next(1, 10);
                secondNum = random.Next(1, 10);
            }

            Console.WriteLine($"\n{firstNum} {operation} {secondNum}");
            result = Console.ReadLine();

            // This while loop remains in this method because it does not need to be repeated
            while (string.IsNullOrEmpty(result) || !int.TryParse(result, out _)) 
            {
                Console.WriteLine("Your answer must be an integer. Try again.");
                result = Console.ReadLine();
            }

            if (int.Parse(result) == PerformCalculation(operation, firstNum, secondNum))
            {
                Console.WriteLine("Your answer is correct!\n");
                score++;
            }
            else { Console.WriteLine("Your Answer is incorrect!\n"); }
        }
        Console.WriteLine($"Your final score is {score}");
        Console.ReadLine();

        AuxFunctions.AddToHistory(score, gameTitle[index]);
    }

    internal int PerformCalculation(char operation, int firstNum, int secondNum)
    {
        //This switch statement matches the input with the operation. I think this might be better than many methods to perform similar arithmetic.
        switch (operation) 
        {
            case '+':
                return firstNum + secondNum;
            case '-':
                return firstNum - secondNum;
            case '*':
                return firstNum * secondNum;
            case '/':
                return firstNum / secondNum;
            default:
                throw new ArgumentException("Unexpected operator string: " + operation);
        }
    }
}
