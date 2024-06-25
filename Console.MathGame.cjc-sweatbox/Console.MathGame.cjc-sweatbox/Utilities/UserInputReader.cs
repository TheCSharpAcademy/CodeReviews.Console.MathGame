// -------------------------------------------------------------------------------------------------
// Console.MathGame.cjc_sweatbox.Utilities.UserInputReader
// -------------------------------------------------------------------------------------------------
// Helper class to present a question and return a valid user response from the console.
// -------------------------------------------------------------------------------------------------
using Console.MathGame.cjc_sweatbox.Enums;

namespace Console.MathGame.cjc_sweatbox.Utilities
{
    internal static class UserInputReader
    {
        #region Methods: Internal Static

        internal static int GetInt()
        {
            string? input = System.Console.ReadLine();
            int output;

            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _))
            {
                System.Console.WriteLine("Input must be an Integer.");
                input = System.Console.ReadLine();
            }

            output = int.Parse(input);

            return output;
        }

        internal static int GetInt(int min, int max)
        {
            string? input = System.Console.ReadLine();
            int output;

            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _) || int.Parse(input) < min || int.Parse(input) > max)
            {
                System.Console.WriteLine($"Input must be an Integer between {min} and {max}.");
                input = System.Console.ReadLine();
            }

            output = int.Parse(input);

            return output;
        }

        internal static GameDifficulty GetGameDifficulty()
        {
            string? input = System.Console.ReadLine();
            GameDifficulty output;

            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out _) || !Enum.IsDefined(typeof(GameDifficulty), int.Parse(input)))
            {
                System.Console.WriteLine("Input must be an Integer that represents the Game Difficulty option.");
                input = System.Console.ReadLine();
            }

            output = (GameDifficulty)int.Parse(input);

            return output;
        }

        internal static string GetString(bool allowNullOrEmpty = false)
        {
            string? input = System.Console.ReadLine();

            if (!allowNullOrEmpty)
            {
                while (string.IsNullOrEmpty(input))
                {
                    System.Console.WriteLine("Input must not be empty.");
                    input = System.Console.ReadLine();
                }
            }

            return string.IsNullOrEmpty(input) ? "" : input;
        }

        #endregion
    }
}
