using MathGame.Enums;
using MathGame.Helpers;
using MathGame.Views;

namespace MathGame.Menus;

internal class MainMenu(IGameMenu gameMenu, IGameView gameView, IGameHistoryView historyView) : IMainMenu
{
    private readonly IGameMenu _gameMenu = gameMenu;
    private readonly IGameView _gameView = gameView;
    private readonly IGameHistoryView _historyView = historyView;

    private const string Title = "Welcome to The Math Game!";
    private readonly MainMenuOptions[] MenuOptions = [MainMenuOptions.Play, MainMenuOptions.History, MainMenuOptions.Exit];
    public void Display()
    {
        var exit = false;
        while (!exit)
        {
            Console.Clear();
            var selection = ConsoleHelper.Prompt<MainMenuOptions>(Title, MenuOptions);

            switch (selection)
            {
                case MainMenuOptions.Play:
                    var gameMode = _gameMenu.SelectGameMode();
                    var difficulty = _gameMenu.SelectDifficulty();
                    _gameView.DisplayGame(gameMode, difficulty);
                    break;

                case MainMenuOptions.History: 
                    _historyView.DisplayHistory();
                    break;
                case MainMenuOptions.Exit:
                    exit = true;
                    break;
            }
        }
    }
}
