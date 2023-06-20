class Program
{
    public static ConsoleKey MenuOperator;
    private static void MainMenu()
    {
        bool gameStart = false;
        while (gameStart == false)
        {
            Console.Clear();
            Console.WriteLine("Welcome to math game\n" +
                              "Press corresponding key to choose:\n" +
                              "1. Let's play!\n"+
                              "2. Exit");
            MenuOperator = Console.ReadKey(true).Key;
            switch (MenuOperator)
            {
                case ConsoleKey.D1:
                {
                    gameStart = true;
                    break;
                }
                case ConsoleKey.D2:
                {
                    Environment.Exit(0);
                    break;
                }
                default:
                    Console.WriteLine("You entered something that you shouldn't");
                    continue;
            }
        }
    }
    
    public static void Main(string[] args)
    {
        GameMenu gameMenu = new GameMenu();
        
        while (true)
        {
            MainMenu();
            gameMenu.Menu();
        }
    }
}


