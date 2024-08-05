using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class UserInterface
    {
        public static Options ShowMenu()
        {
            string display = DisplayMenuOptions();

            return GetValidInput<Options>(display, InputValidator.MenuValidator);
        }

        public static int ShowOperation(Operation operation)
        {
            string display = DisplayOperation(operation);

            return GetValidInput<int>(display, InputValidator.NumericInputValidator);
        }

        public static void ShowHistory(List<GameRecord> history)
        {
            Console.WriteLine();
            Console.WriteLine("History:");
            foreach (GameRecord record in history)
            {
                Console.WriteLine(record.ToString());
            }
            Console.WriteLine();
        }

        public static Difficulty ShowDifficultyOptions()
        {
            string display = DisplayDifficultyOptions();

            return GetValidInput<Difficulty>(display, InputValidator.DifficultyValidator);
        }

        public static int ShowNumberOfGames()
        {
            int result;
            bool validSelection = false;
            do
            {
                Console.Write("Please enter a number of games: ");
                validSelection = int.TryParse(Console.ReadLine(), out result);
                if (!validSelection)
                {
                    Console.WriteLine("Invalid selection. Please try again.");

                }

            } while (!validSelection);

            return result;
        }

        public static T GetValidInput<T>(string display, Func<string, (bool, T)> validator)
        {
            do
            {
                Console.Write(display);
                (bool validSelection, T result) = validator(Console.ReadLine());
                if (validSelection)
                {
                    return result;
                }
                Console.WriteLine("Invalid selection. Please try again.");

            } while (true);
        }

        private static string DisplayMenuOptions()
        {
            StringBuilder sbMenu = new StringBuilder();

            sbMenu.AppendLine("1. Addition");
            sbMenu.AppendLine("2. Subtraction");
            sbMenu.AppendLine("3. Multiplication");
            sbMenu.AppendLine("4. Division");
            sbMenu.AppendLine("5. Random Game");
            sbMenu.AppendLine("6. Number of Games");
            sbMenu.AppendLine("7. History");
            sbMenu.AppendLine("8. Choose Difficulty");
            sbMenu.AppendLine("9. Quit");
            sbMenu.AppendLine("Please enter a number (1-9): ");

            return sbMenu.ToString();
        }

        private static string DisplayDifficultyOptions()
        {
            StringBuilder sbDifficulty = new StringBuilder();

            sbDifficulty.AppendLine("1. Easy");
            sbDifficulty.AppendLine("2. Medium");
            sbDifficulty.AppendLine("3. Hard");
            sbDifficulty.AppendLine("Please enter a number (1-3): ");

            return sbDifficulty.ToString();
        }

        private static string DisplayOperation(Operation operation)
        {
            StringBuilder sbOperation = new StringBuilder();

            sbOperation.AppendLine(operation.ToString());
            sbOperation.AppendLine("Please enter the result of the operation: ");

            return sbOperation.ToString();
        }

        public static void DisplayResult(GameRecord gameRecord)
        {
            Console.WriteLine();
            Console.WriteLine(gameRecord.ToString());
            Console.WriteLine();
        }
    }
}
