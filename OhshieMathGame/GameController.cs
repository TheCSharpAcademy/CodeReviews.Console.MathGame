using System.Diagnostics;
using OhshieMathGame.GameModes;

public class GameController
{
    // those variables are used in both gamemodes to make them work
    public static double score;
    public static List<string> prevGames = new List<string>();
    public static double effectiveness;
    public static double gamesPlayed;
    public static Random random = new Random();
    public static string equation = "";
    
    public static List<string> possibleOperators = new List<string>()
    {
        "+",
        "-",
        "*",
        "/"
    };

    public static void GameModeSelector()
    {
        while (true)
        {
            Console.WriteLine("Select game mode\n" +
                              "1. Career\n" +
                              "2. Infinite");
            Program.menuOperator = Console.ReadKey().Key;
            switch (Program.menuOperator)
            {
                case (ConsoleKey.D1):
                {
                    CareerGameMode.GameplayLoop();
                    break;
                }
                case (ConsoleKey.D2):
                {
                    InfiniteGameMode.GameplayLoop();
                    break;
                }
            }
        }
    }
    
    // prints out user previous games
    public static void ScorePrinter()
    {
        Console.Clear();
        
        foreach (var record in prevGames)
        {
            Console.WriteLine(record);
        }

        Console.WriteLine("Press enter to go back");
        Console.ReadLine();
    }
}
