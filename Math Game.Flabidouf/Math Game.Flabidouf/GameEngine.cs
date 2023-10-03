using Math_Game_v2.Models;

namespace Math_Game_v2;

public class GameEngine
{
   internal void AdditionGame(string message)
        {
            Random rand = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;


            for (int i = 0; i < 5; i++) // N° of questions.
            {
                Console.Clear();
                Console.WriteLine(message);
                
                firstNumber = rand.Next(1, 9);
                secondNumber = rand.Next(1, 9);
                
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);
                
                
                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Your answer is correct. Type any key to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect. Type any key to continue");
                    Console.ReadLine();
                }
                if(i == 4) Console.WriteLine($"Game over. Your score is {score}. Press any key to go back to the main menu.");
                
            }
            Helpers.AddToHistory(score, GameType.Addition); // Record n° of games.
        }

    internal void SubtractionGame(string message)
        {
            Random rand = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;


            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                
                firstNumber = rand.Next(1, 9);
                secondNumber = rand.Next(1, 9);
                
                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);
                
                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Your answer is correct. Type any key to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect. Type any key to continue");
                    Console.ReadLine();
                }
                
                if(i == 4) Console.WriteLine($"Game over. Your score is {score}. Press any key to go back to the main menu.");
            }

            Helpers.AddToHistory(score, GameType.Subtraction); // Record n° of games.
        }

    internal void MultiplicationGame(string message)
        {
            Random rand = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;


            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                
                firstNumber = rand.Next(1, 9);
                secondNumber = rand.Next(1, 9);
                
                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);
                
                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Your answer is correct. Type any key to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect. Type any key to continue");
                    Console.ReadLine();
                }
                if(i == 4) Console.WriteLine($"Game over. Your score is {score}. Press any key to go back to the main menu.");
                Console.ReadLine();
            }
            Helpers.AddToHistory(score, GameType.Multiplication); // Record n° of games.
        }

    internal void DivisionGame(string message)
        {
            var score = 0;
            
            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                
                var divisionNumbers = Helpers.GetDivisionNumbers();
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("Your answer is correct. Type any key to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer is incorrect. Type any key to continue");
                    Console.ReadLine();
                }
                
                if(i == 4) Console.WriteLine($"Game over. Your score is {score}. Press any key to go back to the main menu.");
            } 
            Helpers.AddToHistory(score, GameType.Division); // Record n° of games.
        }
}