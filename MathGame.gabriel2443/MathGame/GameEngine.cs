namespace MathGame
{
    internal class GameEngine
    {
        internal Helpers helpers = new();

        internal void Addition(string message)
        {
            Console.WriteLine(message);
            Console.Clear();
            int score = 0;
            for (int i = 0; i < 2; i++)
            {
                var random = new Random();

                int firstNum = random.Next(1, 10);

                int secondNum = random.Next(1, 10);

                Console.WriteLine($"{firstNum} + {secondNum}");

                var result = Console.ReadLine();

                result = Helpers.Validate(result);

                if (int.Parse(result) == firstNum + secondNum)
                {
                    Console.WriteLine("\n You are correct");
                    score++;
                }
                else Console.WriteLine("\n You are incorrect");

                if (i == 1)
                {
                    Console.WriteLine($"\n Your score is {score}. Type any key to go back to main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, "Addition");
        }

        internal void Subtraction(string message)
        {
            Console.WriteLine(message);
            Console.Clear();
            int score = 0;
            for (int i = 0; i < 2; i++)
            {
                var random = new Random();

                int firstNum = random.Next(1, 10);

                int secondNum = random.Next(1, 10);

                Console.WriteLine($"{firstNum} - {secondNum}");

                var result = Console.ReadLine();
                result = Helpers.Validate(result);

                if (int.Parse(result) == firstNum - secondNum)
                {
                    Console.WriteLine("\n You are correct");
                    score++;
                }
                else Console.WriteLine("\n You are incorrect");

                if (i == 1)
                {
                    Console.WriteLine($"\n Your score is {score}. Type any key to go back to main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, "Subtraction");
        }

        internal void Multiplication(string message)
        {
            Console.WriteLine(message);
            Console.Clear();
            int score = 0;
            for (int i = 0; i < 2; i++)
            {
                var random = new Random();

                int firstNum = random.Next(1, 10);

                int secondNum = random.Next(1, 10);

                Console.WriteLine($"{firstNum} * {secondNum}");

                var result = Console.ReadLine();
                result = Helpers.Validate(result);

                if (int.Parse(result) == firstNum * secondNum)
                {
                    Console.WriteLine("\n You are correct");
                    score++;
                }
                else Console.WriteLine("\n You are incorrect");

                if (i == 1)
                {
                    Console.WriteLine($"\n Your score is {score}. Type any key to go back to main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, "Multiplication");
        }

        internal void Division(string message)
        {
            Console.WriteLine(message);
            Console.Clear();
            int score = 0;
            for (int i = 0; i < 2; i++)
            {
                var divisionNumbers = Helpers.GetDivisionNumbers();

                int firstNum = divisionNumbers[0];

                int secondNum = divisionNumbers[1];

                Console.WriteLine($"{firstNum} / {secondNum}");

                var result = Console.ReadLine();
                result = Helpers.Validate(result);

                if (int.Parse(result) == firstNum / secondNum)
                {
                    Console.WriteLine("\n You are correct");
                    score++;
                }
                else Console.WriteLine("\n You are incorrect");

                if (i == 1)
                {
                    Console.WriteLine($"\n Your score is {score}. Type any key to go back to main menu");
                    Console.ReadLine();
                }
            }

            Helpers.AddToHistory(score, "Division");
        }
    }
}