namespace MathGame;

internal class Viewer
{
    internal static void DisplayOptionsMenu()
    {
        Console.WriteLine("\nChoose an action from the following list:\n");
        Console.WriteLine("\ta - Practice adding exercises");
        Console.WriteLine("\ts - Practice subtracting exercises");
        Console.WriteLine("\tm - Practice multiplying exercises");
        Console.WriteLine("\td - Practice dividing exercises");
        Console.WriteLine("\th - Show history of exercises");
        Console.WriteLine("\t0 - Quit this application");
        Console.Write("\nYour option? ");
    }

    internal static void DisplayTitle()
    {
        Console.WriteLine("+-----> Math Trainer <-----+\n");
    }
}