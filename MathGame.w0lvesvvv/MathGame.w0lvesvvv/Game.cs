namespace MathGame.w0lvesvvv
{
    public class Game
    {
        // You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
        // You don't need to record results on a database. Once the program is closed the results will be deleted.
        List<GameResult> listResults = new List<GameResult>();

        private string option { get; set; }
        private bool validOption
        {
            get
            {
                if (string.IsNullOrEmpty(operatorSymbol) && option != "V" && option != "Q" && option != "X")
                    return false;

                return true;
            }
        }
        private string operatorSymbol
        {
            get
            {
                switch (option)
                {
                    case "A":
                        return "+";
                    case "S":
                        return "-";
                    case "M":
                        return "*";
                    case "D":
                        return "/";
                    case "R":
                        return GetRandomSymbol();
                    default:
                        return string.Empty;
                }
            }
        }
        private int numberAttempts { get; set; }
        private int difficulty { get; set; } = 1;

        #region PUBLIC METHODS
        public void DisplayMenu()
        {
            do
            {
                // Users should be presented with a menu to choose an operation
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=======================================================================");
                Console.WriteLine("What games would you like to play today? Choose from the options below:");
                Console.WriteLine("V - View previous games:");
                Console.WriteLine("A - Addition");
                Console.WriteLine("S - Subtraction");
                Console.WriteLine("M - Multiplication");
                Console.WriteLine("D - Division");
                // Create a 'Random Game' option where the players will be presented with questions from random operations
                Console.WriteLine("R - Random Game");
                // Try to implement levels of difficulty.
                Console.WriteLine("X - Change difficulty (Easy by default)");
                Console.WriteLine("Q - Quit the program");
                Console.WriteLine("=======================================================================");
                Console.Write("Option selected: ");

                Console.ForegroundColor = ConsoleColor.White;
                option = Console.ReadLine();

                if (!validOption)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("You have to choose a valid option, try again.");
                    Console.WriteLine();
                }

            } while (!validOption);
        }

        public void ExecuteGame()
        {
            #region Quit Game
            if (option.Equals("Q"))
            {
                Environment.Exit(0);
            }
            #endregion

            #region View Previous Games
            if (option.Equals("V"))
            {
                DisplayPreviousGames();
                return;
            }
            #endregion

            #region Change Difficulty
            if (option.Equals("X"))
            {
                SetDifficulty();
                return;
            }
            #endregion

            #region Operation Game
            // Add a function that let's the user pick the number of questions.
            SetNumberQuestions();

            Random random = new Random();
            GameResult gameResult = new GameResult(option);

            // Add a timer to track how long the user takes to finish the game.
            gameResult.StartTimer();

            for (int i = 0; i < numberAttempts; i++)
            {
                // The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100.
                var currentSymbol = operatorSymbol;
                var numA = currentSymbol.Equals("/") ? random.Next(0, 101 * difficulty) : random.Next(0, 11 * difficulty);
                var numB = random.Next(0, 11 * difficulty);

                Console.Write($"{numA} {currentSymbol} {numB}: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out var result) && result == ExpectedOutput(numA, numB, currentSymbol))
                {
                    gameResult.IncreasePoint();
                }
            }

            gameResult.StopTimer();

            gameResult.DisplayResult();

            listResults.Add(gameResult);
            Console.WriteLine();
            #endregion
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Displays on console all the previous games 
        /// </summary>
        private void DisplayPreviousGames()
        {
            if (listResults.Any())
            {
                var reversedResults = listResults;
                reversedResults.Reverse();
                foreach (var result in reversedResults)
                {
                    result.DisplayResult();
                }
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There aren't previous games.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Ask the player the number of questions that the game will do
        /// </summary>
        private void SetNumberQuestions()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the number of rounds: ");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();

            int tempNumberAttempts;

            if (!int.TryParse(input, out tempNumberAttempts) || tempNumberAttempts <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid number of rounds. Rounds has been set to 10.");
                Console.ForegroundColor = ConsoleColor.White;
                numberAttempts = 10;
            }
            else
            {
                numberAttempts = tempNumberAttempts;
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Returns the expected output of the operation
        /// </summary>
        /// <param name="numA"></param>
        /// <param name="numB"></param>
        /// <param name="operatorSymbol"></param>
        /// <returns></returns>
        private int ExpectedOutput(int numA, int numB, string operatorSymbol)
        {
            // You need to create a Math game containing the 4 basic operations
            switch (operatorSymbol)
            {
                case "+":
                    return numA + numB;
                case "-":
                    return numA - numB;
                case "*":
                    return numA * numB;
                case "/":
                    return numA / numB;
                default:
                    return default;
            }
        }

        /// <summary>
        /// Returns a random symbol between: + - / *
        /// </summary>
        /// <returns></returns>
        private string GetRandomSymbol()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 5);

            switch (randomNumber)
            {
                case 1:
                    return "+";
                case 2:
                    return "-";
                case 3:
                    return "*";
                case 4:
                    return "/";
                default:
                    return "+";
            }
        }

        private void SetDifficulty()
        {
            bool valid = false;

            do
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Choose difficulty");
                Console.WriteLine(" - 1: Easy");
                Console.WriteLine(" - 2: Hard");
                Console.Write("Type number option: ");

                Console.ForegroundColor = ConsoleColor.White;

                if (!int.TryParse(Console.ReadLine(), out int optionDifficult) || (optionDifficult != 1 && optionDifficult != 2))
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option.");
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Difficult Saved.");
                    difficulty = optionDifficult == 1 ? 1 : 10;
                    valid = true;
                }
            } while (!valid);

            Console.WriteLine();

        }
        #endregion

    }



}

