namespace MathGame.saullbrandao;

internal class Helpers
{
    internal static List<Game> games = [];

    internal static void AddToGames(GameType type, int gameScore)
    {
        games.Add(new Game { Date = DateTime.Now, Score = gameScore, Type = type });
    }

    internal static void PrintGames()
    {
        Console.Clear();
        Console.WriteLine("Games");
        Console.WriteLine();

        if (games.Count == 0)
        {
            Console.WriteLine("No games played yet.");
        }

        foreach (var game in games)
        {
            Console.WriteLine($"{game.Date} - {game.Type}: Score = {game.Score}");
        }
        Console.WriteLine("Press any key to return to menu");
        Console.ReadLine();
    }

    internal static int[] GetValidDivisionNumbers()
    {
        var random = new Random();

        int firstNumber = random.Next(1, 99);
        int secondNumber = random.Next(1, 99);

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, 99);
            secondNumber = random.Next(1, 99);
        }

        return [firstNumber, secondNumber];
    }

    internal static string ValidateAnswer(string? answer)
    {
        while (string.IsNullOrEmpty(answer) || !int.TryParse(answer, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again.");
            answer = Console.ReadLine();
        }

        return answer;
    }

    internal static string GetName()
    {
        Console.WriteLine("Please type your name");
        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty. Try again.");
            name = Console.ReadLine();
        }

        return name;
    }
}
