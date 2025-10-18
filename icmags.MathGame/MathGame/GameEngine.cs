using MathGame.Models;

namespace MathGame
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            int firstNumber;
            int secondNumber;
            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = Helpers.random.Next(1, 9);
                secondNumber = Helpers.random.Next(1, 9);
                Console.WriteLine($"{firstNumber} + {secondNumber}");

                string answer = Console.ReadLine();
                answer = Helpers.ValidateAnswer(answer);
                
                if (int.Parse(answer) == (firstNumber + secondNumber))
                {
                    Console.WriteLine("Your answer is correct. Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer is wrong. Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Type any key to go back to main menu.");
                    Console.ReadLine();
                }
            }
            Helpers.AddHistory(score, GameType.Addition);
        }
        internal void SubtractionGame(string message)
        {
            int firstNumber;
            int secondNumber;
            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = Helpers.random.Next(1, 9);
                secondNumber = Helpers.random.Next(1, 9);
                Console.WriteLine($"{firstNumber} - {secondNumber}");
                string answer = Console.ReadLine();
                answer = Helpers.ValidateAnswer(answer); ;

                if (int.Parse(answer) == (firstNumber - secondNumber))
                {
                    Console.WriteLine("Your answer is correct. Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer is wrong. Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Type any key to go back to main menu.");
                    Console.ReadLine();
                }
            }
            Helpers.AddHistory(score, GameType.Subtraction);
        }
        internal void MultiplicationGame(string message)
        {
            int firstNumber;
            int secondNumber;
            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = Helpers.random.Next(1, 9);
                secondNumber = Helpers.random.Next(1, 9);
                Console.WriteLine($"{firstNumber} * {secondNumber}");
                string answer = Console.ReadLine();
                answer = Helpers.ValidateAnswer(answer);

                if (int.Parse(answer) == (firstNumber * secondNumber))
                {
                    Console.WriteLine("Your answer is correct. Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer is wrong. Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Type any key to go back to main menu.");
                    Console.ReadLine();
                }
            }
            Helpers.AddHistory(score, GameType.Multiplication);
        }
        internal void DivisionGame(string message)
        {
            int[] divisionNumber;
            int score = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                divisionNumber = Helpers.GetDivisionNumbers();
                Console.WriteLine($"{divisionNumber[0]} / {divisionNumber[1]}");
                string answer = Console.ReadLine();
                answer = Helpers.ValidateAnswer(answer);

                if (int.Parse(answer) == (divisionNumber[0] / divisionNumber[1]))
                {
                    Console.WriteLine("Your answer is correct. Type any key for the next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Your answer is wrong. Type any key for the next question.");
                    Console.ReadLine();
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over. Your final score is {score}. Type any key to go back to main menu.");
                    Console.ReadLine();
                }
            }
            Helpers.AddHistory(score, GameType.Division);
        }
    }
}
