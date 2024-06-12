using MathGame.jakubecm.Models;

namespace MathGame.jakubecm
{
    internal class Helpers
    {
        internal static List<Game> games = new();
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

        internal static void AddToHistory(int gameScore, GameType gameType, TimeSpan elapsedTime)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType,
                Time = elapsedTime
            });
        }

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

        internal static void PrintGames()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("---------------------");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} pts Time: {game.Time.ToString(@"hh\:mm\:ss")}");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Press any key to return to the Main Menu");
            Console.ReadLine();
        }

        internal static string ValidateResult(string? result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer needs to be an integer. Try again.");
                result = Console.ReadLine();
            }

            return result;
        }

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
                default:
                    throw new InvalidDataException("Invalid game type");
            }
        }

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
