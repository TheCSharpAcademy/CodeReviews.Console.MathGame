namespace OhshieMathGame.GameModes;

public class InfiniteGameMode
{
    public static void GameplayLoop()
    {
        GameRecordsKeeper.infinitePlayedCounter++;
        
        if (GameController.GamesPlayed==0)
        {
            InfiniteSettings.SettingsMenu();
        }
        
        int cont = 1;
        while (cont == 1)
        {
            GameController.GamesPlayed++;
            GameController.GameLogic(false);
            cont = GameController.ContinueCheck(cont, false);
        }
        
        Console.Clear();
        GameRecordsKeeper.CurrentScorePrinter();
        Console.Clear();
    }
}