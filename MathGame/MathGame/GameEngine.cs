namespace MathGame.Models
{
    internal class GameEngine
    {
        internal void AdditionGame(string message)
        {
            Console.WriteLine(message);
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);
               
                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("Correct! Type any key for next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong! Type any key for next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Your game is over. You final score is {score} Type any key to return to the main menu.");
                    Console.ReadLine();
                }

            }

            Helpers.AddToHistory(score, GameType.Addition);
        }

        internal void SubtractionGame(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(message);
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("Correct! Type any key for next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong! Type any key for next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Your game is over. You final score is {score} Type any key to return to the main menu.");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Subtraction);

        }
        internal void MultiplicationGame(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(message);
            var random = new Random();
            var score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(message);
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();

                result = Helpers.ValidateResult(result);

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("Correct! Type any key for next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong! Type any key for next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Your game is over. You final score is {score} Type any key to return to the main menu.");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Multiplication);

        }
        internal void DivisionGame(string message)
        {
            Console.WriteLine(message);
            Helpers.GetDivisionNumbers();
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
                    Console.WriteLine("Correct! Type any key for next question.");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong! Type any key for next question.");
                    Console.ReadLine();
                }
                if (i == 4)
                {
                    Console.WriteLine($"Your game is over. You final score is {score} Type any key to return to the main menu.");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, GameType.Division);
        }
    }
}
