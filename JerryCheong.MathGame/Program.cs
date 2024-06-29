/*
Project Specifics:
A Math Game containing the 4 basic operations (addition, subtraction, multiplication, division).
The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
Users should be presented with a menu to choose an operation
You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
You don't need to record results on a database. Once the program is closed the results will be deleted.

Implement 3 levels of difficulty.
Add a timer to track how long the user takes to finish the game.
Add a function that let's the user pick the number of questions.
Create a 'Random Game' option where the players will be presented with questions from random operations
*/

using System;  // Required for Console.WriteLine, Console.ReadLine, Console.Clear, Console.ReadKey
using System.Collections.Generic;  // Required for List
using System.Diagnostics;  // Required for Stopwatch

namespace MathGame
{
    class MathGame
    {
        public void StartGame()
        {
            ShowMenu().GetAwaiter().GetResult();
        }

        private async Task ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Math Game!");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            Console.WriteLine("5. Random Game");
            Console.WriteLine("6. Show History");
            Console.WriteLine("7. Exit");

            string option = Console.ReadLine();
            int numberOfQuestions;

            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter the number of questions you want to answer:");
                    numberOfQuestions = int.Parse(Console.ReadLine());
                    await Add(numberOfQuestions);

                    break;
                case "2":
                    Console.WriteLine("Enter the number of questions you want to answer:");
                    numberOfQuestions = int.Parse(Console.ReadLine());
                    await Subtract(numberOfQuestions);

                    break;
                case "3":
                    Console.WriteLine("Enter the number of questions you want to answer:");
                    numberOfQuestions = int.Parse(Console.ReadLine());
                    await Multiply(numberOfQuestions);

                    break;
                case "4":
                    Console.WriteLine("Enter the number of questions you want to answer:");
                    numberOfQuestions = int.Parse(Console.ReadLine());
                    await Divide(numberOfQuestions);

                    break;
                case "5":
                    Console.WriteLine("Enter the number of questions you want to answer:");
                    numberOfQuestions = int.Parse(Console.ReadLine());
                    RandomGame(numberOfQuestions);

