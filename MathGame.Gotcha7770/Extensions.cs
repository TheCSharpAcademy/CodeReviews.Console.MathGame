using MathGame.Gotcha7770.Elements;
using Spectre.Console;

namespace MathGame.Gotcha7770;

internal static class Extensions
{
    public static Rows ToRows<T>(this IEnumerable<T> source, Func<T, string> convertion = default)
    {
        convertion ??= x => x.ToString();
        return new Rows(source.Select(x => new Text(convertion(x))));
    }

    public static T ShowMenu<T>(this IAnsiConsole console, Menu<T> menu)
    {
        return menu.Show(console);
    }
    
    public static void ShowHistory(this IAnsiConsole console, HistoryView historyView)
    {
        historyView.Show(console);
    }
}