class EndGame
{
    public void EndGameScreen()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@" ========================================= ");
        Console.WriteLine(@"||  ______   _______   __   ________     ||");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"|| |%%%%%%| |%%%%%%%| |%%| |%%%%%%%%%\   ||");
        Console.WriteLine(@"|| |%%%%__| |%%%%%%%| |%%| |%%%%%%%%%%\  ||");
        Console.WriteLine(@"|| |%%%|__  |%%%%%%%| |%%| |%%%%___%%%%\ ||");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"|| |%%%%%%| |%%%_%%%| |%%| |%%%|   |%%%| ||");
        Console.WriteLine(@"|| |%%%%%%| |%%| |%%| |%%| |%%%|   |%%%| ||");
        Console.WriteLine(@"|| |%%% __| |%%| |%%| |%%| |%%%|___|%%%| ||");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"|| |%%%|    |%%| |%%| |%%| |%%%%%%%%%%%| ||");
        Console.WriteLine(@"|| |%%%|__  |%%| |%%|_|%%| |%%%%%%%%%%%/ ||");
        Console.WriteLine(@"|| |%%%%%%| |%%| |%%%%%%%| |%%%%%%%%%%/  ||");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(@"|| |______| |__| |_______| |_________/   ||");
        Console.WriteLine(@"||                                       ||");
        Console.WriteLine(@" ========================================= ");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("The Game Has Come To An End!\n");

        List<string> options = new()
        {
            "Play Again",
            "View Game History",
            "Exit Program"
        };

        foreach (string t in options)
        {
            Console.WriteLine(t);
        };

        Console.WriteLine("\nWhat Would You Like To Do?");

        string userOption = "";

        for (int i = 0; i < 3; i++)
        {
            userOption = Console.ReadLine();

            if (options.Contains(userOption, StringComparer.OrdinalIgnoreCase))
            {
                break;
            }
            else
            {
                Console.WriteLine("Enter A Valid Choice: Play Again, View Game History, Exit Program");
            }
        }

        switch (userOption.ToLower())
        {
            case "play again":
                Console.WriteLine("\nLaunching Main Menu. Please Wait. . .");
                Thread.Sleep(2000);
                Console.Clear();

                MainMenu mainMenu = new();
                mainMenu.DifficultySelection();
                break;

            case "view game history":
                Console.WriteLine("\nLaunching Previous Game History. Please Wait. . .");
                Thread.Sleep(2000);
                Console.Clear();

                PreviousHistory.PrintHistory();
                break;

            case "exit program":
                Console.WriteLine("\nExiting Game. Please Wait. . .");
                Thread.Sleep(2000);
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("\nInvalid Operation Launching Desired Action.");
                Thread.Sleep(2000);
                Console.Clear();
                EndGameScreen();
                break;
        }
    }
}