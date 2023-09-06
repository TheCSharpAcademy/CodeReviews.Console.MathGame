using Spectre.Console;

namespace MathGame.Gotcha7770;

internal static class Extensions
{
    public static Rows ToRows<T>(this IEnumerable<T> source, Func<T, string> convertion = default)
    {
        convertion ??= x => x.ToString();
        return new Rows(source.Select(x => new Text(convertion(x))));
    }
}