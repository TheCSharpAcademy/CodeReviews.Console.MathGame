public class GameMenu
{
    private GameRecordsKeeper _gameRecordsKeeper = new GameRecordsKeeper();

    public void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select game mode\n" +
                              "1. Career\n" +
                              "2. Infinite\n" +
                              "3. Display previously played games\n" +
                              "4. Go back to main menu");
            Program.MenuOperator = Console.ReadKey(true).Key;
            switch (Program.MenuOperator)
            {
                case (ConsoleKey.D1):
                {
                    CareerGameMode careerGameMode = new CareerGameMode(); 
                    careerGameMode.GameplayLoop(_gameRecordsKeeper);
                    _gameRecordsKeeper.OverallScoreTracker(true);
                    continue;
                }
                case (ConsoleKey.D2):
                {
                    InfiniteGameMode infiniteGameMode = new InfiniteGameMode();
                    infiniteGameMode.GameplayLoop(_gameRecordsKeeper);
                    _gameRecordsKeeper.OverallScoreTracker(false);
                    continue;
                }
                case (ConsoleKey.D3):
                {
                    _gameRecordsKeeper.OverallScorePrinter();
                    continue;
                }
                case (ConsoleKey.D4):
                {
                    break;
                }
                default:
                {
                    continue;
                }
            }
            return;
        }
    }
}