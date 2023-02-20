using OhshieMathGame.InfiniteGameModeSettings;
public class InfiniteSettings
{
    // default values
    public static int maxNumber = 11;
    public static int amountOfVariables = 2;

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
                    GameController.gamesPlayed = 0;
                    GameController.score = 0;
                    MaxNumberConfiguration.SaveOperatorConfiguration();
                    EquationLengthConfiguration.SaveOperatorConfiguration();
                    OperatorsConfiguration.SaveOperatorConfiguration();
                    GameController.prevGames.Clear();
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
                              "3. Activate/Deactivate operators\n" +
                              "4. Go back");
            Program.menuOperator = Console.ReadKey().Key;
            switch (Program.menuOperator)
            {
                // adjusting length of equation
                case ConsoleKey.D1:
                {
                    Console.Clear();
                    EquationLengthConfiguration.LengthOfEquation();
                    continue;
                }
                // adjusting max value of variables
                case ConsoleKey.D2:
                {
                    Console.Clear();
                    MaxNumberConfiguration.AdjustMaximumAllowedNumber();
                    continue;
                }
                // allow for different operands in equation. Not implemented yet.
                case ConsoleKey.D3:
                {
                    Console.Clear();
                    OperatorsConfiguration.OperatorsSettings();
                    continue;
                }
                // exit settings.
                case ConsoleKey.D4:
                {
                    Console.Clear();
                    break;
                }
                default:
                    continue;
            }
            break;
        }
        SaveSettings();
    }
}