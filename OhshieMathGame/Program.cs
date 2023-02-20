using OhshieMathGame;
using OhshieMathGame.GameModes;

class Program
{
    public static ConsoleKey menuOperator;
    static void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to math game\n" +
                              "Press corresponding key to choose:\n" +
                              "1. Let's play!\n"+
                              "2. Adjust difficulty settings\n" +
                              "3. Exit");
            menuOperator = Console.ReadKey().Key;
            switch (menuOperator)
            {
                case ConsoleKey.D1:
                {
                    break;
                }
                case ConsoleKey.D2:
                {
                    InfiniteSettings.SettingsMenu();
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
    
    public static void Main(string[] args)
    {
        
        while (true)
        {
            MainMenu();
            GameController.GameModeSelector();
        }
    }
}


