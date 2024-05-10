namespace MathGame.Kriz_J;

public class ConsoleHelperMethods
{
    public static void PrintMessage(string message)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.Write($"\t{message}");
        _ = ReadUserSelection();
    }

    public static int ReadUserInteger()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input)) { }

        return input;
    }

    public static char ReadUserSelection() => char.ToUpper(Console.ReadKey().KeyChar);

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