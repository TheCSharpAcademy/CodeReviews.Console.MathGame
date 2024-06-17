using System.Text;

namespace MathGame.Model;

internal class Utility
{
    
    //Model
    private static List<Tuple<DateTime, int, Operations>> myList = new List<Tuple<DateTime, int, Operations>>();
    private static List<DateTime> myTimeList = new List<DateTime>();

    internal List<Tuple<DateTime, int, Operations>> MyList { get { return myList; } }
    internal List<DateTime> MyTimeList { get {return myTimeList; } }

    protected static void CreateGamesHistory(int gameScore, Operations gameName)
    {
        myList.Add(new Tuple<DateTime, int, Operations>(DateTime.Now, gameScore, gameName));
    }

    //Utility
    protected static string ReadInput()
    {
        //allows printing of correct/wrong a tab space away from user input
        StringBuilder input = new StringBuilder();
        while (true)
        {
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Write("\t");
                break;
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
            else if (!char.IsControl(key.KeyChar))
            {
                input.Append(key.KeyChar);
                Console.Write(key.KeyChar);
            }
        }
        return input.ToString();
    }
    internal static string? ReadFromConsole(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
    protected static string Validation(string message, int num1, int num2, int x)
    {
        string userInput = string.Empty;
        do
        {
            Console.Write(message);
            userInput = ReadInput();
            Console.WriteLine(Judgement(userInput, x));

        } while (string.IsNullOrEmpty(userInput) || !int.TryParse(userInput, out _));
        return userInput;
    }
    protected static int NumberGenerator(int difficultyLevel, out int num2)
    {
        int upperRange = 0;
        switch (difficultyLevel)
        {
            case 1: upperRange = 10; break;
            case 2: upperRange = 100; break;
            case 3: upperRange = 1000; break;
        }

        Random random = new Random();
        int num1 = random.Next(1, upperRange);
        num2 = random.Next(1, upperRange);

        return num1;
    }
    protected static string Judgement(string? msg, int x)
    {
        bool success = int.TryParse(msg, out int result);
        string error = success ? "Wrong!" : "Please enter an Integer";
        return x == result ? "Correct!" : error;
    }
    protected static List<int> GetDivision(int difficultyLevel)
    {
        List<int> numList = new List<int>();
        while (true)
        {
            int num1 = NumberGenerator(difficultyLevel, out int num2);
            if (num1 % num2 == 0)
            {
                numList.Add(num2);
                numList.Add(num1);
                break;
            }
        }
        return numList;
    }
}
internal enum Operations
{
    Addition = 1,
    Subtraction,
    Multiplication,
    Division,
    Random
}
