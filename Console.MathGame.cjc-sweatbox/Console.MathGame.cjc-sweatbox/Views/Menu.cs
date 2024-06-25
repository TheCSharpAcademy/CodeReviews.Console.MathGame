// -------------------------------------------------------------------------------------------------
// Console.MathGame.cjc_sweatbox.Views.Menu
// -------------------------------------------------------------------------------------------------
// The menu console view of the application.
// -------------------------------------------------------------------------------------------------
using System.Text;
using Console.MathGame.cjc_sweatbox.Enums;
using Console.MathGame.cjc_sweatbox.Models;
using Console.MathGame.cjc_sweatbox.Data;
using Console.MathGame.cjc_sweatbox.Logic;

namespace Console.MathGame.cjc_sweatbox.Views
{
    internal class Menu
    {
        #region Variables

        private bool _startup = true;
        private readonly MathGameDataManager _dataManager;

        #endregion
        #region Constructors

        internal Menu(MathGameDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        #endregion
        #region Properties

        internal static string MenuText
        {
            get
            {
                var menuTextSb = new StringBuilder();
                menuTextSb.AppendLine("V - View previous games");
                menuTextSb.AppendLine("A - Addition");
                menuTextSb.AppendLine("S - Subtraction");
                menuTextSb.AppendLine("M - Multiplication");
                menuTextSb.AppendLine("D - Division");
                menuTextSb.AppendLine("R - Random");
                menuTextSb.AppendLine("Q - Quit the application");
                menuTextSb.AppendLine("");
                menuTextSb.AppendLine("Enter your selection: ");

                return menuTextSb.ToString();
            }
        }

        #endregion
        #region Methods: Internal

        internal GameStatus Show(string? name, DateTime date)
        {
            if (_startup)
            {
                System.Console.Clear();
                System.Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your math's game.\n");
                System.Console.WriteLine($"Press any key to show menu...");
                System.Console.ReadLine();
                _startup = false;
            }

            System.Console.Clear();
            System.Console.Write(MenuText);

            var option = GetOption();

            return PerformOption(option);
        }

        internal GameStatus PerformOption(string option)
        {
            // Keep Started unless explicitly set to Stopped.
            var result = GameStatus.Started;

            var gameEngine = new GameEngine(_dataManager);

            switch (option)
            {
                case "v":
                    IReadOnlyList<Game> gameHistory = [];
                    if (_dataManager != null)
                    {
                        gameHistory = _dataManager.GetGames();
                    }
                    GameHistory.Show(gameHistory);
                    break;
                case "a":
                    gameEngine.PlayGame(GameType.Addition);
                    break;
                case "s":
                    gameEngine.PlayGame(GameType.Subtraction);
                    break;
                case "m":
                    gameEngine.PlayGame(GameType.Multiplication);
                    break;
                case "d":
                    gameEngine.PlayGame(GameType.Division);
                    break;
                case "r":
                    gameEngine.PlayGame(GameType.Random);
                    break;
                case "q":
                    result = GameStatus.Stopped;
                    break;
                default:
                    System.Console.WriteLine("Invalid option selected. Press any key to continue...");
                    System.Console.ReadLine();
                    break;
            }

            return result;
        }

        #endregion
        #region Methods: Internal Static

        internal static string GetOption()
        {
            var option = System.Console.ReadLine();

            // Normalise.
            option = string.IsNullOrWhiteSpace(option) ? "" : option.Trim().ToLower();

            return option;
        }

        #endregion

    }
}
