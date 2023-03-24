using System;
using System.Collections.Generic;

namespace MathGame
{
    public class Game
    {
        // This method displays the menu options for the game
        private static void LogMenuChoices()
        {
            Console.WriteLine("Welcome to the Math Game!");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. View Scores");
            Console.WriteLine("3. Exit");
        }

        // This method runs the random math game
        public static void RandomGame()
        {
            int score = 0; // The player's score starts at 0
            int lives = 3; // The player has three lives initially
            int questionNumber = 1; // The first question number is 1
            int answer; // Variable to store player's answer

            Random random = new Random(); // Create a new instance of Random class

            List<int> scoresList = new List<int>(); // Create a list to store player's scores

            while (true)
            {
                LogMenuChoices(); // Display menu options

                string userInput = Console.ReadLine(); // Get user input from console

                if (userInput == "1") // If user selects option 1, start game
                {
                    while (lives > 0)
                    {
                        int firstNumber = random.Next(0, 101); // Generate a random number between 0 and 100 for first operand of equation 
                        int secondNumber = random.Next(1, 101); // Generate a random number between 1 and 100 for second operand of equation 

                        string operationSymbol;
                        int correctAnswer;

                        switch (random.Next(1, 5))
                        {
                            case 1:
                                operationSymbol = "+";
                                correctAnswer = MathOperations.AddNumbers(firstNumber, secondNumber); // Call AddNumbers method from MathOperations class to get correct answer
                                break;

                            case 2:
                                operationSymbol = "-";
                                correctAnswer = MathOperations.SubtractNumbers(firstNumber, secondNumber); // Call SubtractNumbers method from MathOperations class to get correct answer
                                break;

                            case 3:
                                operationSymbol = "*";
                                correctAnswer = MathOperations.MultiplyNumbers(firstNumber, secondNumber); // Call MultiplyNumbers method from MathOperations class to get correct answer
                                break;

                            case 4:
                                operationSymbol = "/";
                                correctAnswer = MathOperations.DivideNumbers(firstNumber, secondNumber); // Call DivideNumbers method from MathOperations class to get correct answer
                                break;

                            default:
                                operationSymbol = "";
                                correctAnswer = 0;
                                break;
                        }

                        Console.WriteLine($"Question {questionNumber}: {firstNumber} {operationSymbol} {secondNumber} = ?"); // Display the question number and equation

                        answer = Convert.ToInt32(Console.ReadLine()); // Get player's answer from console and convert it to an integer

                        if (answer == correctAnswer) // If player's answer is correct
                        {
                            Console.WriteLine("Correct!");
                            score++; // Increment player's score by 1
                        }
                        else
                        {
                            Console.WriteLine("Incorrect!");
                            lives--; // Decrement player's lives by 1
                        }

                        questionNumber++; // Increment question number by 1 for next iteration of while loop
                    }

                    scoresList.Add(score); // Add player's score to scoresList

                    Console.WriteLine($"Game Over! Your score is {score}");

                    score = 0; // Reset player's score to 0 for next game
                    lives = 3; // Reset player's lives to 3 for next game 
                    questionNumber = 1; // Reset question number to 1 for next game
                }
                else if (userInput == "2") // If user selects option 2, display scores
                {
                    if (scoresList.Count == 0) // If scoresList is empty
                    {
                        Console.WriteLine("No scores yet!");
                    }
                    else
                    {
                        Console.WriteLine("Scores:");
                        foreach (int s in scoresList) // Iterate through scoresList and display each score
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
                else if (userInput == "3") // If user selects option 3, exit the game
                {
                    break;
                }
            }
        }
    }
}