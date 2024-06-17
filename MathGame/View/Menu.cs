using MathGame.Controller;
using MathGame.Model;

namespace MathGame.View; 
internal class Menu
{
    internal static void DisplayMenu(string? message, out int userChoice, out int difficultyLevel)
    {
        Console.Clear();

        string? Message = message?.ToUpper();
        Console.WriteLine($"Hello {Message}! Welcome to Math Games!\n");
        Console.Write("Math Game Menu:\n" +
            "1 - Addition\n" +
            "2 - Subtraction\n" +
            "3 - Multiplication\n" +
            "4 - Division\n" +
            "5 - Random Game\n" +
            "6 - Game History\n" +
            "7 - Exit Game\n");
        Console.Write("Enter Your Choice: ");
        int.TryParse(Console.ReadLine()?.Trim(), out userChoice);
        Console.Clear();

        DisplayChoice(userChoice);

        difficultyLevel = 0;
        if (userChoice != 6 && userChoice != 7)
        {
            Console.WriteLine();
            Console.Write("Select Difficulty Level: \n" +
                "1 - Easy\n" +
                "2 - Medium\n" +
                "3 - Hard\n");
            Console.Write("Enter Your Choice: ");
            int.TryParse(Console.ReadLine()?.Trim(), out difficultyLevel);

            Console.Clear();
        }
    }
    internal static void DisplayChoice(int num)
    {
        switch (num)
        {
            case 1:
                Console.WriteLine("Addition Round Selected"); break;
            case 2:
                Console.WriteLine("Subtraction Round Selected"); break;
            case 3:
                Console.WriteLine("Multiplication Round Selected"); break;
            case 4:
                Console.WriteLine("Division Round Selected"); break;
            case 5:
                Console.WriteLine("Random Round Selected"); break;
            case 6:
                Console.WriteLine("Games History"); break;
            case 7:
                Console.WriteLine("Exit Game"); break;
            default:
                Console.WriteLine("Invalid input"); break;
        }
    }
    internal static void DisplayGameHistory(Game game)
    {
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

        Utility utility = new Utility();
        for (int i = 0; i < utility.MyList.Count; i++)
        {
            Console.WriteLine($"Start: {utility.MyTimeList[i]} | " +
                $"End: {utility.MyList[i].Item1} | " +
                $"Interval: {(utility.MyList[i].Item1 - utility.MyTimeList[i]).TotalSeconds.ToString("F2")} sec | " +
                $"{utility.MyList[i].Item3} score: {utility.MyList[i].Item2}/{game.NumberOfQuestions}");
        }

        Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            Console.WriteLine("\nPress Enter to return to the main menu.");
        }
    }
}

