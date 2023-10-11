using Spectre.Console;

namespace MathGame.Gotcha7770.Elements;

public record MenuItem<T>(T Value, string Title) where T : notnull;

public static class Menu
{
    public static Menu<T> From<T>(params MenuItem<T>[] items) => new Menu<T>(items);
}

public class Menu<T> where T : notnull
{
    public IDictionary<T, string> Items { get; }

    public Menu(params MenuItem<T>[] items)
    {
        Items = items.ToDictionary(x => x.Value, x => x.Title);
    }

    private string Converter(T trigger) => Items[trigger];

    public T Show(IAnsiConsole console)
    {
        console.Clear();
        console.Write(new FigletText("Math Game project for")
            .Centered()
            .Color(Color.Green));
        console.Write(new FigletText("The C# Academy")
            .Centered()
            .Color(Color.Purple));
        console.WriteLine();

        return console.Prompt(
            new SelectionPrompt<T> { Converter = Converter }
                .Title("What`s next?")
                .AddChoices(Items.Keys));
    }
}