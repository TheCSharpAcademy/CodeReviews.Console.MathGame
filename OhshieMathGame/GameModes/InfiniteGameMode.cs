using OhshieMathGame.InfiniteGameModeSettings;

public class InfiniteGameMode
{
    private GameController _gameController = new GameController();
    private InfiniteSettings _infiniteSettings = new InfiniteSettings();

    public void GameplayLoop(GameRecordsKeeper scoreTracker)
    {
        GameRecordsKeeper.InfinitePlayedCounter++;
        
        _infiniteSettings.SettingsMenu(_gameController);

        int cont = 1;
        while (cont == 1)
        {
            _gameController.GamesPlayed++;
            _gameController.GameLogic(false, scoreTracker, _gameController);
            cont = _gameController.ContinueCheck(cont, false);
        }
        scoreTracker.CurrentScorePrinter();
        Console.Clear();
    }
}