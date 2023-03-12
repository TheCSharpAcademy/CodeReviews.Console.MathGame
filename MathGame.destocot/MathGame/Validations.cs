namespace MathGame;

internal class Validations
{
    internal static string ValidateAns(string? input, string question)
    {
        while (string.IsNullOrEmpty(input) || !Int32.TryParse(input, out _))
        {
            Console.WriteLine("invalid entry, press [enter] to try again.");
            Console.ReadLine();
            Console.Write(question);
            input = Console.ReadLine();
        }
        return input;
    }

    internal static string GetNumberOfQuestions(string? input)
    {
        var isValid = true;
        var numberOfQuestions = "";

        do
        {
            input = ValidateInt(input, Helpers.DisplayQuestionsPrompt);

            switch (input.Trim())
            {
                case "1":
                    numberOfQuestions = "1";
                    isValid = false;
                    break;
                case "2":
                    numberOfQuestions = "2";
                    isValid = false;
                    break;
                case "3":
                    numberOfQuestions = "3";
                    isValid = false;
                    break;
                default:
                    Console.WriteLine("invalid entry, press [enter] to try again.");
                    Console.ReadLine();
                    Helpers.DisplayQuestionsPrompt();
                    input = Console.ReadLine();
                    break;
            }
        } while (isValid);

        return numberOfQuestions;
    }

    internal static string GetDifficulty(string? input)
    {
        var isValid = true;
        var difficulty = "";

        do
        {
            input = ValidateInt(input, Helpers.DisplayDifficulties);

            switch (input.Trim())
            {
                case "1":
                    Console.ForegroundColor = ConsoleColor.Green;
                    difficulty = "Easy";
                    isValid = false;
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    difficulty = "Medium";
                    isValid = false;
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Red;
                    difficulty = "Hard";
                    isValid = false;
                    break;
                default:
                    Console.WriteLine("invalid entry, press [enter] to try again.");
                    Console.ReadLine();
                    Helpers.DisplayDifficulties();
                    input = Console.ReadLine();
                    break;
            }
        } while (isValid);

        return difficulty;
    }

    internal static string ValidateInt(string? input, Action prompt)
    {
        while (string.IsNullOrEmpty(input) || !Int32.TryParse(input, out _))
        {
            Console.WriteLine("invalid entry, press [enter] to try again.");
            Console.ReadLine();
            prompt.Invoke();
            input = Console.ReadLine();
        }
        return input;
    }
}
