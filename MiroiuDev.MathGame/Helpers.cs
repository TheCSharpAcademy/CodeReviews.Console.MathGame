namespace MiroiuDev.MathGame;

internal class Helpers
{
    internal static readonly int DIFFICULTY_MULTIPLIER = 10;

    private static readonly  List<Game> _games = new() {
            new Game { Date = DateTime.Now.AddDays(1), Type= GameType.Addition, Score = 5 },
            new Game { Date = DateTime.Now.AddDays(1), Type= GameType.Random, Score = 10 },
            new Game { Date = DateTime.Now.AddDays(4), Type= GameType.Multiplication, Score = 2 },
            new Game { Date = DateTime.Now.AddDays(2), Type= GameType.Substraction, Score = 2 },
            new Game { Date = DateTime.Now.AddDays(3), Type= GameType.Addition, Score = 3 },
        };

    internal static (int, int) GetTwoRandomNumbers(int lowerLimit, int upperLimit)
    {
        var random = new Random(DateTime.Now.Millisecond);


        int firstNumber = random.Next(lowerLimit, upperLimit);
        int secondNumber = random.Next(lowerLimit, upperLimit);

        return (firstNumber, secondNumber);
    }

    internal static (int, int) GetDivisionNumbers(int dificulty)
    {
        (int, int) numbers = GetTwoRandomNumbers(1, dificulty * DIFFICULTY_MULTIPLIER);

        while (numbers.Item1 % numbers.Item2 != 0)
        {
            numbers = GetTwoRandomNumbers(1, dificulty * DIFFICULTY_MULTIPLIER);
        }

        return numbers;
    }

    internal static void AddToHistory(Game game)
    {
        _games.Add(game);
    }

    internal static void PrintGames()
    {

        var gamesToPrint = _games.OrderByDescending(x => x.Score);

        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("----------------------------------");

        foreach (var game in gamesToPrint)
        {
            Console.WriteLine($"{game.Date} - {game.Type}: Score = {game.Score}");
        }

        Console.WriteLine("----------------------------------\n");
        Console.WriteLine("Press any key to go back to the main menu");
        Console.ReadLine();
    }

    internal static string ValidateResult()
    {
        var result = Console.ReadLine();

        while (string.IsNullOrEmpty(result) || !int.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try Again");
            result = Console.ReadLine();
        }

        return result;
    }
}
