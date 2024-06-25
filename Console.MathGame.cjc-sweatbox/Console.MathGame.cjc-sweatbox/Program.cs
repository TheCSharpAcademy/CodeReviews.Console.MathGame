// -------------------------------------------------------------------------------------------------
// Console.MathGame.cjc_sweatbox.Program
// -------------------------------------------------------------------------------------------------
// The insertion point of the console application.
// -------------------------------------------------------------------------------------------------
using Console.MathGame.cjc_sweatbox.Data;
using Console.MathGame.cjc_sweatbox.Enums;
using Console.MathGame.cjc_sweatbox.Utilities;
using Console.MathGame.cjc_sweatbox.Views;

namespace Console.MathGame.cjc_sweatbox
{
    internal class Program
    {
        #region Variables

        private static readonly DateTime _date = DateTime.Now;
        private static MathGameDataManager? _dataManager;
        private static GameStatus _status;

        #endregion
        #region Methods: Private Static

        private static void Main(string[] args)
        {
            var databaseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"math-game.db");
            _dataManager = new MathGameDataManager(databaseFilePath);

            string? name = GetName();

            var menu = new Menu(_dataManager);

            _status = GameStatus.Started;

            while (_status != GameStatus.Stopped)
            {
                _status = menu.Show(name, _date);

            }

            // Close the application.
            Environment.Exit(1);
        }

        #endregion
        #region Methods: Internal Static

        internal static string? GetName()
        {
            System.Console.WriteLine("Please type your name: ");

            var name = UserInputReader.GetString(false);
            return name;
        }

        #endregion
    }
}
