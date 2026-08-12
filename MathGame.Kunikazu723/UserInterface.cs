using MathGameRecap.Services;
using Spectre.Console;
using static MathGameRecap.Common.Enums;
namespace MathGameRecap
{
    internal class UserInterface
    {
        private readonly GameEngine _engine;
        public UserInterface(GameEngine engine)
        {
            _engine = engine;
        }

        public void MainMenu()
        {
            
            // Could make a while true here instead of do while...
            bool isAppRunning = true;
            do
            {
                AnsiConsole.MarkupLine("[blue]Welcome[/] to the [bold yellow]Math game[/]");
                var mainMenuChoice = AnsiConsole.Prompt(
                        new SelectionPrompt<MenuChoice>()
                        .Title("What would you like to do?")
                        .AddChoices(Enum.GetValues<MenuChoice>())
                    );

                Console.Clear();

                switch (mainMenuChoice)
                {
                    case MenuChoice.Play:
                        GamesMenu();
                        break;
                    case MenuChoice.History:
                        MockDatabase.ViewGamesHistory();
                        break;
                    case MenuChoice.Exit:
                        return;
                }

            } while (isAppRunning);

            
        }

        private void GamesMenu()
        {
            while (true)
            {
                var operatoinChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<GameType>()
                        .Title("Select the game [bold blue]Type / Operation[/]:")
                        .AddChoices(Enum.GetValues<GameType>())
                    );

                if (operatoinChoice == GameType.MainMenu) return;

                var difficultyChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<Difficulty>()
                        .Title("Select the game [bold red]Difficulty[/]:")
                        .AddChoices(Enum.GetValues<Difficulty>())
                    );
                _engine.RunGame(operatoinChoice, difficultyChoice);
            }
        }
    }
}
