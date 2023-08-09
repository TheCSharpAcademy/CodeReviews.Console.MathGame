namespace MathGame
{
    internal class Calculation
    {
        static readonly Random _random = new();
        public static int score;

        internal static void Addition()
        {
            Console.WriteLine("You chose addition\n");

            var questions = 0;

            for (int i = 0; i < 10; i++)
            {
                int number1 = _random.Next(1, 10);
                int number2 = _random.Next(1, 10);
                Console.WriteLine($"{number1} + {number2}");
                int answer = int.Parse(Console.ReadLine());

                if (answer == number1 + number2)
                {
                    Console.Clear();
                    Console.WriteLine("That is correct!\n");
                    score++;
                    questions++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong answer!\n");
                    questions++;
                }                
                Console.WriteLine($"Score {score}/{questions}\n");
            }
            Console.WriteLine($"Your final score is: {score}\n");          
        }
        internal static void Subtraction()
        {
            Console.WriteLine("You chose subtraction\n");

            var questions = 0;

            for (int i = 0; i < 10; i++)
            {
                int number1 = _random.Next(2, 20);
                int number2 = _random.Next(1, 19);

                while (number1 < number2)                
                {
                    number2 = _random.Next(1, 20);
                }

                Console.WriteLine($"{number1} - {number2}");
                int answer = int.Parse(Console.ReadLine());

                if (answer == number1 - number2)
                {
                    Console.Clear();
                    Console.WriteLine("That is correct!\n");
                    score++;
                    questions++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong answer!\n");
                    questions++;
                }
                Console.WriteLine($"Score {score}/{questions}\n");
            }
            Console.WriteLine($"Your final score is: {score}\n");
        }
        internal static void Multiply()
        {
            Console.WriteLine("You chose addition\n");

            var questions = 0;

            for (int i = 0; i < 10; i++)
            {
                int number1 = _random.Next(1, 10);
                int number2 = _random.Next(1, 10);
                Console.WriteLine($"{number1} * {number2}");
                int answer = int.Parse(Console.ReadLine());

                if (answer == number1 * number2)
                {
                    Console.Clear();
                    Console.WriteLine("That is correct!\n");
                    score++;
                    questions++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong answer!\n");
                    questions++;
                }
                Console.WriteLine($"Score {score}/{questions}\n");
            }
            Console.WriteLine($"Your final score is: {score}\n");
        }
        internal static void Divide()
        {
            Console.WriteLine("You chose Divide\n");

            var questions = 0;

            for (int i = 0; i < 10; i++)
            {
                int number1 = _random.Next(1, 10);
                int number2 = _random.Next(1, 10);

                Console.WriteLine($"{number1*number2} / {number2}");
                int answer = int.Parse(Console.ReadLine());

                if (answer == ((number1*number2) / number2 ))
                {
                    Console.Clear();
                    Console.WriteLine("That is correct!\n");
                    score++;
                    questions++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong answer!\n");
                    questions++;
                }
                Console.WriteLine($"Score {score}/{questions}\n");
            }
            Console.WriteLine($"Your final score is: {score}\n");
        }
    }
}
