using System.Diagnostics;
namespace ConsoleMathsGame
{
    internal class GameEngine
    {
        internal static void AdditionGame()
        {
            int firstNumber = 0;
            int secondNumber = 0;
            Console.WriteLine("Easy or Hard? (E/H): ");
            var chosenDifficulty = Console.ReadLine().ToLower().Trim();
            if (chosenDifficulty == "e")
            {
                var easyNumbers = Helpers.GenerateEasyNumbers();
                firstNumber = easyNumbers[0];
                secondNumber = easyNumbers[1];
            }
            else if (chosenDifficulty == "h")
            {
                var hardNumbers = Helpers.GenerateHardNumbers();
                firstNumber = hardNumbers[0];
                firstNumber = hardNumbers[1];
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid choice");
                return;
            }
            Console.WriteLine("How many questions?: ");
            string numQuestionsIn = Console.ReadLine();
            int score = 0;

            if (!int.TryParse(numQuestionsIn, out int numQuestionsOut))
            {
                Console.WriteLine("Please enter a number");
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < numQuestionsOut; i++)
                {

                    int correctAnswer = firstNumber + secondNumber;

                    Console.WriteLine($"{firstNumber} + {secondNumber}");

                    Console.WriteLine("Enter your guess:");
                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out int userGuess))
                    {

                        if (userGuess == correctAnswer)
                        {
                            Console.WriteLine("Correct Answer!\n");
                            score++;
                        }
                        else if (userGuess != correctAnswer)
                        {
                            Console.WriteLine("Incorrect Answer");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid answer");
                    }
                }

                stopwatch.Stop();
                double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