                    break;
                case "6":
                    await ShowHistory();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    await ShowMenu();
                    break;
            }
        }

        private static async Task<string> ReadInputAsync(CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                try
                {
                    return Console.ReadLine(); // Read the input if available
                }
                catch (OperationCanceledException)
                {
                    return "0"; // Return default value if operation was cancelled
                }
            }, cancellationToken).ConfigureAwait(false);
        }

        private async Task ShowHistory()
        {
            Console.Clear();
            Console.WriteLine("History of Games:");
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            await ShowMenu();
        }

        private async Task Add(int numberOfQuestions, bool calledByRandomGame = false)
        {
            int number1;
            int number2;
            int result;

            while (numberOfQuestions > 0)
            {
                numberOfQuestions--;
                number1 = GetRandomNumber();
                number2 = GetRandomNumber();
                result = number1 + number2;

                Console.WriteLine($"\nWhat is {number1} + {number2}?");

                CancellationTokenSource cts = new CancellationTokenSource();

                Task<int> timer = StartTimerAsync(999, cts.Token);
                Task<string> readInput = ReadInputAsync(cts.Token);

                Task gameOver = await Task.WhenAny(readInput, timer);

                if (gameOver == readInput)
                {
                    cts.Cancel();
                    int elapsedSeconds = timer.Result;
                    int answer = int.Parse(readInput.Result);

                    if (answer == result)
                    {
                        Console.WriteLine("Correct!");
                        Console.WriteLine($"You took {elapsedSeconds} seconds to answer this question.");
                        games.Add($"{number1} + {number2} = {result} - Correct! {elapsedSeconds} seconds elapsed.");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect. The correct answer is {result}");
                        Console.WriteLine($"You took {elapsedSeconds} seconds to answer this question.");
                        games.Add($"{number1} + {number2} = {result} - Incorrect! {elapsedSeconds} seconds elapsed.");
                    }
                }
                else if (gameOver == timer)
                {
                    cts.Cancel();
                    games.Add($"{number1} + {number2} = {result} - Time's up! {timer.Result} seconds elapsed.");
                }
            }

            if (!calledByRandomGame)
            {
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
                await ShowMenu();
            }
        }

        private async Task Subtract(int numberOfQuestions, bool calledByRandomGame = false)
        {
            while (numberOfQuestions > 0)
            {
                numberOfQuestions--;
                int number1 = GetRandomNumber();
                int number2 = GetRandomNumber();
                int result = number1 - number2;

                Console.WriteLine($"\nWhat is {number1} - {number2}?");
                CancellationTokenSource cts = new CancellationTokenSource();

                Task<int> timer = StartTimerAsync(9999, cts.Token);
                Task<string> readInput = ReadInputAsync(cts.Token);

                Task gameOver = await Task.WhenAny(readInput, timer);

                if (gameOver == readInput)
                {
                    cts.Cancel();
                    int elapsedSeconds = timer.Result;
                    int answer = int.Parse(readInput.Result);

                    if (answer == result)
                    {
                        Console.WriteLine("Correct!");
                        Console.WriteLine($"You took {elapsedSeconds} seconds to answer this question.");
                        games.Add($"{number1} - {number2} = {result} - Correct! {elapsedSeconds} seconds elapsed.");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect. The correct answer is {result}");
                        Console.WriteLine($"You took {elapsedSeconds} seconds to answer this question.");
                        games.Add($"{number1} - {number2} = {result} - Incorrect! {elapsedSeconds} seconds elapsed.");
                    }
                }
                else if (gameOver == timer)
                {
                    cts.Cancel();
                    games.Add($"{number1} + {number2} = {result} - Time's up! {timer.Result - 1} seconds elapsed.");
                }
            }

            if (!calledByRandomGame)
            {
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
                await ShowMenu();
            }
        }

        private async Task Multiply(int numberOfQuestions, bool calledByRandomGame = false)
        {
            while (numberOfQuestions > 0)
            {
                numberOfQuestions--;
                int number1 = GetRandomNumber();
                int number2 = GetRandomNumber();
                int result = number1 * number2;

                Console.WriteLine($"\nWhat is {number1} * {number2}?");
                CancellationTokenSource cts = new CancellationTokenSource();

                Task<int> timer = StartTimerAsync(9999, cts.Token);
                Task<string> readInput = ReadInputAsync(cts.Token);

                Task gameOver = await Task.WhenAny(readInput, timer);

                if (gameOver == readInput)
                {
                    cts.Cancel();
                    int elapsedSeconds = timer.Result;
                    int answer = int.Parse(readInput.Result);

                    if (answer == result)
                    {
                        Console.WriteLine("Correct!");
                        Console.WriteLine($"You took {elapsedSeconds} seconds to answer this question.");
                        games.Add($"{number1} * {number2} = {result} - Correct! {elapsedSeconds} seconds elapsed.");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect. The correct answer is {result}");
                        Console.WriteLine($"You took {elapsedSeconds} seconds to answer this question.");
                        games.Add($"{number1} * {number2} = {result} - Incorrect! {elapsedSeconds} seconds elapsed.");
                    }
                }
                else if (gameOver == timer)
                {
                    cts.Cancel();
                    games.Add($"{number1} + {number2} = {result} - Time's up! {timer.Result} seconds elapsed.");
                }
            }

            if (!calledByRandomGame)
            {
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
                await ShowMenu();
            }
        }

        private async Task Divide(int numberOfQuestions, bool calledByRandomGame = false)
        {
            while (numberOfQuestions > 0)
            {
                numberOfQuestions--;
                int number1 = GetRandomNumber();
                int number2 = GetRandomNumber(1, 11);
                int result = number1 / number2;

                while (number1 % number2 != 0)
                {
                    number1 = GetRandomNumber();
                    number2 = GetRandomNumber(1, 11);
                    result = number1 / number2;
                }

                Console.WriteLine($"\nWhat is {number1} / {number2}?");
                CancellationTokenSource cts = new CancellationTokenSource();

                Task<int> timer = StartTimerAsync(9999, cts.Token);
                Task<string> readInput = ReadInputAsync(cts.Token);

                Task gameOver = await Task.WhenAny(readInput, timer);

                if (gameOver == readInput)
                {
                    cts.Cancel();
                    int elapsedSeconds = timer.Result;
                    int answer = int.Parse(readInput.Result);

                    if (answer == result)
                    {
                        Console.WriteLine("Correct!");
                        Console.WriteLine($"You took {elapsedSeconds} seconds to answer this question.");
                        games.Add($"{number1} / {number2} = {result} - Correct! {elapsedSeconds} seconds elapsed.");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect. The correct answer is {result}");
                        Console.WriteLine($"You took {elapsedSeconds} seconds to answer this question.");
                        games.Add($"{number1} / {number2} = {result} - Incorrect! {elapsedSeconds} seconds elapsed.");
                    }
                }
                else if (gameOver == timer)
                {
                    cts.Cancel();
                    games.Add($"{number1} + {number2} = {result} - Time's up! {timer.Result - 1} seconds elapsed.");
                }
            }

            if (!calledByRandomGame)
            {
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey();
                await ShowMenu();
            }
        }

        private void RandomGame(int numberOfQuestions)
        {
            Random random = new Random();
            while (numberOfQuestions > 0)
            {
                numberOfQuestions--;
                switch (random.Next(1, 5))
                {
                    case 1:
                        Add(1, calledByRandomGame: true).Wait();
                        break;
                    case 2:
                        Subtract(1, calledByRandomGame: true).Wait();
                        break;
                    case 3:
                        Multiply(1, calledByRandomGame: true).Wait();
                        break;
                    case 4:
                        Divide(1, calledByRandomGame: true).Wait();
                        break;
                }
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            ShowMenu().Wait();
        }

        private static async Task<int> StartTimerAsync(int secondsBeforeLose, CancellationToken cancellationToken)
        {
            int secondsElapsed = 0;
            // Console.WriteLine("");
            try
            {
                for (int i = 0; i <= secondsBeforeLose; i++)
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
                        secondsElapsed++;
                    }

                    // Visually update the timer, but making user input difficult, not using for now
                    // Console.SetCursorPosition(0, Console.CursorTop - 1);
                    // Console.Write($"{i} seconds elapsed.\n");

                    return secondsElapsed;
                }
            }
            catch (OperationCanceledException)
            {
                return secondsElapsed;
            }
            Console.WriteLine("\nTime's up! ");
            return secondsElapsed;
        }

        private int GetRandomNumber(int min = 0, int max = 101)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private List<string> games = new List<string>();

        static void Main(string[] args)
        {
            MathGame mathGame = new MathGame();
            mathGame.StartGame();
        }
    }

}



