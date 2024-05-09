using System.Diagnostics;


namespace MyFirstProgram
{
    internal class GameEngine
    {
        internal GameEngine() {}

        internal void AdditionGame(int score,  List<GameHistory> gameHistories)
        {
            int gameRounds = NumberOfQuestions();
            var watch = Stopwatch.StartNew();
            string gameType = "Addition Game";
            for (int i = 0; i < gameRounds; i++)
            {
                Console.Clear();
                Console.WriteLine(gameType);
                Random rnd = new Random();
                int firstNumber = rnd.Next(1, 10);
                int secondNumber = rnd.Next(1, 10);
                Console.WriteLine($"What is {firstNumber} + {secondNumber}? Key your answer proceed");

                bool incorrectFormat;
                var userInput = Console.ReadLine();
                do
                {
                    incorrectFormat = false;
                    if (!Int32.TryParse(userInput, out int output))
                    {
                        Console.WriteLine("Your answer needs to be an integer. Try again.");
                        incorrectFormat = true;
                        userInput = Console.ReadLine();
                    }
                    else if (output == firstNumber + secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        Console.ReadKey();
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                        Console.ReadKey();
                    }
                } while (incorrectFormat); 

                if (i == gameRounds - 1)
                {
                    watch.Stop();
                    TimeSpan ts = watch.Elapsed;
                    string elapsedTime = System.String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine($"Game over. Your final score is {score}. \nYou took {elapsedTime} to finish the game. \nPress any key to go back to main menu.");
                    Helpers.UpdateGameHistory(gameHistories, GameHistory.GameType.Addition, score);
                    Console.ReadKey();

                }
            }
        }

        internal void SubtractionGame(int score, List<GameHistory> gameHistories)
        {
            int gameRounds = NumberOfQuestions();
            var watch = Stopwatch.StartNew();
            string gameType = "Subtraction Game";
            for (int i = 0; i < gameRounds; i++)
            {
                Console.Clear();
                Console.WriteLine(gameType);
                Random rnd = new Random();
                int firstNumber = rnd.Next(1, 10);
                int secondNumber = rnd.Next(1, 10);
                Console.WriteLine($"What is {firstNumber} - {secondNumber}? Key your answer proceed");

                bool incorrectFormat;
                var userInput = Console.ReadLine();
                do
                {
                    incorrectFormat = false;
                    if (!Int32.TryParse(userInput, out int output))
                    {
                        Console.WriteLine("Your answer needs to be an integer. Try again.");
                        incorrectFormat = true;
                        userInput = Console.ReadLine();
                    }
                    else if (output == firstNumber - secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        Console.ReadKey();
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                        Console.ReadKey();
                    }
                } while (incorrectFormat);

                if (i == gameRounds - 1)
                {
                    watch.Stop();
                    TimeSpan ts = watch.Elapsed;
                    string elapsedTime = System.String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine($"Game over. Your final score is {score}. \nYou took {elapsedTime} to finish the game. \nPress any key to go back to main menu.");
                    Helpers.UpdateGameHistory(gameHistories, GameHistory.GameType.Subtraction, score);
                    Console.ReadKey();

                }
            }
        }

        internal void MultiplicationGame(int score, List<GameHistory> gameHistories)
        {
            int gameRounds = NumberOfQuestions();
            var watch = Stopwatch.StartNew();
            string gameType = "Multiplication Game";
            for (int i = 0; i < gameRounds; i++)
            {
                Console.Clear();
                Console.WriteLine(gameType);
                Random rnd = new Random();
                int firstNumber = rnd.Next(1, 10);
                int secondNumber = rnd.Next(1, 10);
                Console.WriteLine($"What is {firstNumber} * {secondNumber}? Key your answer proceed");

                bool incorrectFormat;
                var userInput = Console.ReadLine();
                do
                {
                    incorrectFormat = false;
                    if (!Int32.TryParse(userInput, out int output))
                    {
                        Console.WriteLine("Your answer needs to be an integer. Try again.");
                        incorrectFormat = true;
                        userInput = Console.ReadLine();
                    }
                    else if (output == firstNumber * secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        Console.ReadKey();
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                        Console.ReadKey();
                    }
                } while (incorrectFormat);

                if (i == gameRounds - 1)
                {
                    watch.Stop();
                    TimeSpan ts = watch.Elapsed;
                    string elapsedTime = System.String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine($"Game over. Your final score is {score}. \nYou took {elapsedTime} to finish the game. \nPress any key to go back to main menu.");
                    Helpers.UpdateGameHistory(gameHistories, GameHistory.GameType.Multiplication, score);
                    Console.ReadKey();

                }
            }
        }

        internal void DivisionGame(int score, List<GameHistory> gameHistories)
        {
            int gameRounds = NumberOfQuestions();
            var watch = Stopwatch.StartNew();
            string gameType = "Multiplication Game";
            for (int i = 0; i < gameRounds; i++)
            {
                Console.Clear();
                Console.WriteLine(gameType);
                Random rnd = new Random();

                int firstNumber = rnd.Next(0, 100);
                int secondNumber;
                do
                {
                    secondNumber = rnd.Next(1, 10);
                } while (firstNumber % secondNumber != 0);

                Console.WriteLine($"What is {firstNumber} / {secondNumber}? Key your answer proceed");

                bool incorrectFormat;
                var userInput = Console.ReadLine();
                do
                {
                    incorrectFormat = false;
                    if (!Int32.TryParse(userInput, out int output))
                    {
                        Console.WriteLine("Your answer needs to be an integer. Try again.");
                        incorrectFormat = true;
                        userInput = Console.ReadLine();
                    }
                    else if (output == firstNumber / secondNumber)
                    {
                        Console.WriteLine("Your answer was correct! Type any key for the next question");
                        Console.ReadKey();
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                        Console.ReadKey();
                    }
                } while (incorrectFormat);

                if (i == gameRounds - 1)
                {
                    watch.Stop();
                    TimeSpan ts = watch.Elapsed;
                    string elapsedTime = System.String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                        ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    Console.WriteLine($"Game over. Your final score is {score}. \nYou took {elapsedTime} to finish the game. \nPress any key to go back to main menu.");
                    Helpers.UpdateGameHistory(gameHistories, GameHistory.GameType.Division, score);
                    Console.ReadKey();

                }
            }
        }

        int NumberOfQuestions()
        {
            Console.WriteLine("How many questions would you like?");
            var TotalQuestions = Console.ReadLine();
            int val;
            while (!Int32.TryParse(TotalQuestions, out val) || string.IsNullOrWhiteSpace(TotalQuestions.Trim('0')))
            {
                Console.WriteLine("You need to input a positive integer. Try again");
                TotalQuestions = Console.ReadLine();
            }
            return val;
        }

    }

}
