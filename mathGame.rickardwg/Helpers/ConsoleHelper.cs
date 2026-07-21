namespace MathGame.Helpers;

internal static class ConsoleHelper
{
    internal static T Prompt<T>(string title, params T[] options)
    {
        ArgumentNullException.ThrowIfNull(options);

        if (options.Length == 0)
        {
            throw new ArgumentException(
                "At least one option must be provided.",
                nameof(options));
        }

        Console.CursorVisible = false;
        
        try
        {
            var selectedIndex = 0;
            while (true)
            {
                Console.Clear();
                WriteLine(title);
                Console.WriteLine();

                for (int i = 0; i < options.Length; i++)
                {
                    bool isSelected = selectedIndex == i;
                    string prefix = isSelected ? ">  " : "   ";
                    ConsoleColor color = isSelected ? ConsoleColor.Yellow : ConsoleColor.White;
                    WriteLine($"{prefix}{options[i]}", color);
                }

                var keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (selectedIndex > 0)
                        {
                            selectedIndex--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (selectedIndex < options.Length - 1)
                        {
                            selectedIndex++;
                        }
                        break;

                    case ConsoleKey.Enter: return options[selectedIndex];
                }
            }
        }
        finally
        {
            Console.CursorVisible = true;
        }
    }

    internal static void WriteLine(string text, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }

    internal static void Write(string text, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
    }
}
