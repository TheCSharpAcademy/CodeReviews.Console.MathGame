namespace MathGame.lilWe3zy;

public static class UserInterfaces
{
    public static void DisplayUserMenu(bool printHeader = false)
    {
        Console.Clear();
        if (printHeader)
        {
            // Redundant verbatim prefix left in to better visualize the header
            Console.WriteLine(@"   _   ___ __  __   _   ");
            Console.WriteLine(@"  /_\ / __|  \/  | /_\  ");
            Console.WriteLine(@" / _ \\__ \ |\/| |/ _ \ ");
            Console.WriteLine(@"/_/ \_\___/_|  |_/_/ \_\");

            Console.WriteLine("\nA (c)Sharp Math Application made with <3");
        }

        Console.WriteLine("\nPlease select an option:");
        Console.WriteLine("1) New Game");
        Console.WriteLine("2) View History");
        Console.WriteLine("3) Exit");
    }

    public static void DisplayNewGameMenu(bool printHeader = false)
    {
        Console.Clear();
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

    public static void DisplayDifficultySelection(bool printHeader = false)
    {
        Console.Clear();
        if (printHeader)
        {
            // Redundant verbatim prefixes left in to better visualize the header
            Console.WriteLine(@" ___  _  __  __ _         _ _        ");
            Console.WriteLine(@"|   \(_)/ _|/ _(_)__ _  _| | |_ _  _ ");
            Console.WriteLine(@"| |) | |  _|  _| / _| || | |  _| || |");
            Console.WriteLine(@"|___/|_|_| |_| |_\__|\_,_|_|\__|\_, |");
            Console.WriteLine(@"                                |__/ ");
        }

        Console.WriteLine("\n Difficulty determines the amount of variation and size of the range of numbers.");

        Console.WriteLine("\nPlease select an option:");
        Console.WriteLine("1) Give me confidence");
        Console.WriteLine("2) Give me challenge");
        Console.WriteLine("3) Give me pain");

        Console.WriteLine("\n4) Back");
    }

    public static void DisplayQuestionAmountSelection()
    {
        Console.Clear();
        Console.WriteLine(@" _____    _        _    ___              _   _             ");
        Console.WriteLine(@"|_   _|__| |_ __ _| |  / _ \ _  _ ___ __| |_(_)___ _ _  ___");
        Console.WriteLine(@"  | |/ _ \  _/ _` | | | (_) | || / -_|_-<  _| / _ \ ' \(_-<");
        Console.WriteLine(@"  |_|\___/\__\__,_|_|  \__\_\\_,_\___/__/\__|_\___/_||_/__/");

        Console.WriteLine("\nFinally, please select the amount of questions I should throw your way?");
        Console.WriteLine("I'm not doing more than 100!");
    }

    public static void DisplayEndGameCard(int score, int length)
    {
        Console.Clear();
        // Redundant verbatim prefixes left in to better visualize the header
        Console.WriteLine(@"  ___                        _      _ ");
        Console.WriteLine(@" / __|___ _ _  __ _ _ _ __ _| |_ __| |");
        Console.WriteLine(@"| (__/ _ \ ' \/ _` | '_/ _` |  _(_-<_|");
        Console.WriteLine(@" \___\___/_||_\__, |_| \__,_|\__/__(_)");
        Console.WriteLine(@"              |___/                   ");

        Console.WriteLine($"\nYou scored {score} out of {length}");
        Console.WriteLine($"That's a solid {(double)score / length * 100:F1}%!");

        Console.WriteLine("\nPlease select an option:");
        Console.WriteLine("1) Return to main menu");
        Console.WriteLine("2) View history");
        Console.WriteLine("3) Quit");
    }

    public static void DisplayHistory(List<History> historyList)
    {
        Console.Clear();
        // Redundant verbatim prefixes left in to better visualize the header
        Console.WriteLine(@" _  _ _    _                ");
        Console.WriteLine(@"| || (_)__| |_ ___ _ _ _  _ ");
        Console.WriteLine(@"| __ | (_-<  _/ _ \ '_| || |");
        Console.WriteLine(@"|_||_|_/__/\__\___/_|  \_, |");
        Console.WriteLine(@"                       |__/ ");

        Console.WriteLine("\nA nice in memory store of your previous games:");
        Console.WriteLine("\nTIMESTAMP\tOPERATION\tSCORE\tPERCENTAGE\tDIFFICULTY\tCOMPLETION TIME");

        foreach (History entry in historyList)
        {
            string timeStamp = $"{entry.Id:d}";
            string operation = entry.Operation switch
            {
                1 => "(+)",
                2 => "(-)",
                3 => "(x)",
                4 => "(/)",
                _ => "(?)"
            };
            string score = $"{entry.Score}/{entry.QuestionLength}";
            string percentage = $"{(double)entry.Score / entry.QuestionLength * 100:F1}";
            string difficulty = entry.Difficulty switch
            {
                1 => "easy",
                2 => "medium",
                _ => "hard"
            };
            string elapsedTime =
                $"{entry.TimeElapsed.Hours:00}:{entry.TimeElapsed.Minutes:00}:{entry.TimeElapsed.Seconds:00}";

            Console.WriteLine(
                "----------------------------------------------------------------------------------------");
            Console.WriteLine(
                $"{timeStamp}{operation,12}{score,14}{percentage,10}%{difficulty,16}{elapsedTime,21}");
        }

        Console.WriteLine(
            "----------------------------------------------------------------------------------------");

        Console.WriteLine("\nPlease select an option:");
        Console.WriteLine("1) Return to main menu");
        Console.WriteLine("2) Quit");
    }
}