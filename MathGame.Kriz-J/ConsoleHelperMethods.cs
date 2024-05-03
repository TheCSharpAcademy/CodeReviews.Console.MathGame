namespace MathGame.Kriz_J;

public class ConsoleHelperMethods
{
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