namespace OhshieMathGame;

public class Settings
{
    // default values
    public static int maxNumber = 11;
    public static int amountOfVariables = 2;
    
    // temporary storage for data
    private static int tempVariables = 2;
    private static int _tempMaxNumber = 11;
    
    // method used to check if user want to change settings after modifying them. To be implemented - autocheck if changes were made.
    private static void SaveSettings()
    {
        while (true)
        {
            
            Console.WriteLine("Save changes?\n" +
                              "1. Yes\n" +
                              "2. Revert to previous");
            Program.menuOperator = Console.ReadKey().Key;
            switch (Program.menuOperator)
            {
                case ConsoleKey.D1:
                {
                    maxNumber = _tempMaxNumber+1;
                    amountOfVariables = tempVariables;
                    break;
                }
                case ConsoleKey.D2:
                {
                    break;
                }
                default:
                    continue;
            }
            break;
        }

        Program.gamesPlayed = 0;
        Program.score = 0;
    }

    // method to adjust length of equation. Also checks if user entered something that is not a number.
    private static void LengthOfEquation()
    {
        Console.Clear();
        Console.WriteLine("How many variables do you want to have in the equation?\n" +
                          "Number must be 2 or more");
        while (true)
        {
            tempVariables  = int.Parse(Console.ReadLine());
            if (tempVariables >= 2)
            {
              break;  
            }
            Console.WriteLine("Either you entered number below 2, or not a number at all.");
        }
    }
    // method to adjust how big numbers can be in equations
    private static void AdjustMaximumAllowedNumber()
    {
        Console.Clear();
        Console.WriteLine("Enter maximum possible number allowed in equation\n" +
                          "Number must not be 0");
        while (true)
        {
            _tempMaxNumber = int.Parse(Console.ReadLine());
            if (_tempMaxNumber != 0)
            {
                break;
            }
            Console.WriteLine("Either you entered 0, or not a number at all.");
        }
    }

    // Main settings menu
    public static void SettingsMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Keep in mind that changing difficulty will reset your score.");
            Console.WriteLine("What do you want to change?\n" +
                              "1. Amount of variables in equation\n" +
                              "2. Maximum size for variables in equation\n" +
                              "3. Allow equation to have different operands\n" +
                              "4. Go back");
            Program.menuOperator = Console.ReadKey().Key;
            switch (Program.menuOperator)
            {
                // adjusting length of equation
                case ConsoleKey.D1:
                {
                    LengthOfEquation();
                    continue;
                }
                // adjusting max value of variables
                case ConsoleKey.D2:
                {
                    AdjustMaximumAllowedNumber();
                    continue;
                }
                // allow for different operands in equation. Not implemented yet.
                case ConsoleKey.D3:
                {
                    continue;
                }
                // exit settings.
                case ConsoleKey.D4:
                {
                    break;
                }
                default:
                    continue;
            }
            break;
        }

        Console.WriteLine();
        SaveSettings();
    }
}