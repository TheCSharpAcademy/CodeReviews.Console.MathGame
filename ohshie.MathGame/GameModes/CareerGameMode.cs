public class CareerGameMode
{
    public static int Lives = 4;
    public static int DifficultyLevel;
    private static Random _random = new Random();
    private GameController _gameController = new GameController();

    public void GameplayLoop(GameRecordsKeeper scoreTracker)
    {
        Lives = 4;
        GameRecordsKeeper.CareerPlayedCounter++;
        
        int cont = 1;
        while (cont == 1 && Lives > 0) 
        {
            _gameController.GamesPlayed++;
            
            DifficultySettings();
            
            _gameController.GameLogic(true, scoreTracker, _gameController);
            
            cont = _gameController.ContinueCheck(cont, true);
        }
        scoreTracker.CurrentScorePrinter();
        WhenGameFinished();
    }
    
    // method is used as an easy way to adjust difficulty for career game mode
    private void DifficultySettings()
    {
        switch (_gameController.GamesPlayed)
        {
            case (1):
            {
                AdjustOperatorsInPlay();
                _gameController.MaxNumber = 10;
                _gameController.AmountOfVariables = 2;
                DifficultyLevel = 1;
                break;
            }
            case (6):
            {
                AdjustOperatorsInPlay();
                _gameController.MaxNumber = 20;
                _gameController.AmountOfVariables = 3;
                DifficultyLevel = 2;
                break;
            }
            case (11):
            {
                AdjustOperatorsInPlay();
                _gameController.AmountOfVariables = 4;
                DifficultyLevel = 3;
                break;
            }
            case (16):
            {
                AdjustOperatorsInPlay();
                _gameController.AmountOfVariables = 5;
                DifficultyLevel = 4;
                break;
            }
            case (21):
            {
                _gameController.MaxNumber = 50;
                DifficultyLevel = 5;
                break;
            }
        }
    }
    
    // helper method for difficulty settings
    private void AdjustOperatorsInPlay()
    {
        int operatorChooser = _random.Next(0, _gameController.AllPossibleOperators.Count-1);
        _gameController.OperatorsInPlay.Add(_gameController.AllPossibleOperators[operatorChooser]);
        _gameController.AllPossibleOperators.Remove(_gameController.AllPossibleOperators[operatorChooser]);
    }
    
    private void WhenGameFinished()
    {
        Console.Clear();
        if (Lives < 1)
        {
            Console.WriteLine("Dang! You run out of lives.\n" +
                              $"You've solved {_gameController.Score} equations our of possible 25");
            return;
        }
        
        if (_gameController.GamesPlayed==26)
        {
            Console.WriteLine("You WON");
        }
        else
        {
            Console.WriteLine("You decided to stop.");
        }
        Console.WriteLine($"You still had {Lives} lives left\n" +
                          $"You've solved {_gameController.Score} equations our of possible 25");
    }
}