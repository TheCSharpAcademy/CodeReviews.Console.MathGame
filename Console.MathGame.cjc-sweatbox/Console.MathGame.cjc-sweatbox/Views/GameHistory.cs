// -------------------------------------------------------------------------------------------------
// Console.MathGame.cjc_sweatbox.Views.GameHistory
// -------------------------------------------------------------------------------------------------
// The game history console view of the application.
// -------------------------------------------------------------------------------------------------
using Console.MathGame.cjc_sweatbox.Models;

namespace Console.MathGame.cjc_sweatbox.Views
{
    internal static class GameHistory
    {
        #region Constants

        internal const string Title = "Game History";

        #endregion
        #region Methods: Internal Static

        internal static void Show(IReadOnlyList<Game> gameHistory)
        {
            System.Console.Clear();
            System.Console.WriteLine(Title);
            System.Console.WriteLine("--------------------");

            foreach (var game in gameHistory)
            {
                System.Console.WriteLine($"{game.DatePlayed:d} - {game.Type} ({game.Difficulty}): {game.Score} points in {game.TimeTakenInSeconds:N1} seconds");
            }
            System.Console.WriteLine("--------------------");
            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to return to the Main Menu...");
            System.Console.ReadLine();
        }

        #endregion
    }
}
