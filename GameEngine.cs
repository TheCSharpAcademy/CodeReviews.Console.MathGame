using MathGame.Models;
using System.Diagnostics;

namespace MathGame;
internal class GameEngine {
    internal void Division() {
        int score = 0;

        string operationType = GameType.Division.ToString();

        Console.WriteLine("You chose division mode!");
        Console.ReadLine();

        Console.WriteLine("Please, select a level of difficulty for the game:\n" +
                              "1 - Easy (Numbers from 1 to 100)\n" +
                              "2 - Medium (Numbers from 1 to 500)\n" +
                              "3 - Hard (Numbers from 1 to 100)");
        int difficulty = int.Parse(Helpers.ValidateResult(Console.ReadLine()));

        int questionNum = Helpers.NumberOfQuestions();

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 1; i <= questionNum; i++) {
            Console.Clear();

            int firstNumber = Helpers.DifficultySelector(GameType.Addition, difficulty)[0];
            int secondNumber = Helpers.DifficultySelector(GameType.Addition, difficulty)[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");

            string? result = Console.ReadLine();
            result = Helpers.ValidateResult(result); ;

            if (int.Parse(result) == firstNumber / secondNumber) {
                Console.WriteLine("Your answer was correct! Type any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else {
                Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                Console.ReadLine();
            }

            if (i == 4) {
                Console.WriteLine($"Game over! Your final score is {score}.");
            }
        }

        // Timer
        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms",
                                           ts.Hours, ts.Minutes, ts.Seconds,
                                           ts.Milliseconds / 10);

        Console.WriteLine("Time elapsed during last game: " + elapsedTime);
        // Timer

        Console.WriteLine(" Press any key to go back to main menu:");
        Console.ReadLine();

        Helpers.AddToHistory(score, GameType.Division, elapsedTime);
    }

    internal void Multiplication() {
        int score = 0;

        Console.WriteLine("You choose multiplication mode!");
        Console.ReadLine();

        Console.WriteLine("Please, select a level of difficulty for the game:\n" +
                              "1 - Easy (Numbers from 1 to 10)\n" +
                              "2 - Medium (Numbers from 1 to 50)\n" +
                              "3 - Hard (Numbers from 1 to 100)");
        int difficulty = int.Parse(Helpers.ValidateResult(Console.ReadLine()));

        int questionNum = Helpers.NumberOfQuestions();

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 1; i <= questionNum; i++) {
            Console.Clear();

            int firstNumber = Helpers.GenerateRandomNumber(1, 10);
            int secondNumber = Helpers.GenerateRandomNumber(1, 10);

            Console.WriteLine($"{firstNumber} * {secondNumber}");

            string? result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber * secondNumber) {
                Console.WriteLine("Your answer was correct! Type any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else {
                Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                Console.ReadLine();
            }

            if (i == 4) {
                Console.WriteLine($"Game over! Your final score is {score}.");
            }
        }

