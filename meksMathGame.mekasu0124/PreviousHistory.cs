public static class PreviousHistory
{
    public static int gameCount = 0;

    public static List<string> addGames = new();
    public static List<string> subGames = new();
    public static List<string> mulGames = new();
    public static List<string> divGames = new();

    public static void PrintHistory()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Your Previous Games");
        Console.WriteLine("\nAddition Games");
        
        foreach (string s in addGames)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine("\nSubtraction Games");

        foreach (string s in subGames)
        {
            Console.WriteLine(s);
        };

        Console.WriteLine("\nMultiplication Games");

        foreach (string s in mulGames)
        {
            Console.WriteLine(s);
        };

        Console.WriteLine("\nDivision Games");

        foreach (string s in divGames)
        {
            Console.WriteLine(s);
        };

        Console.WriteLine("\nWould You Like To Play Again or Exit Program?");

        string playCheck = "";

        for (int i = 0; i < 3; i++)
        {
            playCheck = Console.ReadLine();

            if (playCheck.ToLower() == "play again")
            {
                break;
            }
            else if (playCheck.ToLower() == "exit program")
            {
                Console.WriteLine("Exiting Program. Please Wait. . .");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }    
        };

        Console.WriteLine("Launching Main Menu. Please Wait. . .");
        Thread.Sleep(2000);
        Console.Clear();

        MainMenu mainMenu = new();
        mainMenu.DifficultySelection();
    }

    public static void AddHistory(int num1, string operatorSymbol, int num2, int solution, bool rightWrong)
    {
        gameCount++;
        string writeString = $"Game {gameCount}: {num1} {operatorSymbol} {num2} = {solution} -> solution {(rightWrong ? "correct" : "wrong")}";

        switch (operatorSymbol)
        {
            case "+":
                addGames.Add(writeString);
                break;

            case "-":
                subGames.Add(writeString);
                break;

            case "*":
                mulGames.Add(writeString);
                break;

            case "/":
                divGames.Add(writeString);
                break;

            default:
                Console.WriteLine("Invalid Operation Writing Game History.");
                Thread.Sleep(2000);
                Environment.Exit(0);
                break;
        }
    }
}