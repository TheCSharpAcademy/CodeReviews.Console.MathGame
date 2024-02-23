using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Console.WriteLine("Do you want to play with only integers (I) or whatever (W)?");
            string opt = Console.ReadLine().ToLower().Trim();

            while (opt != "i" && opt != "w")
            {
                Console.WriteLine("Enter a valid input (I) for only integers, or (W) for whatever");
                opt = Console.ReadLine().ToLower().Trim();
            }
            if (opt == "i")
            {
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
            else if (opt == "w")
            {
                Console.WriteLine(message);
                Console.WriteLine("obs: The numbers are rounded to the first two decimal cases, so type numbers like 2,50, also, use commas, not dots");

                var random = new Random();
                double firstNumber;
                double secondNumber;

                for (int i = 0; i < 5; i++)
                {
                    firstNumber = double.Parse(random.Next(1, 9).ToString("F1"));
                    secondNumber = double.Parse(random.Next(1, 9).ToString("F1"));
                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    double result = double.Parse(Console.ReadLine().ToString(CultureInfo.InvariantCulture));
                    double divresult = Math.Round(firstNumber / secondNumber, 2);
                    if (result == divresult)
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
                Helpers.AddToHistory(score, GameType.Division);

            }


        }

    }



}