        // Timer
        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms",
                                           ts.Hours, ts.Minutes, ts.Seconds,
                                           ts.Milliseconds / 10);

        Console.WriteLine("Time elapsed during last game: " + elapsedTime);
        // Timer

        Console.WriteLine(" Press any key to go back to main menu:");
        Console.ReadLine();

        Helpers.AddToHistory(score, GameType.Multiplication, elapsedTime);
    }

    internal void Subtraction() {

        int score = 0;

        Console.WriteLine("You choose subtraction mode! Press any key to continue:");
        Console.ReadLine();

        Console.WriteLine("Please, select a level of difficulty for the game:\n" +
                              "1 - Easy (Numbers from 1 to 10)\n" +
                              "2 - Medium (Numbers from 1 to 50)\n" +
                              "3 - Hard (Numbers from 1 to 100)");
        int difficulty = int.Parse(Helpers.ValidateResult(Console.ReadLine()));

        int questionNum = Helpers.NumberOfQuestions();

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 1; i <= questionNum; i++) {
            Console.Clear();

            int firstNumber = Helpers.GenerateRandomNumber(1, 10);
            int secondNumber = Helpers.GenerateRandomNumber(1, 10);

            Console.WriteLine($"{firstNumber} - {secondNumber}");

            string? result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber - secondNumber) {
                Console.WriteLine("Your answer was correct! Type any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else {
                Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                Console.ReadLine();
            }

            if (i == 4) {
                Console.WriteLine($"Game over! Your final score is {score}.");
            }
        }

        // Timer
        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms",
                                           ts.Hours, ts.Minutes, ts.Seconds,
                                           ts.Milliseconds / 10);

        Console.WriteLine("Time elapsed during last game: " + elapsedTime);
        // Timer

        Console.WriteLine(" Press any key to go back to main menu:");
        Console.ReadLine();

        Helpers.AddToHistory(score, GameType.Subtraction, elapsedTime);
    }

    internal void Addition() {
        int score = 0;
        string elapsedTime;

        Console.WriteLine("You choose addition mode! Press any key to continue:");
        Console.ReadLine();

        Console.WriteLine("Please, select a level of difficulty for the game:\n" +
                              "1 - Easy (Numbers from 1 to 10)\n" +
                              "2 - Medium (Numbers from 1 to 50)\n" +
                              "3 - Hard (Numbers from 1 to 100)");
        int difficulty = int.Parse(Helpers.ValidateResult(Console.ReadLine()));

        int questionNum = Helpers.NumberOfQuestions();

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 1; i <= questionNum; i++) {
            Console.Clear();

            int firstNumber = Helpers.DifficultySelector(GameType.Addition, difficulty)[0];
            int secondNumber = Helpers.DifficultySelector(GameType.Addition, difficulty)[1];

            Console.WriteLine($"{firstNumber} + {secondNumber}");

            string? result = Console.ReadLine();
            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber + secondNumber) {
                Console.WriteLine("Your answer was correct! Type any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else {
                Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                Console.ReadLine();
            }

            if (i == 4) {
                Console.WriteLine($"Game over! Your final score is {score}.");
            }
        }

        // Timer
        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;
        elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms",
                                           ts.Hours, ts.Minutes, ts.Seconds,
                                           ts.Milliseconds / 10);

        Console.WriteLine("Time elapsed during last game: " + elapsedTime);
        // Timer

        Console.WriteLine(" Press any key to go back to main menu:");
        Console.ReadLine();

        Helpers.AddToHistory(score, GameType.Addition, elapsedTime);
    }

    internal void Random() {
        int score = 0;

        Console.WriteLine("You choose random mode! Press any key to continue:");
        Console.ReadLine();

        Console.WriteLine("Please, select a level of difficulty for the game:\n" +
                              "1 - Easy (Numbers from 1 to 10)\n" +
                              "2 - Medium (Numbers from 1 to 50)\n" +
                              "3 - Hard (Numbers from 1 to 100)");
        int difficulty = int.Parse(Helpers.ValidateResult(Console.ReadLine()));

        int questionNum = Helpers.NumberOfQuestions();


        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 1; i <= questionNum; i++) {
            Console.Clear();

            int firstNumber = Helpers.DifficultySelector(GameType.Random, difficulty)[0];
            int secondNumber = Helpers.DifficultySelector(GameType.Random, difficulty)[1];

            int firstNumberDivision = Helpers.DifficultySelector(GameType.Division, difficulty)[0];
            int secondNumberDivision = Helpers.DifficultySelector(GameType.Division, difficulty)[1];

            int randomOperation = Helpers.GenerateRandomNumber(1, 5);

            switch (randomOperation) {
                // Addition operation:
                case 1:
                    Console.WriteLine($"{firstNumber} + {secondNumber}");

                    string? result = Console.ReadLine();
                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == firstNumber + secondNumber) {
                        Console.WriteLine("Your answer was correct! Type any key for the next question.");
                        score++;
                        Console.ReadLine();
                    }
                    else {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                        Console.ReadLine();
                    }

                    if (i == 4) {
                        Console.WriteLine($"Game over! Your final score is {score}. Press any key to go back to main menu:");
                        Console.ReadLine();
                    }
                    break;

                // Suctraction
                case 2:
                    Console.WriteLine($"{firstNumber} - {secondNumber}");

                    result = Console.ReadLine();
                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == firstNumber - secondNumber) {
                        Console.WriteLine("Your answer was correct! Type any key for the next question.");
                        score++;
                        Console.ReadLine();
                    }
                    else {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                        Console.ReadLine();
                    }

                    if (i == 4) {
                        Console.WriteLine($"Game over! Your final score is {score}.");
                    }
                    break;

                // Multiplication
                case 3:
                    Console.WriteLine($"{firstNumber} * {secondNumber}");

                    result = Console.ReadLine();
                    result = Helpers.ValidateResult(result);

                    if (int.Parse(result) == firstNumber * secondNumber) {
                        Console.WriteLine("Your answer was correct! Type any key for the next question.");
                        score++;
                        Console.ReadLine();
                    }
                    else {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                        Console.ReadLine();
                    }

                    if (i == 4) {
                        Console.WriteLine($"Game over! Your final score is {score}.");
                    }
                    break;

                // Division
                case 4:
                    Console.WriteLine($"{firstNumberDivision} / {secondNumberDivision}");

                    result = Console.ReadLine();
                    result = Helpers.ValidateResult(result); ;

                    if (int.Parse(result) == firstNumberDivision / secondNumberDivision) {
                        Console.WriteLine("Your answer was correct! Type any key for the next question.");
                        score++;
                        Console.ReadLine();
                    }
                    else {
                        Console.WriteLine("Your answer was incorrect! Type any key for the next question.");
                        Console.ReadLine();
                    }

                    if (i == 4) {
                        Console.WriteLine($"Game over! Your final score is {score}.");
                    }
                    break;

            }
        }
        // Timer
        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;
        string elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms",
                                           ts.Hours, ts.Minutes, ts.Seconds,
                                           ts.Milliseconds / 10);

        Console.WriteLine("Time elapsed during last game: " + elapsedTime);
        // Timer

        Console.WriteLine(" Press any key to go back to main menu:");
        Console.ReadLine();

        Helpers.AddToHistory(score, GameType.Addition, elapsedTime);
    }
}
