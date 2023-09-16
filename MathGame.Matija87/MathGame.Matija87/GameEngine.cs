namespace MathGame.Matija87
{
    internal static class GameEngine
    {
        public static void Addition()
        {
            Random random = new Random();
            Console.WriteLine("Addition game");
            Console.WriteLine("-------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
                Console.WriteLine($"{firstNumber} + {secondNumber}");
                
                do
                {
                    result = Console.ReadLine();
                } while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _));

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    score++;
                    Console.WriteLine($"Correct! Your score is {score} / {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Your score is {score} / {i + 1}");
                }
            }
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
        }

        public static void Subtraction()
        {
            Random random = new Random();
            Console.WriteLine("Subtraction game");
            Console.WriteLine("-----------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
                Console.WriteLine($"{firstNumber} - {secondNumber}");

                do
                {
                    result = Console.ReadLine();
                } while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _));

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    score++;
                    Console.WriteLine($"Correct! Your score is {score} / {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Your score is {score} / {i + 1}");
                }
            }
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
        }

        public static void Multiplication()
        {
            Random random = new Random();
            Console.WriteLine("Multiplication game");
            Console.WriteLine("--------------------");

            int firstNumber;
            int secondNumber;
            int score = 0;
            string? result;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
                Console.WriteLine($"{firstNumber} * {secondNumber}");

                do
                {
                    result = Console.ReadLine();
                } while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _));

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    score++;
                    Console.WriteLine($"Correct! Your score is {score} / {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Your score is {score} / {i + 1}");
                }
            }
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
        }

        public static void Division()
        {
            Random random = new Random();
            Console.WriteLine("Division game");
            Console.WriteLine("-------------");

            int firstNumber = 0;
            int secondNumber = 0;
            int score = 0;
            string? result;

            for (int i = 0; i < 5; i++)
            {
                int[] divisionNumbers = GetDivisionNumbers();
                firstNumber = divisionNumbers[0];
                secondNumber = divisionNumbers[1];


                Console.WriteLine($"{firstNumber} / {secondNumber}");

                do
                {
                    result = Console.ReadLine();
                } while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _));

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    score++;
                    Console.WriteLine($"Correct! Your score is {score} / {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Your score is {score} / {i + 1}");
                }
            }
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
        }

        static int[] GetDivisionNumbers()
        {
            Random random = new Random();
            int firstNumber = random.Next(0, 99);
            int secondNumber = random.Next(1, 99); //Prevents dividing by 0

            int[] result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(0, 99);
                secondNumber = random.Next(1, 99); 
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }
    }
}
