using MathGame.gsharshavardhan.Models;
using System.Security.AccessControl;

namespace MathGame.gsharshavardhan;

internal class Helpers
{
    private static List<Game> gameHistory = new();
    internal static void AddToGameHistory(GameType gameType, int points)
    {
        gameHistory.Add(new Game
        {
            DatePlayed = DateTime.Now,
            GameType = gameType,
            Score = points
        } );
    }
    internal static int[] GetDivisionNumbers()
    {
        var random = new Random();
        int firstNumber = random.Next(1, 100);
        int secondNumber = random.Next(1, 100);

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 100);
            secondNumber = random.Next(1, 100);
        }

        int[] result =
        {
            firstNumber, secondNumber
        };

        return result;
    }
    internal static void ShowPreviousGames()
    {
        Console.Clear();
        PrintLine();
        Console.Write("PREVIOUS GAMES\n");
        foreach (var game in gameHistory) Console.WriteLine($"{game.DatePlayed} - {game.GameType}: {game.Score} pts");
        PrintLine();
        Console.WriteLine("Press any key to go back to the main menu");
        Console.ReadKey(true);
        Console.Clear();
    }

    internal static void PrintLine()
    {
        Console.WriteLine($"{"".PadLeft(Console.WindowWidth, '=')}\n");
    }

    internal static int ParseResult()
    {
        int result = 0;
        var validInput = false;
        while (!validInput)
        {
            validInput = Int32.TryParse(Console.ReadLine(), out int i);
            if (!validInput) { Console.WriteLine("Answer can only be an integer. Try again!"); }
            result = i;
        }

        return result;
    }
}
