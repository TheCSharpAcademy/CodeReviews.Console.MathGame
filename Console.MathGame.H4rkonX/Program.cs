// Math game - Thecsharp academy project

using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using static System.Formats.Asn1.AsnWriter;

namespace MathGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Menu
            int userSelection = Menu();
            // Initialize variables
            DateTime startingTime = DateTime.MinValue;
            List<string> gameHistory = new List<string>();
            // Start program
            Logic(userSelection, gameHistory, startingTime);
        }

        static int GenerateIntegers(int difficulty)
        {
            var rand = new Random();

            return rand.Next(1, difficulty);
        }

        static int UserInput()
        {
            // Convert user input only to int, if not possible ask the user to enter another number
            while (true)
            {
                int userInput = 0;
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please write a number!");
                    continue;
                }

                return userInput;
            }
        }

        static int Menu()
        {
            while (true)
            {

                int userChoice = -1;

                Console.WriteLine("Welcome! Choose an option from the list:");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Subtraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Division");
                Console.WriteLine("5 - Random");
                Console.WriteLine("6 - Game history");
                Console.WriteLine("7 - Difficulty level");
                Console.WriteLine("0 - Exit");

                try
                {
                    userChoice = Convert.ToInt16(Console.ReadLine());

                    if (userChoice < 0 || userChoice > 7)
                    {
                        throw new System.FormatException();
                    }
                    else if (userChoice == 0)
                    {
                        Environment.Exit(0); // Closes the program
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Please take a look at the available options!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    continue;
                }

                Thread.Sleep(500); // Delete the console after select a correct option
                Console.Clear();
                return userChoice;
            }
        }
        static void Logic(int userSelection, List<string> gameHistory, DateTime startingTime, int score = 0, int selectedDifficulty = 0, bool retried = false, bool randomGame = false)
        {
            // Initialize for random game
            Random random = new Random();

            // Difficulty levels
            List<string> levels = new List<string> {"Easy", "Medium", "Hard"};
            List<int> levelsValues = new List<int> {11, 101, 1001};

            // Initialize variables
            char operation = new char();
            int solution = 0;
            string gameName = "";
            int num1 = GenerateIntegers(levelsValues[selectedDifficulty]);
            int num2 = GenerateIntegers(levelsValues[selectedDifficulty]);

            if (userSelection == 5)
            {
                randomGame = true;
                userSelection = random.Next(1, 5);
            }

            if (userSelection == 4)
            {
                while (num1 % num2 != 0)
                {
                    num1 = GenerateIntegers(levelsValues[selectedDifficulty]);
                    num2 = GenerateIntegers(levelsValues[selectedDifficulty]);
                }
            }

            switch (userSelection)
            {
                case 1:
                    operation = '+';
                    solution = num1 + num2;
                    gameName = "Addition game";
                    break;
                case 2:
                    operation = '-';
                    solution = num1 - num2;
                    gameName = "Subtraction game";
                    break;
                case 3:
                    operation = '*';
                    solution = num1 * num2;
                    gameName = "Multiplication game";
                    break;
                case 4:
                    operation = '/';
                    solution = num1 / num2;
                    gameName = "Division game";
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Games history");
                    foreach (var item in gameHistory)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("Press a key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    userSelection = Menu();
                    Logic(userSelection, gameHistory, startingTime, selectedDifficulty);
                    break;
                case 7:
                    // Difficulty level
                    int userDifficultySelection = -1;
                    while (true)
                    {
                        Console.WriteLine($"Selected: {levels[selectedDifficulty]}");
                        Console.WriteLine("1 - Easy");
                        Console.WriteLine("2 - Medium");
                        Console.WriteLine("3 - Hard");
                        Console.WriteLine("0 - Go back...");

                        userDifficultySelection = UserInput() - 1; // Subtracts one from the selected to match the index on the list
                        if (userDifficultySelection > 3)
                        {
                            Console.WriteLine("Please take a look at the available options!");
                            Thread.Sleep(1500);
                            Console.Clear();
                            continue;
                        }
                        break;
                    }
                    
                    if (userDifficultySelection >= 0)
                    {
                        selectedDifficulty = userDifficultySelection;
                        Console.Clear();
                        userSelection = Menu();
                        Logic(userSelection, gameHistory, startingTime, selectedDifficulty);
                    }
                    else
                    {
                        // If userDifficultySelection < 0, then go back to the menu without changing anything
                        Console.Clear();
                        userSelection = Menu();
                        Logic(userSelection, gameHistory, startingTime, selectedDifficulty);
                    }
                    break;
                default:
                    // Nothing should happen ;)
                    break;
                }

            string template = $"{num1} {operation} {num2}";
            if (retried == false)
            {
                startingTime = DateTime.Now; // Start time
            }

            while (true) 
            {
                Console.WriteLine(gameName);
                Console.WriteLine(template);
                int userInput = UserInput();
                if (userInput == solution)
                {
                    Console.WriteLine("You did it, nice job!");
                    if (randomGame == true)
                    {
                        Thread.Sleep(500);
                        Console.Clear();
                        Logic(userSelection = random.Next(1, 5), gameHistory, startingTime, score += 1, selectedDifficulty, retried = true, randomGame);
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Console.Clear();
                        Logic(userSelection, gameHistory, startingTime, score += 1, selectedDifficulty, retried = true, randomGame);
                    }
                }
                Console.WriteLine($"Game over! Your score was {score}. Wanna play another one Y/N?");
                TimeSpan elapsedTime = DateTime.Now.Subtract(startingTime); // Record the elapsed time
                gameHistory.Add($"{startingTime} - Score: {score} - Difficulty: {levels[selectedDifficulty]} - Elapsed time: {elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}");

                while (true)
                {
                    try
                    {
                        char anotherOne = Convert.ToChar(Console.ReadLine().ToLower());
                        if (anotherOne == 'y')
                        {
                            // Open menu
                            Console.Clear();
                            userSelection = Menu();
                            Console.Clear();
                            Logic(userSelection, gameHistory, startingTime, score = 0, selectedDifficulty, retried = false);
                        }
                        else if (anotherOne == 'n')
                        {
                            Environment.Exit(0);
                        }
                        throw new FormatException();
                    }
                    catch (FormatException) 
                    {
                        Console.WriteLine("Your answer must be Y or N");
                        continue;
                    }
                }
            }
        }
    }
}