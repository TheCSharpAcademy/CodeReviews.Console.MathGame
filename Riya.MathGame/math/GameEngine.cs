using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using math.Models;
using static math.Models.Game;
namespace math
{
    internal class GameEngine
    {
        internal void Addition()
        {
            Console.Clear();
            Console.WriteLine("Addition game selected");
            var random = new Random();
            int firstNumber;
            int secondNumber;
            var score = 0;
            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} + {secondNumber} = ?");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }




            }
           
            Helpers.AddToHistory(score, GameType.Addition);
        }


        internal void Subtraction()
        {
            Console.Clear();
            Console.WriteLine("Subtraction game Selected");
            var random = new Random();
            int firstNumber;
            int secondNumber;
            var score = 0;
            for (int i = 0; i < 3; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} - {secondNumber} = ?");
                var result = Console.ReadLine();
                //bool isValidInput = int.TryParse(result, out int userInput);
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }




            }
            Helpers.AddToHistory(score, GameType.Subtraction);
        }
        internal void Multiplication()
        {
            Console.Clear();

            Console.WriteLine("Multiplication game selected");
            var random = new Random();
            int firstNumber;
            int secondNumber;
            var score = 0;
            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} * {secondNumber} = ?");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }



            }
            Helpers.AddToHistory(score, GameType.Multiplication);
          
        }

        internal void Division()
        {
            Console.Clear();
            Console.WriteLine("Division game selected");
            var score = 0;
            for (int i = 0; i < 5; i++)
            {
                var divisionNumber = Helpers.GetDivisionNumber();
                int firstNumber = divisionNumber[0];
                int secondNumber = divisionNumber[1];
                Console.WriteLine($"{firstNumber} / {secondNumber} = ?");
                var result = Console.ReadLine();
                //bool isValidInput = int.TryParse(result, out int userInput);
                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer was correct! Type any key for the next question");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer was incorrect. Type any key for the next question");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Press any key to go back to the main menu.");
                    Console.ReadLine();
                }



            }
            Helpers.AddToHistory(score, GameType.Division);
           
        }
    }
}
