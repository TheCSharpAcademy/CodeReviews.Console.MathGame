namespace MathGame
{
    internal class Utilities
    {
        public static string ShowWelcomeScreen()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            Console.WriteLine($"Welcome to the Math Game on {today}!");
            Console.WriteLine($"Kindly enter your username.");

            var userInput = Console.ReadLine() ?? "";

            while (userInput.Trim().Length < 2)
            {
                Console.WriteLine($"Username CANNOT be less than 2 characters.");
                userInput = Console.ReadLine() ?? "";

            }

            return userInput.ToUpper();
        }
        public static int ShowMainMenu(string username)
        {
            Console.WriteLine($"Greetings {username}! What would you like to do?");
            DisplayMainMenuOptions();
            var userInput = Console.ReadLine() ?? "";
            int userChoice;



            while (int.TryParse(userInput, out userChoice) == false)
            {
                Console.WriteLine("Invalid choice!! Kindly enter a VALID INTEGER that corresponds to a valid option on the list.");
                DisplayMainMenuOptions();
                userInput = Console.ReadLine() ?? "";

            }

            return userChoice;


        }
        public static int ShowMainMenu()
        {
            Console.Clear();
            DisplayMainMenuOptions();
            var userInput = Console.ReadLine() ?? "";
            int userChoice;



            while (int.TryParse(userInput, out userChoice) == false)
            {
                Console.WriteLine("Invalid choice!! Kindly enter a VALID INTEGER that corresponds to a valid option on the list.");
                DisplayMainMenuOptions();
                userInput = Console.ReadLine() ?? "";

            }

            return userChoice;


        }

        public static void ShowInvalidMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("Invalid Selection");
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();

        }

        private static void DisplayMainMenuOptions()
        {
            Console.WriteLine(@"What would you like to do?
1.Start New Game
2.View Past Games
3.Quit Program");
        }

        public static int ShowGameModeMenu()
        {
            Console.Clear();
            DisplayGameModeOptions();
            int userChoice;
            var userInput = Console.ReadLine() ?? "";

            while (!int.TryParse(userInput, out userChoice))
            {
                Console.WriteLine("Invalid choice!! Kindly enter a VALID INTEGER that corresponds to a valid option on the list.");
                DisplayGameModeOptions();
                userInput = Console.ReadLine() ?? "";
            }
            return userChoice;
        }

        public static int ShowDifficultyMenu()
        {
            Console.Clear();
            DisplayDifficultyOptions();
            int userChoice;
            var userInput = Console.ReadLine() ?? "";

            while (!int.TryParse(userInput, out userChoice))
            {
                Console.WriteLine("Invalid choice!! Kindly enter a VALID INTEGER that corresponds to a valid option on the list.");
                DisplayDifficultyOptions();
                userInput = Console.ReadLine() ?? "";
            }
            return userChoice;
        }

        private static void DisplayGameModeOptions()
        {
            Console.WriteLine(@"Select the game
1.Addition
2.Subtraction
3.Division
4.Multiplication");

        }
        private static void DisplayDifficultyOptions()
        {
            Console.WriteLine(@"Select the difficulty level
1.Easy
2.Medium
3.Hard");

        }

        public static void ShowGameHistory()
        {
            Console.WriteLine("Showing Game History");

        }

        private enum GameDifficulty
        {
            Easy = 1,
            Normal,
            Hard
        }

        public static string PlayGame(int difficulty, string game)
        {
            var gameDifficulty = (GameDifficulty)difficulty;
            int upperBound;
            int lowerBound;
            Console.Clear();
            Console.WriteLine($"{game} game selected\t\tDifficulty - {gameDifficulty}");
            var random = new Random();
            switch (gameDifficulty)
            {
                case GameDifficulty.Easy:
                    if (game == "Addition" || game == "Subraction" || game == "Division")
                    {
                        lowerBound = 2; upperBound = 100;

                    }

                    else if (game == "Multiplication")
                    {
                        lowerBound = 0; upperBound = 10;

                    }

                    else
                    {
                        return ("Invalid Game selected");
                    }
                    break;
                case GameDifficulty.Normal:
                    if (game == "Addition" || game == "Subraction" || game == "Division")
                    {
                        lowerBound = 100; upperBound = 1000;

                    }

                    else if (game == "Multiplication")
                    {
                        lowerBound = 2; upperBound = 50;

                    }

                    else
                    {
                        return ("Invalid Game selected");
                    }
                    break;
                case GameDifficulty.Hard:
                    if (game == "Addition" || game == "Subraction" || game == "Division")
                    {
                        lowerBound = 1000; upperBound = 10000;

                    }

                    else if (game == "Multiplication")
                    {
                        lowerBound = 2; upperBound = 100;

                    }

                    else
                    {
                        return ("Invalid Game selected");
                    }
                    break;
                default:
                    lowerBound = 0; upperBound = 0;
                    break;
            }
            var firstInteger = random.Next(lowerBound, upperBound);
            var secondInteger = random.Next(lowerBound, upperBound);
            if (game == "Division")
            {
                while (firstInteger % secondInteger != 0 || firstInteger <= secondInteger)
                {
                    secondInteger = random.Next(lowerBound, upperBound);
                }
            }

            switch (game)
            {
                case "Addition":
                    var sum = firstInteger + secondInteger;
                    Console.WriteLine($"What is {firstInteger} + {secondInteger} ?");
                    var response = Console.ReadLine();
                    int userAnswer;
                    while (int.TryParse(response, out userAnswer) == false)
                    {
                        Console.WriteLine("Kindly enter a valid integer");
                        response = Console.ReadLine();
                    }

                    string outcome = userAnswer == sum ? "correct" : "incorrect";
                    Console.WriteLine($"Your answer is {outcome} !\nPress enter to continue");
                    Console.ReadLine();
                    return ($"{DateTime.Now.ToString()}\n\tFor the question: What is {firstInteger} + {secondInteger} ?\n\t\t The expected answer was {sum}\n\t\tYou responded with {userAnswer} which was {outcome}");
                case "Subtraction":
                    var difference = firstInteger - secondInteger;
                    Console.WriteLine($"What is {firstInteger} - {secondInteger} ?");
                    response = Console.ReadLine();
                    while (int.TryParse(response, out userAnswer) == false)
                    {
                        Console.WriteLine("Kindly enter a valid integer");
                        response = Console.ReadLine();
                    }

                    outcome = userAnswer == difference ? "correct" : "incorrect";
                    Console.WriteLine($"Your answer is {outcome} !\nPress enter to continue");
                    Console.ReadLine();
                    return ($"{DateTime.Now.ToString()}\n\tFor the question: What is {firstInteger} - {secondInteger} ?\n\t\t The expected answer was {difference}\n\t\tYou responded with {userAnswer} which was {outcome}");
                case "Multiplication":
                    var multiple = firstInteger * secondInteger;
                    Console.WriteLine($"What is {firstInteger} x {secondInteger} ?");
                    response = Console.ReadLine();
                    while (int.TryParse(response, out userAnswer) == false)
                    {
                        Console.WriteLine("Kindly enter a valid integer");
                        response = Console.ReadLine();
                    }

                    outcome = userAnswer == multiple ? "correct" : "incorrect";
                    Console.WriteLine($"Your answer is {outcome} !\nPress enter to continue");
                    Console.ReadLine();
                    return ($"{DateTime.Now.ToString()}\n\tFor the question: What is {firstInteger} x {secondInteger} ?\n\t\t The expected answer was {multiple}\n\t\tYou responded with {userAnswer} which was {outcome}");
                case "Division":
                    var quotient = firstInteger / secondInteger;
                    Console.WriteLine($"What is {firstInteger} / {secondInteger} ?");
                    response = Console.ReadLine();
                    while (int.TryParse(response, out userAnswer) == false)
                    {
                        Console.WriteLine("Kindly enter a valid integer");
                        response = Console.ReadLine();
                    }

                    outcome = userAnswer == quotient ? "correct" : "incorrect";
                    Console.WriteLine($"Your answer is {outcome} !\nPress enter to continue");
                    Console.ReadLine();
                    return ($"{DateTime.Now.ToString()}\n\tFor the question: What is {firstInteger} / {secondInteger} ?\n\t\t The expected answer was {quotient}\n\t\tYou responded with {userAnswer} which was {outcome}");

            }
            return "Error encountered";
        }




    }


}
