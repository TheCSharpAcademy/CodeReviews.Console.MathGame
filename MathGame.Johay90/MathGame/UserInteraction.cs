using System.Linq;

public class UserInteraction
{
    public static Operation OperationsMenu()
    {
        do
        {
            Console.WriteLine("What would you like to do:");
            Console.WriteLine("1. Add (+)");
            Console.WriteLine("2. Subtract (-)");
            Console.WriteLine("3. Multiply (*)");
            Console.WriteLine("4. Divide (/)");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int result) && result is >= 1 and <= 4)
            {
                switch (result)
                {
                    case 1: return Operation.Add;
                    case 2: return Operation.Subtract;
                    case 3: return Operation.Multiply;
                    case 4: return Operation.Divide;
                }
            }

            Console.WriteLine("Invalid input. Please any key to continue and try again.");
            Console.ReadKey();
            Console.WriteLine();

        } while (true);
    }

    public void GameHistory(List<Game> games)
    {
        for (int i = 0; i < games.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {games[i]}");
        }

        Console.WriteLine("Pick a number of a game above to see the history, or type anything else to move on.");
        var input = Console.ReadLine();

        if (!int.TryParse(input, out int result)) return;

        result -= 1;

        if (games.ElementAtOrDefault(result) == null) return;

        foreach (var item in games[result].Games)
        {
            Console.WriteLine(item);
        }
    }
}