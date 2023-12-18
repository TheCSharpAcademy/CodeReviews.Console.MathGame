namespace MathGame.StanimalTheMan;

internal static class Menu
{
    public static void ShowMenu()
    {
        Console.WriteLine("Choose an operation below:");
        Console.WriteLine("a - Addition");
        Console.WriteLine("s - Subtraction");
        Console.WriteLine("m - Multiplication");
        Console.WriteLine("d - Division");
        Console.WriteLine("v - View Previous Games");
        Console.WriteLine("q - Quit");

        string userInput = Console.ReadLine();
        PlayGame(userInput);
    }

    private static void PlayGame(string userInput)
    {
        Console.Clear();
 
        switch (userInput)
        {
            case "a":
                Gameplay.PlayAdditionGame();
                break;
            case "s":
                Gameplay.PlaySubtractionGame();
                break;
            case "m":
                Gameplay.PlayMultiplicationGame();
                break;
            case "d":
                Gameplay.PlayDivisionGame();
                break;
            case "v":
                Gameplay.ViewGameHistory();
                break;
            case "q":
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }
}
