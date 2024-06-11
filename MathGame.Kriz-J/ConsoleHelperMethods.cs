using System.Numerics;

namespace MathGame.Kriz_J;

public class ConsoleHelperMethods
{
    public static void PrintTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"{title}");
    }

    public static char PrintMessageAwaitResponse(string message)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.Write($"\t{message}");
        Console.CursorVisible = false;
        return ReadUserSelection();
    }
    
    public static char ReadUserSelection()
    {
        return char.ToUpper(Console.ReadKey(intercept: true).KeyChar);
    }
    
    public static int ReadUserInteger()
    {
        while (true)
        {
            var cursorPosition = Console.GetCursorPosition();
            var input = Console.ReadLine();

            if (int.TryParse(input, out var integer))
            {
                return integer;
            }

            ClearInputFromPosition(cursorPosition, input!);
        }
    }

    public static void ClearInputFromPosition((int Left, int Top) position, string input)
    {
        Console.SetCursorPosition(position.Left, position.Top);
        Console.Write(new string(' ', input.Length));
        Console.SetCursorPosition(position.Left, position.Top);
    }

    public static void ClearInputAndDisplayError((int Left, int Top) cursorPosition, string input, string errorMessage)
    {
        ClearInputFromPosition(cursorPosition, input);
        PrintError(errorMessage);
        Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);
    }

    private static void PrintError(string message)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.Write($"{message}");
        Console.ResetColor();
    }

    public static void FormatWriteLineWithHighlight(string before, string highlight, string after)
    {
        Console.Write($"{before}");
        SetHighlightColors();
        Console.Write($"{highlight}");
        Console.ResetColor();
        Console.Write($"{after}");
    }

    private static void SetHighlightColors(ConsoleColor background = ConsoleColor.Blue, ConsoleColor text = ConsoleColor.White)
    {
        Console.BackgroundColor = background;
        Console.ForegroundColor = text;
    }
}