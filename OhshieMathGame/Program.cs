using OhshieMathGame;
using OhshieMathGame.GameModes;

class Program
{
    public static ConsoleKey MenuOperator;
    private static void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to math game\n" +
                              "Press corresponding key to choose:\n" +
                              "1. Let's play!\n"+
                              "2. Exit");
            MenuOperator = Console.ReadKey().Key;
            switch (MenuOperator)
            {
                case ConsoleKey.D1:
                {
                    break;
                }
                case ConsoleKey.D2:
                {
                    Environment.Exit(0);
                    break;
                }
                default:
                    Console.WriteLine();
                    Console.WriteLine("You entered something that you shouldn't");
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


