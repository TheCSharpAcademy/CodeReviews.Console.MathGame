using OhshieMathGame;

class Program
{
    public static double gamesPlayed;
    public static ConsoleKey menuOperator;
    static void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            if (gamesPlayed == 0)
            {
                Console.WriteLine("Welcome to math game\n" +
                                  "Press corresponding key to choose:\n" +
                                  "1. Let's play!\n"+
                                  "2. Adjust difficulty settings\n" +
                                  "3. Exit"); 
            }
            else
            {
                Console.WriteLine($"Correct answers: {Gameplay.score}\n" +
                                  "Press corresponding key to choose:\n" +
                                  "1. Let's play!\n"+
                                  "2. Adjust difficulty settings\n" +
                                  "3. Score record\n" +
                                  "4. Exit");
            }
            
            menuOperator = Console.ReadKey().Key;
            switch (menuOperator)
            {
                case ConsoleKey.D1:
                {
                    break;
                }
                case ConsoleKey.D2:
                {
                    Settings.SettingsMenu();
                    continue;
                }
                case ConsoleKey.D3:
                {
                    ScorePrinter();
                    continue;
                }
                case ConsoleKey.D4:
                {
                    Environment.Exit(0);
                    break;
                }
                default:
                    Console.WriteLine();
                    Console.WriteLine("hm");
                    continue;
            }
            Console.Clear();
            break;
        }
    }
    static void ScorePrinter()
    {
        Console.Clear();
        foreach (var record in Gameplay.prevGames)
        {
            Console.WriteLine(record);
        }

        Console.WriteLine("Press enter to go back");
        Console.ReadLine();
    }
    
    public static void Main(string[] args)
    {
        while (true)
        {
            MainMenu();
            
            Gameplay.GameplayLoop();
        }
    }
}


