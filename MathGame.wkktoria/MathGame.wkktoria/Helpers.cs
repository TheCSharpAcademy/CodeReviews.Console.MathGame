using MathGame.wkktoria.Models;

namespace MathGame.wkktoria;

internal static class Helpers
{
    private static readonly List<Game> PreviousGames = new();

    internal static string GetName()
    {
        Console.Write("Please type your name: ");
        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name cannot be empty.");
            name = Console.ReadLine();
        }

        return name;
    }

    internal static void PrintPreviousGames()
    {
        var gamesToPrint = PreviousGames.OrderByDescending(game => game.Score);

        Console.Clear();
        Console.WriteLine("Games history");
        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
        foreach (var game in gamesToPrint)
            Console.WriteLine($"{game.Date} - {game.Type}: {game.Score} points; {game.Time} seconds");
        Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadLine();
    }

    internal static void AddToHistory(int gameScore, GameType gameType, double time)
    {
        PreviousGames.Add(new Game { Date = DateTime.Now, Score = gameScore, Type = gameType, Time = time });
    }

    internal static int[] GetNumbers(DifficultyLevel difficultyLevel)
    {
        var random = new Random();

        var numbers = new int[2];

        int firstNumber;
        int secondNumber;

        switch (difficultyLevel)
        {
            case DifficultyLevel.Easy:
                firstNumber = random.Next(1, 10);
                secondNumber = random.Next(1, 10);
                break;
            case DifficultyLevel.Medium:
                firstNumber = random.Next(10, 100);
                secondNumber = random.Next(10, 100);
                break;
            case DifficultyLevel.Hard:
                firstNumber = random.Next(100, 1000);
                secondNumber = random.Next(100, 1000);
                break;
            default:
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
                break;
        }

        numbers[0] = firstNumber;
        numbers[1] = secondNumber;

        return numbers;
    }


    internal static int[] GetDivisionNumbers(DifficultyLevel difficultyLevel)
    {
        var divisionNumbers = GetNumbers(difficultyLevel);

        while (divisionNumbers[0] % divisionNumbers[1] != 0 || divisionNumbers[0] == divisionNumbers[1])
            divisionNumbers = GetNumbers(difficultyLevel);

        return divisionNumbers;
    }

    private static string ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !int.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again.");
            Console.Write("> ");
            result = Console.ReadLine();
        }

        return result;
    }

    internal static int GetResult()
    {
        Console.Write("> ");
        var result = Console.ReadLine();
        result = ValidateResult(result);

        return int.Parse(result);
    }

    private static string ValidateDifficultyLevel(string difficultyLevel)
    {
        var isValid = false;

        while (!isValid)
            switch (difficultyLevel.Trim().ToLower())
            {
                case "e":
                case "m":
                case "h":
                    isValid = true;
                    break;
                default:
                    Console.WriteLine("Invalid difficulty level. Try again.");
                    Console.Write("> ");
                    difficultyLevel = Console.ReadLine();
                    break;
            }

        return difficultyLevel;
    }

    internal static DifficultyLevel ChooseDifficulty()
    {
        Console.WriteLine("Choose difficulty from options below:");
        foreach (var difficultyLevel in Enum.GetNames(typeof(DifficultyLevel)))
            Console.WriteLine($"{difficultyLevel[0]} - {difficultyLevel}");

        Console.Write("> ");
        var difficulty = Console.ReadLine();
        difficulty = ValidateDifficultyLevel(difficulty);

        return difficulty.Trim().ToLower() switch
        {
            "e" => DifficultyLevel.Easy,
            "m" => DifficultyLevel.Medium,
            "h" => DifficultyLevel.Hard,
            _ => DifficultyLevel.Easy
        };
    }
}