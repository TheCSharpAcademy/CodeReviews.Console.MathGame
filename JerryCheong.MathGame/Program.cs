/*
Project Specifics:
A Math Game containing the 4 basic operations (addition, subtraction, multiplication, division).
The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
Users should be presented with a menu to choose an operation
You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
You don't need to record results on a database. Once the program is closed the results will be deleted.

Implement 3 levels of difficulty.
Easy: Long time to answer(999s). Numbers from 0 to 100
Medium: Medium time to answer(15s). Numbers from 0 to 1000
Hard: Short time to answer(5s). Numbers from 0 to 10000
Add a timer to track how long the user takes to finish the game.
Add a function that let's the user pick the number of questions.
Create a 'Random Game' option where the players will be presented with questions from random operations
*/

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

            int numberOfQuestions;
            int difficultyLevel;

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter the number of questions you want to answer:");
                    numberOfQuestions = ConvertToInteger(Console.ReadLine());
                    Console.WriteLine("Select the difficulty level:");
                    Console.WriteLine("1. Easy (999 seconds to answer, numbers from 0 to 100)");
                    Console.WriteLine("2. Medium (15 seconds to answer, numbers from 0 to 1000)");
                    Console.WriteLine("3. Hard (5 seconds to answer, numbers from 0 to 10000)");
                    difficultyLevel = ConvertToInteger(Console.ReadLine());
                    while (difficultyLevel < 1 || difficultyLevel > 3)
                    {
                        Console.WriteLine("Invalid difficulty level. Please select a valid option.");
                        difficultyLevel = ConvertToInteger(Console.ReadLine());
                    }
                    await Add(numberOfQuestions, difficultyLevel);

                    break;
                case "2":
                    Console.WriteLine("Enter the number of questions you want to answer:");
                    numberOfQuestions = ConvertToInteger(Console.ReadLine());
                    Console.WriteLine("Select the difficulty level:");
                    Console.WriteLine("1. Easy (999 seconds to answer, numbers from 0 to 100)");
                    Console.WriteLine("2. Medium (15 seconds to answer, numbers from 0 to 1000)");
                    Console.WriteLine("3. Hard (5 seconds to answer, numbers from 0 to 10000)");
                    difficultyLevel = ConvertToInteger(Console.ReadLine());
                    while (difficultyLevel < 1 || difficultyLevel > 3)
                    {
                        Console.WriteLine("Invalid difficulty level. Please select a valid option.");
                        difficultyLevel = ConvertToInteger(Console.ReadLine());
                    }
                    await Subtract(numberOfQuestions, difficultyLevel);

                    break;
                case "3":
                    Console.WriteLine("Enter the number of questions you want to answer:");
                    numberOfQuestions = ConvertToInteger(Console.ReadLine());
                    Console.WriteLine("Select the difficulty level:");
                    Console.WriteLine("1. Easy (999 seconds to answer, numbers from 0 to 100)");
                    Console.WriteLine("2. Medium (15 seconds to answer, numbers from 0 to 1000)");
                    Console.WriteLine("3. Hard (5 seconds to answer, numbers from 0 to 10000)");
                    difficultyLevel = ConvertToInteger(Console.ReadLine());
                    while (difficultyLevel < 1 || difficultyLevel > 3)
                    {
                        Console.WriteLine("Invalid difficulty level. Please select a valid option.");
                        difficultyLevel = ConvertToInteger(Console.ReadLine());
                    }
                    await Multiply(numberOfQuestions, difficultyLevel);

                    break;
                case "4":
                    Console.WriteLine("Enter the number of questions you want to answer:");
                    numberOfQuestions = ConvertToInteger(Console.ReadLine());
                    Console.WriteLine("Select the difficulty level:");
                    Console.WriteLine("1. Easy (999 seconds to answer, numbers from 0 to 100)");
                    Console.WriteLine("2. Medium (15 seconds to answer, numbers from 0 to 1000)");
                    Console.WriteLine("3. Hard (5 seconds to answer, numbers from 0 to 10000)");
                    difficultyLevel = ConvertToInteger(Console.ReadLine());
                    while (difficultyLevel < 1 || difficultyLevel > 3)
                    {
                        Console.WriteLine("Invalid difficulty level. Please select a valid option.");
                        difficultyLevel = ConvertToInteger(Console.ReadLine());
                    }
                    await Divide(numberOfQuestions, difficultyLevel);

                    break;
                case "5":
                    Console.WriteLine("Enter the number of questions you want to answer:");
                    numberOfQuestions = ConvertToInteger(Console.ReadLine());
                    Console.WriteLine("Select the difficulty level:");
                    Console.WriteLine("1. Easy (999 seconds to answer, numbers from 0 to 100)");
                    Console.WriteLine("2. Medium (15 seconds to answer, numbers from 0 to 1000)");
                    Console.WriteLine("3. Hard (5 seconds to answer, numbers from 0 to 10000)");
                    difficultyLevel = ConvertToInteger(Console.ReadLine());
                    while (difficultyLevel < 1 || difficultyLevel > 3)
                    {
                        Console.WriteLine("Invalid difficulty level. Please select a valid option.");
                        difficultyLevel = ConvertToInteger(Console.ReadLine());
                    }
                    RandomGame(numberOfQuestions, difficultyLevel);

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

        private static int ConvertToInteger(string? input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (FormatException)
            {
                do
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out int result));
                return int.Parse(input);
            }
        }

        private static async Task<string> ReadInputAsync(CancellationToken cancellationToken)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    while (!Console.KeyAvailable)
                    {
                        await Task.Delay(100, cancellationToken); // Use a delay to reduce CPU usage
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                    string? input = Console.ReadLine();
                    while (!int.TryParse(input, out int result))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        input = Console.ReadLine();
                    }
                    return input; // Read the input if available
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

        private async Task Add(int numberOfQuestions, int difficultyLevel, bool calledByRandomGame = false)
        {
            int number1;
            int number2;
            int result;

            while (numberOfQuestions > 0)
            {
                numberOfQuestions--;
                switch (difficultyLevel)
                {
                    case 1:
                        number1 = GetRandomNumber();
                        number2 = GetRandomNumber();
                        result = number1 + number2;
                        break;
                    case 2:
                        number1 = GetRandomNumber(0, 1001);
                        number2 = GetRandomNumber(0, 1001);
                        result = number1 + number2;
                        break;
                    case 3:
                        number1 = GetRandomNumber(0, 10001);
                        number2 = GetRandomNumber(0, 10001);
                        result = number1 + number2;
                        break;
                    default:
                        number1 = GetRandomNumber();
                        number2 = GetRandomNumber();
                        result = number1 + number2;
                        break;
                }

                Console.WriteLine($"\nWhat is {number1} + {number2}?");

                CancellationTokenSource cts = new CancellationTokenSource();

                Task<int> timer = new Task<int>(() => 0);
                switch (difficultyLevel)
                {
                    case 1:
                        timer = StartTimerAsync(999, cts.Token);
                        break;
                    case 2:
                        timer = StartTimerAsync(15, cts.Token);
                        break;
                    case 3:
                        timer = StartTimerAsync(5, cts.Token);
                        break;
                    default:
                        timer = StartTimerAsync(999, cts.Token);
                        break;
                }
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

        private async Task Subtract(int numberOfQuestions, int difficultyLevel, bool calledByRandomGame = false)
        {
            while (numberOfQuestions > 0)
            {
                numberOfQuestions--;
                int number1;
                int number2;
                int result;

                switch (difficultyLevel)
                {
                    case 1:
                        number1 = GetRandomNumber();
                        number2 = GetRandomNumber();
                        result = number1 - number2;
                        break;
                    case 2:
                        number1 = GetRandomNumber(0, 1001);
                        number2 = GetRandomNumber(0, 1001);
                        result = number1 - number2;
                        break;
                    case 3:
                        number1 = GetRandomNumber(0, 10001);
                        number2 = GetRandomNumber(0, 10001);
                        result = number1 - number2;
                        break;
                    default:
                        number1 = GetRandomNumber();
                        number2 = GetRandomNumber();
                        result = number1 - number2;
                        break;
                }

                Console.WriteLine($"\nWhat is {number1} - {number2}?");
                CancellationTokenSource cts = new CancellationTokenSource();

                Task<int> timer = new Task<int>(() => 0);
                switch (difficultyLevel)
                {
                    case 1:
                        timer = StartTimerAsync(999, cts.Token);
                        break;
                    case 2:
                        timer = StartTimerAsync(15, cts.Token);
                        break;
                    case 3:
                        timer = StartTimerAsync(5, cts.Token);
                        break;
                    default:
                        timer = StartTimerAsync(999, cts.Token);
                        break;
                }
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

        private async Task Multiply(int numberOfQuestions, int difficultyLevel, bool calledByRandomGame = false)
        {
            while (numberOfQuestions > 0)
            {
                numberOfQuestions--;
                int number1;
                int number2;
                int result;

                switch (difficultyLevel)
                {
                    case 1:
                        number1 = GetRandomNumber();
                        number2 = GetRandomNumber();
                        result = number1 * number2;
                        break;
                    case 2:
                        number1 = GetRandomNumber(0, 1001);
                        number2 = GetRandomNumber(0, 1001);
                        result = number1 * number2;
                        break;
                    case 3:
                        number1 = GetRandomNumber(0, 10001);
                        number2 = GetRandomNumber(0, 10001);
                        result = number1 * number2;
                        break;
                    default:
                        number1 = GetRandomNumber();
                        number2 = GetRandomNumber();
                        result = number1 * number2;
                        break;
                }

                Console.WriteLine($"\nWhat is {number1} * {number2}?");
                CancellationTokenSource cts = new CancellationTokenSource();

                Task<int> timer = new Task<int>(() => 0);
                switch (difficultyLevel)
                {
                    case 1:
                        timer = StartTimerAsync(999, cts.Token);
                        break;
                    case 2:
                        timer = StartTimerAsync(15, cts.Token);
                        break;
                    case 3:
                        timer = StartTimerAsync(5, cts.Token);
                        break;
                    default:
                        timer = StartTimerAsync(999, cts.Token);
                        break;
                }
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

        private async Task Divide(int numberOfQuestions, int difficultyLevel, bool calledByRandomGame = false)
        {
            while (numberOfQuestions > 0)
            {
                numberOfQuestions--;
                int number1;
                int number2;
                int result;

                do
                {
                    switch (difficultyLevel)
                    {
                        case 1:
                            number1 = GetRandomNumber();
                            number2 = GetRandomNumber(1, 11);
                            result = number1 / number2;
                            break;
                        case 2:
                            number1 = GetRandomNumber(0, 1001);
                            number2 = GetRandomNumber(1, 101);
                            result = number1 / number2;
                            break;
                        case 3:
                            number1 = GetRandomNumber(0, 10001);
                            number2 = GetRandomNumber(1, 1001);
                            result = number1 / number2;
                            break;
                        default:
                            number1 = GetRandomNumber();
                            number2 = GetRandomNumber();
                            result = number1 / number2;
                            break;
                    }
                } while (number1 % number2 != 0);


                Console.WriteLine($"\nWhat is {number1} / {number2}?");
                CancellationTokenSource cts = new CancellationTokenSource();

                Task<int> timer = new Task<int>(() => 0);
                switch (difficultyLevel)
                {
                    case 1:
                        timer = StartTimerAsync(999, cts.Token);
                        break;
                    case 2:
                        timer = StartTimerAsync(15, cts.Token);
                        break;
                    case 3:
                        timer = StartTimerAsync(5, cts.Token);
                        break;
                    default:
                        timer = StartTimerAsync(999, cts.Token);
                        break;
                }
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

        private void RandomGame(int numberOfQuestions, int difficultyLevel)
        {
            Random random = new Random();
            while (numberOfQuestions > 0)
            {
                numberOfQuestions--;
                switch (random.Next(1, 5))
                {
                    case 1:
                        Add(1, difficultyLevel, calledByRandomGame: true).Wait();
                        break;
                    case 2:
                        Subtract(1, difficultyLevel, calledByRandomGame: true).Wait();
                        break;
                    case 3:
                        Multiply(1, difficultyLevel, calledByRandomGame: true).Wait();
                        break;
                    case 4:
                        Divide(1, difficultyLevel, calledByRandomGame: true).Wait();
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

            try
            {
                for (int i = 0; i <= secondsBeforeLose; i++)
                {
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
                        secondsElapsed++;
                    }
                    cancellationToken.ThrowIfCancellationRequested();
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



