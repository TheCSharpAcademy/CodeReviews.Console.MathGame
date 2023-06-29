namespace OhshieMathGame.InfiniteGameModeSettings;

public class InfiniteSettings
{
    public void SettingsMenu(GameController currentGame)
    {
        bool settingsConfirmed = false;
        while (settingsConfirmed == false)
        {
            Console.Clear();
            Console.WriteLine("Adjust difficulty?\n" +
                              $"1. Amount of variables in equation.\n" +
                              $"2. Maximum size for variables in equation.\n" +
                              "3. Activate/Deactivate operators");
            Console.WriteLine("4. Confirm those settings");
            Program.MenuOperator = Console.ReadKey().Key;
            switch (Program.MenuOperator)
            {
                case ConsoleKey.D1:
                {
                    Console.Clear();
                    EquationLengthConfiguration.LengthOfEquation();
                    continue;
                }
                case ConsoleKey.D2:
                {
                    Console.Clear();
                    MaxNumberConfiguration.AdjustMaximumAllowedNumber();
                    continue;
                }
                case ConsoleKey.D3:
                {
                    Console.Clear();
                    OperatorsConfiguration.OperatorsSettings();
                    continue;
                }
                case ConsoleKey.D4:
                {
                    settingsConfirmed = true;
                    SaveSettings(currentGame);
                    Console.Clear();
                    return;
                }
                default:
                    Console.WriteLine("Please select appropriate variant");
                    continue;
            }
        }
    }

    private static void SaveSettings(GameController currentGame)
    {
        currentGame.OperatorsInPlay = OperatorsConfiguration._tempAllowedOperators;
        currentGame.AmountOfVariables = EquationLengthConfiguration.TempVariables;
        currentGame.MaxNumber = MaxNumberConfiguration.TempMaxNumber;
    }
}