                Helpers.games.Add($"{DateTime.Now} - Addition Game (Easy) - Score: {score} - Time: {elapsedSeconds}s");
                Console.WriteLine($"Congratulations, you scored {score} points!");
                Console.WriteLine($"Time Elapsed: {elapsedSeconds}s");
            }
        }
        internal static void SubtractionGame()
        {
            int firstNumber = 0;
            int secondNumber = 0;
            Console.WriteLine("Easy or Hard? (E/H): ");
            var chosenDifficulty = Console.ReadLine().ToLower().Trim();
            if (chosenDifficulty == "e")
            {
                var easyNumbers = Helpers.GenerateEasyNumbers();
                firstNumber = easyNumbers[0];
                secondNumber = easyNumbers[1];
            }
            else if (chosenDifficulty == "h")
            {
                var hardNumbers = Helpers.GenerateHardNumbers();
                firstNumber = hardNumbers[0];
                secondNumber = hardNumbers[1];
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid choice");
                return;
            }

            Console.WriteLine("How many questions?: ");
            string numQuestionsIn = Console.ReadLine();
            int score = 0;

            if (!int.TryParse(numQuestionsIn, out int numQuestionsOut))
            {
                Console.WriteLine("Please enter a number");
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < numQuestionsOut; i++)
                {

                    int correctAnswer = firstNumber - secondNumber;

                    Console.WriteLine($"{firstNumber} - {secondNumber}");

                    Console.WriteLine("Enter your guess:");
                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out int userGuess))
                    {

                        if (userGuess == correctAnswer)
                        {
                            Console.WriteLine("Correct Answer!\n");
                            score++;
                        }
                        else if (userGuess != correctAnswer)
                        {
                            Console.WriteLine("Incorrect Answer");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid answer");
                    }
                }

                stopwatch.Stop();
                double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

                Helpers.games.Add($"{DateTime.Now} - Subtraction Game (Easy) - Score: {score} - Time: {elapsedSeconds}s");
                Console.WriteLine($"Congratulations, you scored {score} points!");
                Console.WriteLine($"Time Elapsed: {elapsedSeconds}s");
            }
        }
        internal static void MultiplicationGame()
        {
            int firstNumber = 0;
            int secondNumber = 0;
            Console.WriteLine("Easy or Hard? (E/H): ");
            var chosenDifficulty = Console.ReadLine().ToLower().Trim();
            if (chosenDifficulty == "e")
            {
                var easyNumbers = Helpers.GenerateEasyNumbers();
                firstNumber = easyNumbers[0];
                secondNumber = easyNumbers[1];
            }
            else if (chosenDifficulty == "h")
            {
                var hardNumbers = Helpers.GenerateHardNumbers();
                firstNumber = hardNumbers[0];
                secondNumber = hardNumbers[1];
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid choice");
            }

            Console.WriteLine("How many questions?: ");
            string numQuestionsIn = Console.ReadLine();
            int score = 0;

            if (!int.TryParse(numQuestionsIn, out int numQuestionsOut))
            {
                Console.WriteLine("Please enter a number");
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < numQuestionsOut; i++)
                {

                    int correctAnswer = firstNumber * secondNumber;

                    Console.WriteLine($"{firstNumber} * {secondNumber}");

                    Console.WriteLine("Enter your guess:");
                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out int userGuess))
                    {

                        if (userGuess == correctAnswer)
                        {
                            Console.WriteLine("Correct Answer!\n");
                            score++;
                        }
                        else if (userGuess != correctAnswer)
                        {
                            Console.WriteLine("Incorrect Answer");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid answer");
                    }
                }

                stopwatch.Stop();
                double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

                Helpers.games.Add($"{DateTime.Now} - Multiplication Game (Easy) - Score: {score} - Time: {elapsedSeconds}s");
                Console.WriteLine($"Congratulations, you scored {score} points!");
                Console.WriteLine($"Time Elapsed: {elapsedSeconds}s");
            }
        }
        internal static void DivisionGameEasy()
        {
            Console.WriteLine("How many questions?: ");
            string numQuestionsIn = Console.ReadLine();
            int score = 0;

            if (!int.TryParse(numQuestionsIn, out int numQuestionsOut))
            {
                Console.WriteLine("Please enter a number");
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < numQuestionsOut; i++)
                {

                    var divisionNumbers = Helpers.DivisionNumbersEasy();
                    int firstNumber = divisionNumbers[0];
                    int secondNumber = divisionNumbers[1];

                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    int correctAnswer = firstNumber / secondNumber;

                    Console.WriteLine("Enter your guess:");
                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out int userGuess))
                    {

                        if (userGuess == correctAnswer)
                        {
                            Console.WriteLine("Correct Answer!\n");
                            score++;
                        }
                        else if (userGuess != correctAnswer)
                        {
                            Console.WriteLine("Incorrect Answer");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid answer");
                    }
                }

                stopwatch.Stop();
                double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

                Helpers.games.Add($"{DateTime.Now} - Division Game (Easy) - Score: {score} - Time: {elapsedSeconds}s");
                Console.WriteLine($"Congratulations, you scored {score} points!");
                Console.WriteLine($"Time Elapsed: {elapsedSeconds}s");
            }
        }
        internal static void DivisionGameHard()
        {
            Console.WriteLine("How many questions?: ");
            string numQuestionsIn = Console.ReadLine();
            int score = 0;

            if (!int.TryParse(numQuestionsIn, out int numQuestionsOut))
            {
                Console.WriteLine("Please enter a number");
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                for (int i = 0; i < numQuestionsOut; i++)
                {

                    var divisionNumbers = Helpers.DivisionNumbersHard();
                    int firstNumber = divisionNumbers[0];
                    int secondNumber = divisionNumbers[1];

                    Console.WriteLine($"{firstNumber} / {secondNumber}");
                    int correctAnswer = firstNumber / secondNumber;

                    Console.WriteLine("Enter your guess:");
                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out int userGuess))
                    {

                        if (userGuess == correctAnswer)
                        {
                            Console.WriteLine("Correct Answer!\n");
                            score++;
                        }
                        else if (userGuess != correctAnswer)
                        {
                            Console.WriteLine("Incorrect Answer");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid answer");
                    }
                }

                stopwatch.Stop();
                double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

                Helpers.games.Add($"{DateTime.Now} - Division Game (Hard) - Score: {score} - Time: {elapsedSeconds}s");
                Console.WriteLine($"Congratulations, you scored {score} points!");
                Console.WriteLine($"Time Elapsed: {elapsedSeconds}s");
            }
        }
        internal static void RandomGame()
        {
            Random random = new Random();
            int randomGame = random.Next(0, 4);
            switch (randomGame)
            {
                case 0:
                    GameEngine.AdditionGame();
                    break;
                case 1:
                    GameEngine.SubtractionGame();
                    break;
                case 2:
                    GameEngine.MultiplicationGame();
                    break;
                case 3:
                    GameEngine.DivisionGameEasy();
                    break;
                case 4:
                    GameEngine.DivisionGameHard();
                    break;
                default:
                    break;

            }

        }
    }
}
