using MathGame.pcjb.Models;

internal static class Screen
{
    internal static char ShowMenu(GameDifficulty difficulty, int numberOfQuestions)
    {
        Console.Clear();
        Console.WriteLine("### Math Game ###");
        Console.WriteLine("(A)ddition Game");
        Console.WriteLine("(S)ubtraction Game");
        Console.WriteLine("(M)ultiplication Game");
        Console.WriteLine("(D)ivision Game");
        Console.WriteLine("(H)istory of previous games");
        Console.WriteLine($"(L)evel of difficulty: {difficulty}");
        Console.WriteLine($"(N)umber of questions: {numberOfQuestions}");
        Console.WriteLine("(Q)uit");
        return char.ToUpper(Console.ReadKey().KeyChar);
    }

    internal static string ShowQuestion(MathQuestion question)
    {
        Console.Clear();
        Console.WriteLine($"{question.Type} game");
        Console.WriteLine($"{question.Text}");

        var answer = Console.ReadLine();
        if (answer != null)
        {
            return answer.Trim();
        }
        return "";
    }

    internal static void ShowResult(MathQuestion question)
    {
        if (question.HasCorrrectAnswer())
        {
            Console.WriteLine("Correct answer :-)");
        }
        else
        {
            Console.WriteLine("Wrong answer :-(");
        }

        Console.WriteLine("Type any key for the next question.");
        Console.ReadKey();
    }

    internal static void ShowScore(GameResult result)
    {
        Console.Clear();
        Console.WriteLine($"{result.Type} game completed.");
        Console.WriteLine($"Your score: {result.Score}");
        Console.WriteLine($"Time elapsed: {FormatDuration(result.Duration)}");
        Console.WriteLine("Type any key to return to the main menu.");
        Console.ReadKey();
    }

    internal static void ShowQuit()
    {
        Console.Clear();
        Console.WriteLine("Goodbye. Thank you for playing Math Game.");
    }

    internal static void ShowHistory(List<GameResult> history)
    {
        Console.Clear();
        Console.WriteLine("History of previous games:");

        if (history != null && history.Count > 0)
        {
            Console.WriteLine(String.Format("{0,-15}{1,-11}{2,5}{3,9}", "Game", "Difficulty", "Score", "Duration"));
            foreach (var result in history)
            {
                Console.WriteLine($"{result.Type,-15}{result.Difficulty,-11}{result.Score,5}{FormatDuration(result.Duration),9}");
            }
        }
        else
        {
            Console.WriteLine("No games played yet.");
        }

        Console.WriteLine("Type any key to return to the main menu.");
        Console.ReadKey();
    }

    internal static char ShowDifficultySelection()
    {
        Console.Clear();
        Console.WriteLine("Level of difficulty");
        Console.WriteLine("(E)asy");
        Console.WriteLine("(N)ormal");
        Console.WriteLine("(H)ard");
        return char.ToUpper(Console.ReadKey().KeyChar);
    }

    internal static string? ShowNumberOfQuestions(int minNumberOfQuestions, int maxNumberOfQuestions)
    {
        Console.Clear();
        Console.WriteLine($"Enter number of questions per game ({minNumberOfQuestions}-{maxNumberOfQuestions}):");
        return Console.ReadLine();
    }

    private static string FormatDuration(TimeSpan duration)
    {
        return duration.ToString(@"mm\:ss"); // No hours displayed as a game should barely take minutes
    }
}