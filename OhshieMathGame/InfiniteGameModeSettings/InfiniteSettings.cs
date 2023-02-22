using OhshieMathGame.InfiniteGameModeSettings;
public class InfiniteSettings
{
    private static bool ChangesWereMade;
    // method saves all changes
    private static void SaveSettings()
    {
        if (ChangesWereMade)
        {
            GameController.GamesPlayed = 0; 
            GameController.Score = 0;
            MaxNumberConfiguration.SaveOperatorConfiguration();
            EquationLengthConfiguration.SaveOperatorConfiguration();
            OperatorsConfiguration.SaveOperatorConfiguration();
            GameController.PrevGames.Clear();
        }
        else
        {
            GameController.GamesPlayed = 0; 
            GameController.Score = 0;
            MaxNumberConfiguration.SaveOperatorConfiguration();
            EquationLengthConfiguration.SaveOperatorConfiguration();
            GameController.OperatorsInPlay=GameController.AllPossibleOperators;
            GameController.PrevGames.Clear();
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
                              $"1. Amount of variables in equation.\n" +
                              $"2. Maximum size for variables in equation.\n" +
                              "3. Activate/Deactivate operators");
            Console.WriteLine("4. Confirm those settings");
            Program.MenuOperator = Console.ReadKey().Key;
            switch (Program.MenuOperator)
            {
                // adjusting length of equation
                case ConsoleKey.D1:
                {
                    Console.Clear();
                    EquationLengthConfiguration.LengthOfEquation();
                    ChangesWereMade = true;
                    continue;
                }
                // adjusting max value of variables
                case ConsoleKey.D2:
                {
                    Console.Clear();
                    MaxNumberConfiguration.AdjustMaximumAllowedNumber();
                    ChangesWereMade = true;
                    continue;
                }
                // allow for different operands in equation. Not implemented yet.
                case ConsoleKey.D3:
                {
                    Console.Clear();
                    OperatorsConfiguration.OperatorsSettings();
                    ChangesWereMade = true;
                    continue;
                }
                // exit settings.
                case ConsoleKey.D4:
                {
                    Console.Clear();
                    ChangesWereMade = false;
                    break;
                }
                default:
                    continue;
            }
            SaveSettings();
            break;
        }
        
    }
}