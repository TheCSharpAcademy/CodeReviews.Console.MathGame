
namespace mathGame.bkohler93;

public class App
{
    private MathGame mathGame = new();
    private List<string> gameHistory = [];
    public void Run()
    {
        bool keepPlaying = true;
        while (keepPlaying)
        {
            int option = UI.MenuSelection("Math Game Main Menu:",
                ["Play Self-Selection",
                    "Play Random-Selection Game",
                    "Settings",
                    "View Game History",
                    "Exit"]);

            switch (option)
            {
                case 1:
                    mathGame.PlaySelfSelection();

                    LogGameResult();
                    break;
                case 2:
                    mathGame.PlayRandomSelection();

                    LogGameResult();
                    break;
                case 3:
                    mathGame.ConfigureGame();
                    break;
                case 4:
                    ViewGameHistory();
                    break;
                case 5:
                    keepPlaying = false;
                    break;
            }
        }
    }

    private void LogGameResult()
    {
        string? gameResult = mathGame.ToString();

        gameHistory.Add(gameResult!);

        mathGame.Reset();
    }

    private void ViewGameHistory()
    {
        if (gameHistory.Count == 0)
        {
            UI.DisplayConfirmation("No game history yet");
            return;
        }

        Console.WriteLine("=== Game History ===");
        foreach (var game in gameHistory)
        {
            Console.WriteLine(game);
        }
    }
}