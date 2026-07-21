using MathGame.Helpers;
using MathGame.Repositories;

namespace MathGame.Views;

internal class GameHistoryView(IHistoryRepository historyRepository) : IGameHistoryView
{
    private readonly IHistoryRepository _historyRepository = historyRepository;
    public void DisplayHistory()
    {
        Console.Clear();
        ConsoleHelper.WriteLine("Game History:");
        Console.WriteLine();

        foreach (var entry in _historyRepository.GetGameHistory())
        {
            ConsoleHelper.Write("Game #");
            ConsoleHelper.WriteLine($"{entry.Id}", ConsoleColor.Yellow);

            ConsoleHelper.Write("Game Mode: ");
            ConsoleHelper.WriteLine($"{entry.GameMode}", ConsoleColor.Yellow);

            ConsoleHelper.Write("Difficulty: ");
            ConsoleHelper.WriteLine($"{entry.Difficulty}", ConsoleColor.Yellow);

            ConsoleHelper.Write("Score: ");
            ConsoleHelper.Write($"{entry.CorrectAnswers}", ConsoleColor.Yellow);
            ConsoleHelper.Write(" / ");
            ConsoleHelper.WriteLine($"{entry.TotalQuestions}", ConsoleColor.Yellow);

            ConsoleHelper.Write("Time: ");
            ConsoleHelper.Write($"{entry.TimeTaken.TotalSeconds:0}", ConsoleColor.Yellow);
            ConsoleHelper.WriteLine(" seconds");

            Console.WriteLine();
        }

        ConsoleHelper.WriteLine("Press any key to continue...", ConsoleColor.Yellow);
        Console.ReadKey();
    }
}
