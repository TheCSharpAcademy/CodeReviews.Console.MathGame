namespace MathGame.mekasu0124;

public class Helpers
{
    public static string ValidateUsernameInput(string input)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        
        foreach (char letter in input)
        {
            if (!alphabet.Contains(letter))
            {
                Console.WriteLine("[Error] Invalid Input. Input Should Only Be English Letters" +
                                  "A-Z or 0-9");
                Console.Write("Your Input: ");
                input = Console.ReadLine();
                return ValidateUsernameInput(input);
            }
        }

        return input;
    }

    public static string ValidateMenuChoice(string input)
    {
        List<string> options = new() { "a", "s", "m", "d", "r", "p", "q" };

        while (!options.Contains(input))
        {
            Console.WriteLine("[Error] Invalid Input. Input Should Be: A, S, M, D, R, P, or Q");
            Console.Write("Your Selection: ");
            input = Console.ReadLine().ToLower();
            return ValidateMenuChoice(input);
        }

        return input switch
        {
            "a" => "Addition",
            "s" => "Subtraction",
            "m" => "Multiplication",
            "d" => "Division",
            "r" => "Random Game",
            "p" => "Previous Games",
            "q" => "Quit Game"
        };
    }

    public static string ValidateNumOfQuestionsInput(string input)
    {
        string numbers = "1234567890";

        foreach (char number in input)
        {
            while (!numbers.Contains(number))
            {
                Console.WriteLine("[Error] Invalid Input. Input Should Be Numbers 0-9");
                Console.Write("Number Of Questions: ");

                input = Console.ReadLine();
                return ValidateNumOfQuestionsInput(input);
            }
        }

        return input;
    }

    public static string ValidateDifficultyChoice(string input)
    {
        List<string> difficultyOptions = new() { "e", "m", "h" };

        while (!difficultyOptions.Contains(input))
        {
            Console.WriteLine("[Error] Invalid Input. Difficulty Should Be E, M, or H");
            Console.Write("What Difficulty Would You Like To Play: ");

            input = Console.ReadLine().ToLower();
            return ValidateDifficultyChoice(input);
        }

        return input switch
        {
            "e" => "Easy",
            "m" => "Medium",
            "h" => "Hard"
        };
    }

    public static int ValidateNumericInput(string question, string input)
    {
        int value;
        
        while (!int.TryParse(input, out value))
        {
            Console.WriteLine("[Error] Input Must Be Numeric");
            Console.Write(question);
            input = Console.ReadLine();
            return ValidateNumericInput(question, input);
        }

        return value;
    }
}