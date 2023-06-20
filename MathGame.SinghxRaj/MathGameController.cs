using SinghxRaj.MathGame.MathGame;

namespace SinghxRaj.MathGame;

internal class MathGameController
{
    private static MathGameHistory GameHistory = new();

    public static void Run()
    {
        Display.Intro();
        MathGameHistory games = new();
        bool isRunning = true;
        while (isRunning)
        {
            Display.Options();
            isRunning = HandleOptions();
        }
        Display.Exit();
    }

    private static int GetOption()
    {
        string? userOption = Console.ReadLine();
        int option;
        while (!int.TryParse(userOption, out option))
        {
            Console.WriteLine("Invalid input. Try again.");
            userOption = Console.ReadLine();
        }
        return option;
    }

    private static bool HandleOptions() 
    {
        int option = GetOption();

        MathGame.MathGame currentGame;

        switch (option)
        {
            case (int)Option.ExitApplication:
                return false;
            case (int)Option.ViewHistory:
                GameHistory.ViewHistory();
                return true;
            case (int)Option.AdditionGame:
                currentGame = new AddGame();
                break;
            case (int)Option.SubtractionGame:
                currentGame = new SubtractGame();
                break;
            case (int)Option.MultiplicationGame:
                currentGame = new MultiplyGame();
                break;
            case (int)Option.DivisionGame:
                currentGame = new DivideGame();
                break;
            default:
                Console.WriteLine($"{option} is not a valid option.");
                return true; ;
        }
        currentGame.PlayGame();
        GameHistory.Games.Add(currentGame);
        return true;
    }
}
