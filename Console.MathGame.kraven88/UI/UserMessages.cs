using MathGame.Models;
using System.Diagnostics;
using static MathGame.GameLogic;

namespace MathGame.UI;
internal static class UserMessages
{
    internal static void WelcomeMessage()
    {
        var name = GetName("Please enter your name: ");
        var day = DateTime.UtcNow.DayOfWeek;

        Console.WriteLine("-------------------------------------------------");

        Console.WriteLine($"Hello {name!.ToUpper()}. It's {day}. This is your math game. \n" +
                          $"That's great that you are working on improving yourself");
        Console.ReadLine();
    }

    private static string GetName(string message)
    {
        Console.Write(message);
        return Console.ReadLine()!.ToUpper();
    }

    internal static string GetScore(GameEntry entry)
    {
        var completionTime = $"{entry.CompletionTime.Hours:00}:" +
            $"{entry.CompletionTime.Minutes:00}:" +
            $"{entry.CompletionTime.Seconds:00}:" +
            $"{entry.CompletionTime.Milliseconds:0}";

        Console.WriteLine($"Game over. Your score is: {entry.Score}/{entry.NumberOfRounds}, Completion time: {completionTime}");
        Console.ReadLine();
        return $"{DateTime.Now} - {entry.Difficulty} {entry.GameType}. Score: {entry.Score}/{entry.NumberOfRounds}";
    }

    internal static void PrintLine(string message)
    {
        Console.WriteLine(message);
    }

    internal static void Print(string message)
    {
        Console.Write(message);
    }

    internal static string GetString()
    {
        return Console.ReadLine().Trim();
    }

    internal static int GetAndValidateInteger(string errorMessage)
    {
        var isValid = false;
        int answer;
        do
        {
            var answerText = GetString();
            isValid = int.TryParse(answerText, out answer);
            if (isValid == false)
                PrintLine(errorMessage);

        } while (isValid == false);

        return answer;
    }
}
