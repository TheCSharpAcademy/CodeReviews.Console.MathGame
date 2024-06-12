using MathGame.jakubecm.Models;

namespace MathGame.jakubecm
{
    internal class Helpers
    {
        // The list of games for keeping a record
        internal static List<Game> games = new();

        /// <summary>
        /// Function that generates two random numbers that are divisible
        /// </summary>
        /// <returns> An array of two divisible numbers</returns>
        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var result = new int[2];

            var firstNumber = random.Next(0, 99);
            var secondNumber = random.Next(0, 99);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);

            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        /// <summary>
        /// Adds the game record with the specified parameters to the list of played games
        /// </summary>
        /// <param name="gameScore">The score the player achieved</param>
        /// <param name="maxScore">Maximal score on the specific game</param>
        /// <param name="gameType">The GameType of the game</param>
        /// <param name="elapsedTime">The time the player took to finish the game</param>
        internal static void AddToHistory(int gameScore, int maxScore, GameType gameType, TimeSpan elapsedTime)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                MaxScore = maxScore,
                Type = gameType,
                Time = elapsedTime
            });
        }

        /// <summary>
        /// A function that takes the name from the user and checks if it is not empty.
        /// </summary>
        /// <returns>The name string the user selects</returns>
        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be an empty string");
                name = Console.ReadLine();
            }
            return name!;
        }

        /// <summary>
        /// Method for printing a history of played games.
        /// </summary>
        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}/{game.MaxScore} pts Time: {game.Time.ToString(@"hh\:mm\:ss")}");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadLine();
        }

        /// <summary>
        /// Method that validates the result of an operation in the game, meaning if the result is a valid integer. If not, it asks for a valid input.
        /// </summary>
        /// <param name="result">User's answer to a question in the game</param>
        /// <returns>A valid string result</returns>
        internal static string ValidateResult(string? result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine();
            }

            return result;
        }

        /// <summary>
        /// A function for getting a game operator based on the game type selected.
        /// </summary>
        /// <param name="gameType">The type of game the user selected</param>
        /// <returns>The string operator of the operation</returns>
        /// <exception cref="InvalidDataException">Gets thrown if there is an invalid game type.</exception>
        internal static string GetGameOperator(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.Addition:
                    return "+";
                case GameType.Multiplication:
                    return "*";
                case GameType.Division:
                    return "/";
                case GameType.Subtraction:
                    return "-";
                case GameType.Random:
                    string randomOperator = GetRandomGameOperator();
                    return randomOperator;
                default:
                    throw new InvalidDataException("Invalid game type");
            }
        }

        /// <summary>
        /// Gets a random operator for the Random Game challenge of this project
        /// </summary>
        /// <returns>A random string operator from the pool</returns>
        internal static string GetRandomGameOperator()
        {
            string[] operatorsPool = { "+", "-", "*", "/" };
            Random dice = new();
            int index = dice.Next(operatorsPool.Length);

            return operatorsPool[index];
        }

        /// <summary>
        /// A helper function to count the result of a operation based on the operator
        /// </summary>
        /// <param name="currentGameOperator">The operation operator</param>
        /// <param name="num1">First operand</param>
        /// <param name="num2">Second operand</param>
        /// <returns>The integer result of the operation</returns>
        /// <exception cref="InvalidDataException">Gets thrown if the operator is invalid</exception>
        internal static int GetOperationResult(string currentGameOperator, int num1, int num2)
        {
            switch (currentGameOperator)
            {
                case "+":
                    return num1+num2;
                case "*":
                    return num1*num2;
                case "-":
                    return num1-num2;
                case "/":
                    return num1 / num2;
                default:
                    throw new InvalidDataException("Invalid operator");
            }
        }

        /// <summary>
        /// Helper function to get the required amount of questions in a game from the user.
        /// </summary>
        /// <returns>An integer representing the amount of requested questions</returns>
        internal static int GetQuestionAmount()
        {
            Console.Clear();
            Console.WriteLine("How many questions would you like?\n Insert a number or press enter to keep the default value (5)");
            Console.Write("Your answer: ");

            bool validInput = false;
            int defaultAmount = 5;
            int questionAmount = 0; // default value

            while (!validInput)
            {
                var userInput = Console.ReadLine();
                validInput = int.TryParse(userInput, out questionAmount);

                if (String.IsNullOrEmpty(userInput))
                {
                    return defaultAmount; 
                }
                else if(validInput)
                {
                    if (questionAmount <= 0)
                    {
                        validInput = false;
                        Console.WriteLine("Invalid input. Amount of questions must be higher than 0.");
                        Console.Write("Your answer: ");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. You need to insert a number.");
                    Console.Write("Your answer: ");
                }
            }

            return questionAmount;
        }
    }
}
