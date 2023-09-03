using System;
using System.Collections.Generic;

namespace MathGame
{
    class Program
    {
        static List<string> Games = new List<string>();
        static void Main(string[] args)
        {            
            GetUserInput();
        }

        static void GetUserInput()
        {
            Console.Clear();
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("\n\nMain Menu");
                Console.WriteLine("\nWhat would you like to do");
                Console.WriteLine("\nType q to Close Application");
                Console.WriteLine("Type 1 for Additon");
                Console.WriteLine("Type 2 for Subtraction");
                Console.WriteLine("Type 3 for Division");
                Console.WriteLine("Type 4 for Multiplication");
                Console.WriteLine("Type 5 for Game Results");
                Console.WriteLine("-------------------------\n");

                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "q":
                        Console.WriteLine("\nGoodbye\n");
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case "1":
                        Additon();
                        break;
                    case "2":
                        Subtraction();
                        break;
                    case "3":
                        Division();
                        break;
                    case "4":
                        Multiplication();                     
                        break;
                    case "5":
                        GamesResults();
                        break;
                    default:
                        Console.WriteLine("\nInvalid Command. Please type a number from 0 to 5.\n");
                        break;
                }
            }
        }

        static void Additon()
        {
            (int firstNumber, int secondNumber) = GetRandomNumbers();
            Console.WriteLine($"What is {firstNumber} + {secondNumber}:");
            int actualResult = firstNumber + secondNumber;
            int userResult = GetNumberInput("\n\nPlease type your result. Type 0 to return to Main Menu\n\n");
            
            if (actualResult == userResult)
            {
                Console.WriteLine("Correct");
                Games.Add("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
                Games.Add("Incorrect");
            }
        }

        static void Subtraction()
        {
            (int firstNumber, int secondNumber) = GetRandomNumbers();
            Console.WriteLine($"What is {firstNumber} - {secondNumber}:");
            int actualResult = firstNumber - secondNumber;
            int userResult = GetNumberInput("\n\nPlease type your result. Type 0 to return to Main Menu\n\n");
            
            if (actualResult == userResult)
            {
                Console.WriteLine("Correct");
                Games.Add("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
                Games.Add("Incorrect");
            }
        }

        static void Division()
        {
            (int firstNumber, int secondNumber) = GetRandomNumbers();

            while (!(firstNumber % secondNumber == 0))
            {
                (firstNumber, secondNumber) = GetRandomNumbers();
            }

            Console.WriteLine($"What is {firstNumber} / {secondNumber}:");
            int actualResult = firstNumber / secondNumber;
            int userResult = GetNumberInput("\n\nPlease type your result. Type 0 to return to Main Menu\n\n");

            if (actualResult == userResult)
            {
                Console.WriteLine("Correct");
                Games.Add("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
                Games.Add("Incorrect");
            }
        }

        static void Multiplication()
        {
            (int firstNumber, int secondNumber) = GetRandomNumbers();
            Console.WriteLine($"What is {firstNumber} x {secondNumber}:");
            int actualResult = firstNumber * secondNumber;
            int userResult = GetNumberInput("\n\nPlease type your result. Type 0 to return to Main Menu\n\n");

            if (actualResult == userResult)
            {
                Console.WriteLine("Correct");
                Games.Add("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
                Games.Add("Incorrect");
            }            
        }

        private static void GamesResults()
        {
            Console.WriteLine("The results of each game are:");
            for (int i = 0; i < Games.Count; i++)
            {
                 Console.WriteLine($"Game {i}, {Games[i]}");
            }
        }

        static int GetNumberInput(string message)
        {
            Console.WriteLine(message);
            string numberInput = Console.ReadLine();
            if (numberInput == "q") GetUserInput();

            while (!Int32.TryParse(numberInput, out _) || Convert.ToInt32(numberInput) < 0)
            {
                Console.WriteLine("\n\nInvalid number. Try again.\n\n");
                numberInput = Console.ReadLine();
            }

            int finalInput = Convert.ToInt32(numberInput);
            return finalInput;
        }

        static (int firstNumber, int secondNumber) GetRandomNumbers()
        {
            var random = new Random();
            int firstNumber = random.Next(1, 9);
            int secondNumber = random.Next(1, 9);

            return (firstNumber, secondNumber);
        }
    }
}
