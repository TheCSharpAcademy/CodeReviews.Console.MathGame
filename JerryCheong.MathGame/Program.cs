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

/*
Timer Psuedo Code:
1. Wait for user input
2. Start stopwatch
3. While user input != desired input
4. console.WriteLine 
*/

/*
Psuedo Code:
1. Create a class called MathGame
2. Create a method called StartGame
3. Create a method called ShowMenu
4. Create a method called ShowHistory
5. Create a method called Add
6. Create a method called Subtract
7. Create a method called Multiply
8. Create a method called Divide
9. Create a method called GetRandomNumber
11. Create a method called GetRandomDividend
12. Create a method called GetRandomDivisor
13. Create a method called RandomGame
14. Create a method called AddTimer
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

            switch (option)
            {
                case "1":
                    await Add();
                    break;
                case "2":
                    await Subtract();
                    break;
                case "3":
                    await Multiply();
                    break;
                case "4":
                    await Divide();
                    break;
                case "5":
                    RandomGame();
                    break;
                case "6":
                    ShowHistory();
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

        private async void ShowHistory()
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

        private async Task Add()
        {
            int number1 = GetRandomNumber();
            int number2 = GetRandomNumber();
            int result = number1 + number2;

            Console.WriteLine($"What is {number1} + {number2}?");

            CancellationTokenSource cts = new CancellationTokenSource();

            Task<int> timer = StartTimerAsync(5, cts.Token);
            Task<string> readInput = ReadInputAsync(cts.Token);

            Task gameOver = await Task.WhenAny(readInput, timer);

            if (gameOver == readInput)
            {
                cts.Cancel();
                int answer = int.Parse(readInput.Result);

                if (answer == result)
                {
                    Console.WriteLine("Correct!");
                    games.Add($"{number1} + {number2} = {result} - Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {result}");
                    games.Add($"{number1} + {number2} = {result} - Incorrect!");
                }
            }
            else if (gameOver == timer)
            {
                cts.Cancel();
                games.Add($"{number1} + {number2} = {result} - Time's up! {timer.Result} seconds elapsed.");
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            await ShowMenu();
        }

        private async Task Subtract()
        {
            int number1 = GetRandomNumber();
            int number2 = GetRandomNumber();
            int result = number1 - number2;

            Console.WriteLine($"What is {number1} - {number2}?");
            CancellationTokenSource cts = new CancellationTokenSource();

            Task<int> timer = StartTimerAsync(9999, cts.Token);
            Task<string> readInput = ReadInputAsync(cts.Token);

            Task gameOver = await Task.WhenAny(readInput, timer);

            if (gameOver == readInput)
            {
                // cts.Cancel();
                int answer = int.Parse(readInput.Result);

                if (answer == result)
                {
                    Console.WriteLine("Correct!");
                    games.Add($"{number1} - {number2} = {result} - Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {result}");
                    games.Add($"{number1} - {number2} = {result} - Incorrect!");
                }
            }
            else if (gameOver == timer)
            {
                cts.Cancel();
                games.Add($"{number1} + {number2} = {result} - Time's up! {timer.Result - 1} seconds elapsed.");
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            await ShowMenu();
        }

        private async Task Multiply()
        {
            int number1 = GetRandomNumber();
            int number2 = GetRandomNumber();
            int result = number1 * number2;

            Console.WriteLine($"What is {number1} * {number2}?");
            CancellationTokenSource cts = new CancellationTokenSource();

            Task<int> timer = StartTimerAsync(9999, cts.Token);
            Task<string> readInput = ReadInputAsync(cts.Token);

            Task gameOver = await Task.WhenAny(readInput, timer);

            if (gameOver == readInput)
            {
                cts.Cancel();
                int answer = int.Parse(readInput.Result);

                if (answer == result)
                {
                    Console.WriteLine("Correct!");
                    games.Add($"{number1} * {number2} = {result} - Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {result}");
                    games.Add($"{number1} * {number2} = {result} - Incorrect!");
                }
            }
            else if (gameOver == timer)
            {
                cts.Cancel();
                games.Add($"{number1} + {number2} = {result} - Time's up! {timer.Result} seconds elapsed.");
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            await ShowMenu();
        }

        private async Task Divide()
        {
            int number1 = GetRandomNumber();
            int number2 = GetRandomNumber(1, 11);
            int result = number1 / number2;

            Console.WriteLine($"What is {number1} / {number2}?");
            CancellationTokenSource cts = new CancellationTokenSource();

            Task<int> timer = StartTimerAsync(9999, cts.Token);
            Task<string> readInput = ReadInputAsync(cts.Token);

            Task gameOver = await Task.WhenAny(readInput, timer);

            if (gameOver == readInput)
            {
                cts.Cancel();
                int answer = int.Parse(readInput.Result);

                if (answer == result)
                {
                    Console.WriteLine("Correct!");
                    games.Add($"{number1} / {number2} = {result} - Correct!");
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {result}");
                    games.Add($"{number1} / {number2} = {result} - Incorrect!");
                }
            }
            else if (gameOver == timer)
            {
                cts.Cancel();
                games.Add($"{number1} + {number2} = {result} - Time's up! {timer.Result - 1} seconds elapsed.");
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            await ShowMenu();
        }

        private void RandomGame()
        {
            Random random = new Random();
            switch (random.Next(1, 5))
            {
                case 1:
                    Add().Wait();
                    break;
                case 2:
                    Subtract().Wait();
                    break;
                case 3:
                    Multiply().Wait();
                    break;
                case 4:
                    Divide().Wait();
                    break;
            }
        }

        private static async Task<int> StartTimerAsync(int secondsBeforeLose, CancellationToken cancellationToken)
        {
            int secondsElapsed = 0;
            Console.WriteLine("");
            for (int i = 0; i <= secondsBeforeLose; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return secondsElapsed;
                }

                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write($"{i} seconds elapsed.\n");

                await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
                secondsElapsed++;
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



