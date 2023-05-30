public static class PreviousHistory
{
    public static int gameCount = 0;

    public static List<string> addGames = new();
    public static List<string> subGames = new();
    public static List<string> mulGames = new();
    public static List<string> divGames = new();

    public static void PrintHistory()
    {
        List<string> history = new();

        history.Add("\nAddition Games");
        history.AddRange(addGames);
        history.Add("\nSubtraction Games");
        history.AddRange(subGames);
        history.Add("\nMultiplication Games");
        history.AddRange(mulGames);
        history.Add("\nDivision Games");
        history.AddRange(divGames);

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Your Previous Games");

        for (int index = 0; index < history.Count; index++)
        {
            Console.WriteLine(history[index]);
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