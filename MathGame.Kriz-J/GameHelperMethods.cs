using static MathGame.Kriz_J.ConsoleHelperMethods;

namespace MathGame.Kriz_J;

public class GameHelperMethods
{
    public static void SetGameDifficulty(char difficulty)
    {
        switch (difficulty)
        {
            case 'E':
                FormatWriteLineWithHighlight("", "\t\t[E]asy", " [M]edium [H]ard");
                break;
            case 'M':
                FormatWriteLineWithHighlight("\t\t[E]asy ", "[M]edium", " [H]ard");
                break;
            case 'H':
                FormatWriteLineWithHighlight("\t\t[E]asy [M]edium ", "[H]ard", "");
                break;
        }
    }

    public static void SetGameMode(char mode)
    {
        switch (mode)
        {
            case 'S':
                FormatWriteLineWithHighlight("", "\t\t[S]tandard", " [T]imed");
                break;
            case 'T':
                FormatWriteLineWithHighlight("\t\t[S]tandard ", "[T]imed", "");
                break;
        }
    }

    public static void GameCountDown()
    {
        for (int i = 3; i > 0; i--)
        {
            Console.Write($"{i} . . . ");
            Thread.Sleep(1000);
        }
    }

}

