using Math.Models;


namespace Math
{
    internal class Operators
    {
        internal static void Addition(string message, int questions)
        {
            Console.Clear();
            Console.WriteLine(message);

            int firstNumber;
            int secondNumber;
            int correctAnswer;
            int score = 0;
            TimeSpan startTime = DateTime.Now.TimeOfDay;


            for (int i = 0; i < questions; i++)
            {
                var random = new Random();
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                correctAnswer = firstNumber + secondNumber;
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                string? result = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(result) || !Int32.TryParse(result, out _))
                {
                    Console.WriteLine("Please enter a valid input");
                    result = Console.ReadLine();
                }
                if (int.Parse(result) == correctAnswer)
                {
                    Console.WriteLine("Your Answer is Correct, press any key to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You Answer is Incorrect, press any key to continue");
                    Console.ReadLine();
                }

                if (i == 4) Console.WriteLine($"Game Over! your score is {score}");
            }
            TimeSpan endTime = DateTime.Now.TimeOfDay;
            var timeTaken = endTime - startTime;
            Console.WriteLine($"This took you {timeTaken} to complete");

            HelperMethods.AddHistory(score, GameType.Addition, questions, timeTaken);
        }

        internal static void Subtraction(string message, int questions)
        {
            Console.Clear();
            Console.WriteLine(message);

            int firstNumber;
            int secondNumber;
            int correctAnswer;
            int score = 0;
            TimeSpan startTime = DateTime.Now.TimeOfDay;
            for (int i = 0; i < questions; i++)
            {
                var random = new Random();
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                correctAnswer = firstNumber - secondNumber;
                Console.WriteLine($"{firstNumber} - {secondNumber}");
                string? result = Console.ReadLine();
                if (int.Parse(result) == correctAnswer)
                {
                    Console.WriteLine("Your Answer is Correct, press any key to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You Answer is Incorrect, press any key to continue");
                    Console.ReadLine();
                }
                if (i == 4) Console.WriteLine($"Game Over! your score is {score}");
            }
            TimeSpan endTime = DateTime.Now.TimeOfDay;
            var timeTaken = endTime - startTime;
            Console.WriteLine($"This took you {timeTaken} to complete");

            HelperMethods.AddHistory(score, GameType.Subtraction, questions, timeTaken);
        }

        internal static void Multiplication(string message, int questions)
        {
            Console.Clear();
            Console.WriteLine(message);

            int firstNumber;
            int secondNumber;
            int correctAnswer;
            int score = 0;
            TimeSpan startTime = DateTime.Now.TimeOfDay;

            for (int i = 0; i < questions; i++)
            {
                var random = new Random();
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);
                correctAnswer = firstNumber * secondNumber;
                Console.WriteLine($"{firstNumber} * {secondNumber}");
                string? result = Console.ReadLine();
                if (int.Parse(result) == correctAnswer)
                {
                    Console.WriteLine("Your Answer is Correct, press any key to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You Answer is Incorrect, press any key to continue");
                    Console.ReadLine();
                }
                if (i == 4) Console.WriteLine($"Game Over! your score is {score}");
            }
            TimeSpan endTime = DateTime.Now.TimeOfDay;
            var timeTaken = endTime - startTime;
            Console.WriteLine($"This took you {timeTaken} to complete");

            HelperMethods.AddHistory(score, GameType.Multiplication, questions, timeTaken);
        }

        internal static void Division(string message, int questions)
        {
            Console.Clear();
            Console.WriteLine(message);
            int score = 0;
            TimeSpan startTime = DateTime.Now.TimeOfDay;
            for (int i = 0; i < questions; i++)
            {
                var divisionNumbers = HelperMethods.GetDivisionNumbers();
                var firstNumber = divisionNumbers[0];
                var secondNumber = divisionNumbers[1];
                var correctAnswer = firstNumber / secondNumber;


                Console.WriteLine($"{firstNumber} / {secondNumber}");
                string? result = Console.ReadLine();
                if (int.Parse(result) == correctAnswer)
                {
                    Console.WriteLine("Your Answer is Correct, press any key to continue");
                    score++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You Answer is Incorrect, press any key to continue");
                    Console.ReadLine();
                }
                if (i == 4) Console.WriteLine($"Game Over! your score is {score}");
            }
            TimeSpan endTime = DateTime.Now.TimeOfDay;
            var timeTaken = endTime - startTime;
            Console.WriteLine($"This took you {timeTaken} to complete");

            HelperMethods.AddHistory(score, GameType.Division, questions, timeTaken);

        }


    }
}


