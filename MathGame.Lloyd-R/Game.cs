using System;
using System.Collections.Generic;

namespace MathGame
{
    public class Game
    {
        public static void RandomGame()
        {
            int score = 0;
            int lives = 3;
            int questionNumber = 1;
            int answer;
            Random random = new Random();

            List<int> scoresList = new List<int>();

            while (true)
            {
                Console.WriteLine("Welcome to the Math Game!");
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. View Scores");
                Console.WriteLine("3. Exit");

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    while (lives > 0)
                    {
                        int firstNumber = random.Next(0, 101);
                        int secondNumber = random.Next(1, 101);

                        string operationSymbol;
                        int correctAnswer;

                        // Generate question based on random operation
                        switch (random.Next(1, 5))
                        {
                            case 1:
                                operationSymbol = "+";
                                correctAnswer = AddNumbers(firstNumber, secondNumber);
                                break;

                            case 2:
                                operationSymbol = "-";
                                correctAnswer = SubtractNumbers(firstNumber, secondNumber);
                                break;

                            case 3:
                                operationSymbol = "*";
                                correctAnswer = MultiplyNumbers(firstNumber, secondNumber);
                                break;

                            case 4:
                                operationSymbol = "/";
                                correctAnswer = DivideNumbers(firstNumber, secondNumber);
                                break;

                            default:
                                operationSymbol = "";
                                correctAnswer = 0;
                                break;
                        }

                        Console.WriteLine($"Question {questionNumber}: {firstNumber} {operationSymbol} {secondNumber} = ?");
                        answer = Convert.ToInt32(Console.ReadLine());

                        if (answer == correctAnswer)
                        {
                            Console.WriteLine("Correct!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect!");
                            lives--;
                        }

                        questionNumber++;
                    }

                    scoresList.Add(score);

                    Console.WriteLine($"Game Over! Your score is {score}");

                    score = 0;
                    lives = 3;
                    questionNumber = 1;
                }
                else if (userInput == "2")
                {
                    if (scoresList.Count == 0)
                    {
                        Console.WriteLine("No scores yet!");
                    }
                    else
                    {
                        Console.WriteLine("Scores:");
                        foreach (int s in scoresList)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
                else if (userInput == "3")
                {
                    break;
                }
            }
        }

        private static int AddNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        private static int SubtractNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }

        private static int MultiplyNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        private static int DivideNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}