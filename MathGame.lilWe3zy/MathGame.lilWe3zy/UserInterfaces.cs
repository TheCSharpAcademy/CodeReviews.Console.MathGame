namespace MathGame.lilWe3zy;

public static class UserInterfaces
{
    public static void DisplayUserMenu(bool printHeader = false)
    {
        if (printHeader)
        {
            // Redundant verbatim prefix left in to better visualize the header
            Console.WriteLine(@"    _    ____  __  __    _");
            Console.WriteLine(@"   / \  / ___||  \/  |  / \");
            Console.WriteLine(@"  / _ \ \___ \| |\/| | / _ \");
            Console.WriteLine(@" / ___ \ ___) | |  | |/ ___ \");
            Console.WriteLine(@"/_/   \_\____/|_|  |_/_/   \_\");

            Console.WriteLine("\nA (c)Sharp Math Application made with <3");
        }

        Console.WriteLine("\nPlease select an option:");
        Console.WriteLine("1) New Game");
        Console.WriteLine("2) View History");
        Console.WriteLine("3) Exit");
    }

    public static void DisplayNewGameMenu(bool printHeader = false)
    {
        if (printHeader)
        {
            // Redundant verbatim prefix left in to better visualize the header
            Console.WriteLine(@" _  _               ___                ");
            Console.WriteLine(@"| \| |_____ __ __  / __|__ _ _ __  ___ ");
            Console.WriteLine(@"| .` / -_) V  V / | (_ / _` | '  \/ -_)");
            Console.WriteLine(@"|_|\_\___|\_/\_/   \___\__,_|_|_|_\___|");
        }

        string[] gameOptions =
        [
            "Addition Attack!", "Subtraction Subversion", "Multiplying Monsters", "Division Destroyer!",
            "Randomized Recon"
        ];

        Console.WriteLine("\nPlease select one of the options below to start the new game:");
        for (int i = 0; i < gameOptions.Length; i++) Console.WriteLine(FormatGameOption(gameOptions[i], i, 30));

        Console.WriteLine("\n6) Back");
    }

    private static string FormatGameOption(string gameOption, int index, int printWidth)
    {
        string symbol = index switch
        {
            0 => "(+)",
            1 => "(-)",
            2 => "(x)",
            3 => "(/)",
            _ => "(?)"
        };

        return $"{index + 1}) {gameOption}{symbol.PadLeft(printWidth - gameOption.Length)}";
    }

    public static int MainMenu()
    {
        bool validInput = false;
        int userSelection = 0;

        DisplayUserMenu(true);

        do
        {
            string? userInput = Console.ReadLine();
            if (userInput == null)
            {
                Console.WriteLine("Please enter a valid number");
                DisplayUserMenu();
                continue;
            }

            if (int.TryParse(userInput, out userSelection))
            {
                if (userSelection is <= 0 or > 3)
                {
                    Console.WriteLine("Please enter a valid number");
                    DisplayUserMenu();
                    continue;
                }

                validInput = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
                DisplayUserMenu();
            }
        } while (validInput == false);

        return userSelection;
    }

    public static void DisplayDifficultySelection() { }
    public static void DisplayHistorySelection() { }
}