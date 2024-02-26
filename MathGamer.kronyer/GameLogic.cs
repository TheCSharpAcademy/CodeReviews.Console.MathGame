using System;
using System.Globalization;

using static MathGamer.Models.Game;

namespace MathGamer
{
    internal class GameLogic
    {
        public void AdditionGame(string message)
        {
            int score = 0;
            Console.WriteLine(message);

            var random = new Random();
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);


                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score += 10;
                }
                else
                {
                    Console.WriteLine("Sorry, thats not the answer...");
                }

                if (i == 4)
                {
                    Console.WriteLine($"Your score was: {score}");
                }


            }
            Helpers.AddToHistory(score, GameType.Addition);
        }

        public void SubtractionGame(string message)
        {

            int score = 0;
            Console.WriteLine(message);

            var random = new Random();
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);


                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score += 10;
                }
                else
                {
                    Console.WriteLine("Sorry, thats not the answer...");
                }

                if (i == 4)
                {
                    Console.WriteLine($"Your score was: {score}");
                }


            }
            Helpers.AddToHistory(score, GameType.Subtraction);


        }

        public void MultiplicationGame(string message)
        {
            int score = 0;
            Console.WriteLine(message);

            var random = new Random();
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Correct!");
                    score += 10;
                }
                else
                {
                    Console.WriteLine("Sorry, thats not the answer...");
                }

                if (i == 4)
                {
                    Console.WriteLine($"Your score was: {score}");
                }


            }
            Helpers.AddToHistory(score, GameType.Multiplication);
        }

        public void DivisionGame(string message)
        {
            int score = 0;

            
                Console.WriteLine(message);
                for (int i = 0; i < 5; i++)
                {
                    var divisionNumbers = Helpers.GetDivisionNumbers();
                    int firstNumber = divisionNumbers[0];
                    int secondNumber = divisionNumbers[1];

                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    var result = Console.ReadLine();
                    result = Helpers.ValidateResult(result);


                    if (int.Parse(result) == firstNumber / secondNumber)
                    {
                        Console.WriteLine("Correct!");
                        score += 10;
                    }
                    else
                    {
                        Console.WriteLine("Sorry thats not the answer");
                    }

                    if (i == 4)
                    {
                        Console.WriteLine($"Your final score was {score}");
                    }
                }
                Helpers.AddToHistory(score, GameType.Division);

            }
           

            }
        }
    
