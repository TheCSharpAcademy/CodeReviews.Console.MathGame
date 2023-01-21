using SinghxRaj.MathGame.MathGame;

namespace SinghxRaj.MathGame;

internal class MathGameController
{
    private MathGameHistory Games { get; set; } = new();

    public static void Run()
    {
        Display.Intro();
        MathGameHistory games = new();
        bool isRunning = true;
        while (isRunning)
        {
            Display.Options();
            HandleOptions();
        }
        Display.Exit();
    }

    private static int GetOption()
    {
        // TODO
        string? userOption = Console.ReadLine();

        throw new NotImplementedException();
    }

    private static void HandleOptions() 
    {
        // TODO
        int option = GetOption();

        throw new NotImplementedException();
    }
}
