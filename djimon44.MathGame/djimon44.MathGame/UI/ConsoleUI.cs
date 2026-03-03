using MathGame.Enums;
using MathGame.Models;

namespace MathGame.UI;

public class ConsoleUI
{
    public string ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("=== MATH GAME ===");
        Console.WriteLine("R. Random");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. View History");
        Console.WriteLine("0. Exit");
        Console.Write("\nChoose an option: ");

        return Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
    }

    public string ShowDifficultyMenu()
    {
        Console.Clear();
        Console.WriteLine("=== PICK DIFFICULTY ===");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");

        return Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
    }

    public void DisplayQuestion(MathQuestion question, int number, int total, int timeLimit)
    {
        Console.Clear();
        Console.WriteLine($"=== {question.Game} Game ===");
        Console.WriteLine($"[You have {timeLimit} seconds!]");
        Console.WriteLine($"\nQuestion [{number}/{total}]");
        Console.Write($"{question.OperandA} {OperationSymbol(question.Game)} {question.OperandB} = ");
    }

    public int GetPlayerAnswer()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                return answer;
            }

            Console.Write("Please enter a whole number: ");
        }
    }

    public void DisplayFeedback(bool correct, int correctAnswer = 0)
    {
        if (correct)
        {
            Console.WriteLine("Correct!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine($"Wrong/Out of time. The answer is: [{correctAnswer}]");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    public void DisplaySummary(GameSession session)
    {
        Console.Clear();
        Console.WriteLine($"\nGame over! You scored {session.Score}/{session.TotalQuestions}.");
        Console.WriteLine($"Completion time: {session.Duration}");
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    public void DisplayHistory(IReadOnlyList<GameSession> history)
    {
        Console.Clear();
        Console.WriteLine("=== GAME HISTORY ===\n");

        if (!history.Any())
        {
            Console.WriteLine("No games played yet.");
        }
        else
        {
            foreach (GameSession session in history)
            {
                Console.WriteLine(
                    $"{session.PlayedOn:HH:mm:ss} | {session.Duration} | {session.Game,-15} Game | {session.Difficulty} | {session.Score}/{session.TotalQuestions}");
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }

    private static string OperationSymbol(GameType op)
    {
        switch (op)
        {
            case GameType.Addition:
                return "+";
            case GameType.Subtraction:
                return "-";
            case GameType.Multiplication:
                return "*";
            case GameType.Division:
                return "/";

            default:
                return "?";
        }
    }
}
