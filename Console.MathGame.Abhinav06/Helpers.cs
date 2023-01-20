using ConsoleTableExt;
using MathGame.Entities;

namespace MathGame;

static class Helpers
{
    private static readonly Dictionary<HeaderCharMapPositions, char> HeaderCharacterMap = new()
    {
        { HeaderCharMapPositions.TopLeft, '╒' },
        { HeaderCharMapPositions.TopCenter, '╤' },
        { HeaderCharMapPositions.TopRight, '╕' },
        { HeaderCharMapPositions.BottomLeft, '╞' },
        { HeaderCharMapPositions.BottomCenter, '╪' },
        { HeaderCharMapPositions.BottomRight, '╡' },
        { HeaderCharMapPositions.BorderTop, '═' },
        { HeaderCharMapPositions.BorderRight, '│' },
        { HeaderCharMapPositions.BorderBottom, '═' },
        { HeaderCharMapPositions.BorderLeft, '│' },
        { HeaderCharMapPositions.Divider, '│' },
    };

    public static void DisplayTable<T>(List<T> records) where T : class
    {
        ConsoleTableBuilder.From(records)
            .WithCharMapDefinition(CharMapDefinition.FramePipDefinition, HeaderCharacterMap)
            .ExportAndWriteLine();
    }

    public static T GetRandomEnumValue<T>()
    {
        var random = new Random();
        var enumValues = Enum.GetValues(typeof(T));
        return (T)enumValues.GetValue(random.Next(enumValues.Length))!;
    }

    public static Operation GetRandomOperation()
    {
        var operation = Operation.RandomOperation;

        while (operation == Operation.RandomOperation)
            operation = GetRandomEnumValue<Operation>();

        return operation;
    }

    public static void WriteUsingTypeWriter(string message, int delay = 30, int finalSleep = 100)
    {
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            Thread.Sleep(delay);
        }

        Console.WriteLine();
        Thread.Sleep(finalSleep);
    }
}
