using MathGame.Models;

using static System.Formats.Asn1.AsnWriter;

namespace MathGame
{
    internal class Helpers
    {
        internal int[] GetNumbers(QuestionType questionType, int lowerBound, int upperBound)
        {
            var random = new Random();
            var firstNumber = random.Next(lowerBound, upperBound);
            var secondNumber = random.Next(lowerBound, upperBound);
            var result = new int[2];

            if (questionType == QuestionType.Division)
            {
                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(lowerBound, upperBound);
                    secondNumber = random.Next(lowerBound, upperBound);
                }
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }   

        internal dynamic ReadMainMenuInput()
        {
            var userInput = Console.ReadLine();
            while (userInput == null)
            {
                Menu.PrintMainMenu();
                Console.WriteLine("Invalid Input. Please enter a valid selection.");
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        internal dynamic ReadDifficultyLevelMenuInput()
        {
            var userInput = Console.ReadLine();
            while (userInput == null)
            {
                Menu.PrintDifficultySelectionMenu();
                Console.WriteLine("Invalid Input. Please enter a valid selection.");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        internal DifficultyLevel PromptDifficultyLevel()
        {
            Console.Clear();
            Menu.PrintDifficultySelectionMenu();
            var userInput = ReadDifficultyLevelMenuInput();
            string key = userInput.Trim().ToLower();
            DifficultyLevel? difficultyLevel = null;

            while (string.IsNullOrEmpty(key) || difficultyLevel == null)
            {
                switch (key)
                {
                    case "e":
                        difficultyLevel = DifficultyLevel.Easy;
                        break;
                    case "m":
                        difficultyLevel = DifficultyLevel.Medium;
                        break;
                    case "h":
                        difficultyLevel = DifficultyLevel.Hard;
                        break;
                    case "i":
                        difficultyLevel = DifficultyLevel.Insane;
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please select a valid option.");
                        Console.ReadKey();
                        break;
                }
            }

            return difficultyLevel.Value;
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Invalid input. Please enter an integer value.");
                result = Console.ReadLine();
            }

            return result;
        }
    }
}
