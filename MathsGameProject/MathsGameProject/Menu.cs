using Spectre.Console;

namespace MathsGameProject

{
    internal static class Menu
    {
        private static List<string> MenuOptions = new List<string>
        {
            "Addition",
            "Subtraction",
            "Multiplication",
            "Division",
            "Random",
            "View History",
            "Configuration",
            "Quit Game"
        };
        internal static void MainMenu()
        {
            Console.Clear();
           string menuOption = AnsiConsole.Prompt(
           new SelectionPrompt<string>()
               .Title("Choose an option")
               .AddChoices(MenuOptions));

            ConfigurationSettings.GameType = menuOption switch
            {
                "Addition"=> Enums.GameTypes.addition,
                "Subtraction"=> Enums.GameTypes.subtraction,
                "Multiplication"=> Enums.GameTypes.multiplication,
                "Division"=> Enums.GameTypes.division,
                "Random"=> Enums.GameTypes.Random,
                "View History"=> Enums.GameTypes.ViewHistory,
                "Configuration"=> Enums.GameTypes.Configuration,
                "Quit Game"=> Enums.GameTypes.QuitGame,
                _ => Enums.GameTypes.QuitGame
            };
        }

    }
}
