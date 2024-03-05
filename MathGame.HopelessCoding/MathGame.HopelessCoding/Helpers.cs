using MathGame.HopelessCoding.Models;

namespace MathGame.HopelessCoding
{
    internal class Helpers
    {
        internal static List<Game> taskHistory = new();

        // List previous games
        internal static void ShowHistory()
        {
            Console.WriteLine("Previous games and correct answers:");
            foreach (var game in taskHistory)
            {
                Console.WriteLine($"{game.Num1} {game.Operation} {game.Num2} = {game.UserAnswer} ({game.Level})");
            }
            Console.WriteLine();
        }

        // Command to add to list
        internal static void AddToHistory(int num1, int num2, int userAnswer, string operation, string level)
        {
            taskHistory.Add(new Game
            {
                Num1 = num1,
                Num2 = num2,
                UserAnswer = userAnswer,
                Operation = operation,
                Level = level
            });
        }

        internal static int ValidateInput(string input)
        {
            int userAnswer;

            if (!int.TryParse(input, out userAnswer))
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
                return ValidateInput(Console.ReadLine());
            }
            else
                return userAnswer;
        }
    }
}
