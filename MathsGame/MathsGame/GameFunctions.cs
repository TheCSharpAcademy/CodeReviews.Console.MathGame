using System.Timers;

namespace MathsGame;

public class GameFunctions
{
    const int EASY = 1;
    const int MEDIUM = 2;
    const int HARD = 3;

    internal static System.Timers.Timer newTimer;
    internal static int seconds;

    internal static int[] SetDifficulty(int[] difficulty)
    {
        // Set up initial variables
        string? result;
        bool validInput = false;
        int userChoice = 0;

        do
        {
            Helpers.ConsoleClear();
            Console.WriteLine($"Choose your difficulty:\n");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard\n");
            Console.WriteLine("Enter a valid number from the list.");

            result = Console.ReadLine();

            if (result == null)
            {
                Console.WriteLine("Input is null. Exiting the program");
                Environment.Exit(1);
                    return difficulty;
            }

            try
            {
                int.Parse(result);
            
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No input detected. Please choose an option from the menu.\n");
                continue;
            }
            catch (FormatException)
            {
                Console.WriteLine($"{result} is not a valid number. Please choose an option from the menu.\n");
                continue;
            }

            userChoice = int.Parse(result);
            if (Helpers.isInRange(userChoice, 1, 3))
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine($"{userChoice} is not a menu option. Please choose again.\n");
            }
        
        } while (validInput == false);

        switch (userChoice)
        {
            case EASY:
                difficulty[0] = 0;
                difficulty[1] = 9;
                    return difficulty;
            case MEDIUM:
                difficulty[0] = 0;
                difficulty[1] = 100;
                    return difficulty;
            case HARD:
                difficulty[0] = -100;
                difficulty[1] = 100;
                    return difficulty;
            default:
                difficulty[0] = 0;
                difficulty[1] = 9;
                    return difficulty;
        }
    }

    internal static void ViewLog(List<string> log)
    {
        Console.WriteLine("---------- Past Games Log ----------\n");

        foreach (string line in log)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadLine();
    }

    internal static bool DividesIntoInt(int firstNumber, int secondNumber)
    {
        if (firstNumber % secondNumber == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

