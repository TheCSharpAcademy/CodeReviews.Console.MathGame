namespace MathGame
{
    internal class GameEngine
    {
        private GameHistory _gameHistory;

        internal GameEngine(GameHistory gameHistory)
        {
            _gameHistory = gameHistory;
        }
        internal void AdditionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            Random random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} + {secondNumber}");

                string? readResult = Console.ReadLine();
                while (String.IsNullOrWhiteSpace(readResult))
                {
                    Console.WriteLine("Please make a guess");
                    readResult = Console.ReadLine();
                }
                readResult.ToLower().Trim();


                int answer;
                if (int.TryParse(readResult, out answer))
                {
                    if (answer == firstNumber + secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Press any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Press any key for the next question");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over! Your final score is: {score}. Press any key to go back to main menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            _gameHistory.AddToHistory(score, GameType.Addition);
        }

        internal void SubtractionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            Random random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} - {secondNumber}");

                string? readResult = Console.ReadLine();
                while (String.IsNullOrWhiteSpace(readResult))
                {
                    Console.WriteLine("Please make a guess");
                    readResult = Console.ReadLine();
                }
                readResult.ToLower().Trim();


                int answer;
                if (int.TryParse(readResult, out answer))
                {
                    if (answer == firstNumber - secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Press any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Press any key for the next question");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over! Your final score is: {score}. Press any key to go back to main menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            _gameHistory.AddToHistory(score, GameType.Subtraction);
        }

        internal void MultiplicationGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            Random random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                firstNumber = random.Next(1, 9);
                secondNumber = random.Next(1, 9);

                Console.WriteLine($"{firstNumber} * {secondNumber}");

                string? readResult = Console.ReadLine();
                while (String.IsNullOrWhiteSpace(readResult))
                {
                    Console.WriteLine("Please make a guess");
                    readResult = Console.ReadLine();
                }
                readResult.ToLower().Trim();


                int answer;
                if (int.TryParse(readResult, out answer))
                {
                    if (answer == firstNumber * secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Press any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Press any key for the next question");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over! Your final score is: {score}. Press any key to go back to main menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            _gameHistory.AddToHistory(score, GameType.Multiplication);
        }

        internal void DivisionGame(string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            Random random = new Random();
            int score = 0;
            int firstNumber;
            int secondNumber;

            for (int i = 0; i < 5; i++)
            {
                int[] divisionNumbers = Helpers.GetDivisionNumbers();
                firstNumber = divisionNumbers[0];
                secondNumber = divisionNumbers[1];


                Console.WriteLine($"{firstNumber} / {secondNumber}");

                string? readResult = Console.ReadLine();
                while (String.IsNullOrWhiteSpace(readResult))
                {
                    Console.WriteLine("Please make a guess");
                    readResult = Console.ReadLine();
                }
                readResult.ToLower().Trim();


                int answer;
                if (int.TryParse(readResult, out answer))
                {
                    if (answer == firstNumber / secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Press any key for the next question");
                        score++;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect. Press any key for the next question");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                if (i == 4)
                {
                    Console.WriteLine($"Game over! Your final score is: {score}. Press any key to go back to main menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            _gameHistory.AddToHistory(score, GameType.Division);
        }
    }
}