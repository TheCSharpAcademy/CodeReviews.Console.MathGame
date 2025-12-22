namespace MathGame
{
    internal class Program
    {
        private static Random random = new Random();
        private static List<int> Scores = new List<int>();
        private static int numberOfQuestions = 5;
        static void Main(string[] args)
        {
            string playerName = ReadPlayerName();
            WelcomeMessage(playerName);
            DisplayMenu();
            ReadMenuChoice();
        }

        private static void WelcomeMessage(string _playerName)
        {
            Console.WriteLine($"Hello {_playerName}");
            Console.WriteLine("You are going to try to asnwer few simple math questions. We will start with 5 questions");
            Console.WriteLine("Each correct answer gives you 1 points, while incorrect gives you 0");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private static string ReadPlayerName()
        {
            while (true)
            {
                Console.WriteLine("Welcome to the math game!");
                Console.WriteLine("Input your name");
                string _playerName = Console.ReadLine();
                if (!string.IsNullOrEmpty(_playerName))
                {
                    Console.Clear();
                    return _playerName;
                }
                Console.WriteLine("Invalid name, please enter a valid one");
            }
        }
        private static void DisplayMenu()
        {
            Console.WriteLine("----Math Game----");
            Console.WriteLine("Press 1 to answer questions about additions of numbers (+)");
            Console.WriteLine("Press 2 to answer questions about subtraction of numbers (-)");
            Console.WriteLine("Press 3 to answer questions about multiplication of numbers(*)");
            Console.WriteLine("Press 4 to answer questions about division of numbers (/)");
            Console.WriteLine("Press 5 to answer questions about random operations");
            Console.WriteLine("Press 6 to view your history");
            Console.WriteLine("Press 7 to change number of questions to make the game harder / easier");
            Console.WriteLine("Press 0 to exit the program");
        }
        private static void ReadMenuChoice()
        {
            Console.Clear();
            bool exit = false;
            char operation;
            while (!exit)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        operation = '+';
                        BeginMathQuestions(operation);
                        break;
                    case "2":
                        operation = '-';
                        BeginMathQuestions(operation);
                        break;
                    case "3":
                        operation = '*';
                        BeginMathQuestions(operation);
                        break;
                    case "4":
                        operation = '/';
                        BeginMathQuestions(operation);
                        break;
                    case "5":
                        operation = '#';
                        BeginMathQuestions(operation);
                        break;
                    case "6":
                        Console.Clear();
                        ViewHistory(Scores);
                        break;
                    case "7":
                        SetNumberOfQuestions();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please enter a valid one");
                        break;
                }
            }
        }
        private static void BeginMathQuestions(char operation)
        {
            DateTime startTime = DateTime.Now;
            int score = 0;
            char[] validOperations = { '+', '-', '*', '/' };
            bool randomOperationValue = false;

            if (operation == '#')
            {
                randomOperationValue = true;
            }

            for (int i = 0; i < numberOfQuestions; i++)
            {
                int a, b, result;

                if (randomOperationValue == true)
                {
                    operation = validOperations[random.Next(validOperations.Length)];
                }

                if (operation == '/')
                {
                    b = random.Next(1, 101);
                    int quotient = random.Next(1, 11);
                    a = b * quotient;
                    result = quotient;
                }
                else
                {
                    a = RandomNumberTo100();
                    b = RandomNumberTo100();
                }

                if (operation == '+')
                {
                    result = a + b;
                }
                else if (operation == '-')
                {
                    result = a - b;
                }
                else if (operation == '*')
                {
                    result = a * b;
                }
                else
                {
                    result = a / b;
                }

                Console.WriteLine($"A equals {a}");
                Console.WriteLine($"B equals {b}");
                Console.WriteLine($"A {operation} B =");

                int playerResult = ReadPlayerResult();

                if (playerResult == result)
                {
                    Console.Write("Correct\n");
                    score++;
                }
                else
                {
                    Console.WriteLine($"Wrong, your asnwer was {playerResult}");
                    Console.WriteLine($"Correct asnwer was {result}\n");

                }
            }
            DisplayScore(score, startTime);
        }

        private static void DisplayScore(int score, DateTime startTime)
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Your final score is {score}");
            AddScoreToHistory(score);

            DateTime endTime = DateTime.Now;
            TimeSpan timePassed = endTime.Subtract(startTime);
            var outputTimePassed = $"{(int)timePassed.TotalMinutes}:{timePassed.Seconds:00}";

            Console.WriteLine($"It took you {outputTimePassed} to answer those questions");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        private static int RandomNumberTo100()
        {
            return random.Next(1, 101);
        }
        private static void AddScoreToHistory(int score)
        {
            Scores.Add(score);
        }
        private static int ReadPlayerResult()
        {
            int playerNumber;
            while (true)
            {
                Console.WriteLine("Enter the result");
                bool _validNumber = int.TryParse(Console.ReadLine(), out playerNumber);

                if (_validNumber)
                {
                    return playerNumber;
                }
                else
                {
                    Console.WriteLine("Invalid number, please try again");
                }
            }
        }
        private static void ViewHistory(List<int> scores)
        {
            if (scores.Count == 0)
            {
                Console.WriteLine("History is empty, start playing already!");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.WriteLine("Your scores are");

            foreach (var score in scores)
            {
                Console.WriteLine(score);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        private static void SetNumberOfQuestions()
        {

            while (true)
            {
                Console.WriteLine("You can change number of questions to make the game harder/easier!");
                Console.WriteLine("Input what amount of questions you would like to answer (at least 5)");
                Console.WriteLine($"Current number of questions is {numberOfQuestions}");

                if(TryGetValidNumber(out int newValue))
                {
                    numberOfQuestions = newValue;
                    Console.Clear();
                    break;
                }
                Console.WriteLine("Invalid number, try again");
            }
        }

        private static bool TryGetValidNumber(out int result)
        {
            if(int.TryParse(Console.ReadLine(), out int value) && value >= 5)
            {
                result = value;
                return true;
            }
            result = default;
            return false;
        }
    }
}
