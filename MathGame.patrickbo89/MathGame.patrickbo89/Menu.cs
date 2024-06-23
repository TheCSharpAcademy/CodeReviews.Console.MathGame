namespace MathGame.patrickbo89;

internal class Menu
{
    internal void DisplayMenu(DateTime date, GameEngine gameEngine, string name)
    {
        bool isGameRunning = true;

        UserInterface.DisplayGreeting(date, name);

        do
        {
            UserInterface.DisplayMenuOptions();

            var selectedOption = Console.ReadLine();

            switch (selectedOption?.Trim().ToLower())
            {
                case "v":
                    UserInterface.DisplayHistory(gameEngine);
                    break;
                case "a":
                    Game game = gameEngine.SetupGame(GameType.Addition);
                    gameEngine.StartGame(game);
                    break;
                case "s":
                    game = gameEngine.SetupGame(GameType.Subtraction);
                    gameEngine.StartGame(game);
                    break;
                case "m":
                    game = gameEngine.SetupGame(GameType.Multiplication);
                    gameEngine.StartGame(game);
                    break;
                case "d":
                    game = gameEngine.SetupGame(GameType.Division);
                    gameEngine.StartGame(game);
                    break;
                case "r":
                    game = gameEngine.SetupGame(GameType.Random);
                    gameEngine.StartGame(game);
                    break;
                case "q":
                    UserInterface.DisplayQuitMessage();

                    isGameRunning = false;
                    break;
                default:
                    UserInterface.DisplayInvalidMenuChoiceMessage();
                    break;
            }
        } while (isGameRunning);
    }
}