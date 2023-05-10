namespace mathGame.batista92;

internal class Program
{
    static void Main(string[] args)
    {
        DateTime date = DateTime.UtcNow;

        string name = GetName();

        Menu(name, date);

        static string GetName()
        {
            Console.Clear();
            Console.WriteLine("Please type your name");
            string name = Console.ReadLine();
            return name;
        }

        void Menu(string name, DateTime date)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Hello {name}. It's {date}. This is your math's game. That's great that you're working on improving yourself");
            Console.WriteLine();

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play today? Choose from the options below:
                A - Addition
                S - Subtraction
                M - Multiplication
                D - Division
                Q - Quit the program");
                Console.WriteLine("---------------------------------------------------");

                string gameSelected = Console.ReadLine();
                switch (gameSelected.Trim().ToLower())
                {
                    case "a":
                        AdditionGame("AdditionGame");
                        break;
                    case "s":
                        SubtractionGame("Subtraction");
                        break;
                    case "m":
                        MultiplicationGame("Multiplication");
                        break;
                    case "d":
                        DivisionGame("Division");
                        break;
                    case "q":
                        Console.Clear();
                        Console.WriteLine("See you later!");
                        isGameOn = false;
                        break;
                    default: 
                        Console.WriteLine("Invalid input, Try again...");
                        break;
                }

            } while (isGameOn);
        }

        void AdditionGame(string msg)
        {
            Random random = new Random();
            int score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(msg);

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} + {secondNumber}");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber + secondNumber)
                {
                    Console.WriteLine("You answer was correct! Type any key for next question");
                    score++;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Your answer war incorrect. Type any key for next question");
                    Console.ReadKey();
                }
            }

            Console.WriteLine($"Game over! Your final score is: {score}");
            Console.WriteLine("Type any key for return to the menu");
            Console.ReadKey();
        }

        void SubtractionGame(string msg)
        {
            Random random = new Random();
            int score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(msg);

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber}");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber - secondNumber)
                {
                    Console.WriteLine("You answer was correct! Type any key for next question");
                    score++;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Your answer war incorrect. Type any key for next question");
                    Console.ReadKey();
                }
            }

            Console.WriteLine($"Game over! Your final score is: {score}");
            Console.WriteLine("Type any key for return to the menu");
            Console.ReadKey();
        }

        void MultiplicationGame(string msg)
        {
            Random random = new Random();
            int score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(msg);

                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber}");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber * secondNumber)
                {
                    Console.WriteLine("You answer was correct! Type any key for next question");
                    score++;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Your answer war incorrect. Type any key for next question");
                    Console.ReadKey();
                }
            }

            Console.WriteLine($"Game over! Your final score is: {score}");
            Console.WriteLine("Type any key for return to the menu");
            Console.ReadKey();
        }

        void DivisionGame(string msg)
        {
            Random random = new Random();
            int score = 0;

            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                Console.Clear();
                Console.WriteLine(msg);

                var divisionNumbers = GetDivisionNumbers();
                firstNumber = divisionNumbers[0];
                secondNumber = divisionNumbers[1];

                Console.WriteLine($"{firstNumber} / {secondNumber}");
                var result = Console.ReadLine();

                if (int.Parse(result) == firstNumber / secondNumber)
                {
                    Console.WriteLine("You answer was correct! Type any key for next question");
                    score++;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Your answer war incorrect. Type any key for next question");
                    Console.ReadKey();
                }
            }

            Console.WriteLine($"Game over! Your final score is: {score}");
            Console.WriteLine("Type any key for return to the menu");
            Console.ReadKey();
        }

        int[] GetDivisionNumbers()
        {
            Random random = new Random();
            int firstNumber = random.Next(1, 99);
            int secondNumber = random.Next(1, 99);

            int[] result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;
            
            return result;
        }
    }
}