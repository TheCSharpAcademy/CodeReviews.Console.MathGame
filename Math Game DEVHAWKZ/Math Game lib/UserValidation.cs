using System.Text.RegularExpressions;

namespace Math_Game_lib
{
    internal static class UserValidations
    {
        // choice validation
        internal static string GetChoice(string choice)
        {
            while (string.IsNullOrEmpty(choice))
            {
                Console.WriteLine("\nYou need to choose some of the options in the menu. Please try again.");
                Console.Write("Your choice: ");
                choice = Console.ReadLine();
            }
            return choice;
        }

        // number of questions validation
        private static bool IsInteger(string numberOfQuestions)
        {
            Regex regex = new(@"^\d+$");
            return regex.IsMatch(numberOfQuestions);
        }

        internal static int GetInteger(string numberOfQuestions)
        {
            while (!IsInteger(numberOfQuestions))
            {
                Console.Clear();
                Console.WriteLine("You have entered invalid number.\nPlease try again.");
                numberOfQuestions = Console.ReadLine();
            }
            return Convert.ToInt32(numberOfQuestions);
        }

        // answer validation
        private static bool IsValidAnswer(string answer)
        {
            Regex regex = new(@"^-?\d+$");
            return regex.IsMatch(answer);
        }

        internal static int GetAnswer(string answer)
        {
            while (!IsValidAnswer(answer))
            {
                Console.WriteLine("\nYou have entered invalid number.\nPlease try again.");
                answer = Console.ReadLine();
            }
            return Convert.ToInt32(answer);
        }

        // get level
        internal static string GetLevel(string level)
        {
            while (string.IsNullOrEmpty(level))
            {
                Console.WriteLine("\nYou need to choose some of the options in the menu. Please try again.");
                Console.Write("Your choice: ");
                level = Console.ReadLine();
            }

            return level;
        }
    }
}
