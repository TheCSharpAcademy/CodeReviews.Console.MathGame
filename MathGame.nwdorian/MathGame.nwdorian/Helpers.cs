using MathGame.nwdorian.Models;

namespace MathGame.nwdorian;

internal class Helpers
{
    internal static int UpperLimit { get; set; } = 9;
    internal static int UpperDivisonLimit { get; set; } = 99;

    internal static List<Game> games = new List<Game>();
    internal static string GetName()
    {
        Console.Write("Type your name: ");
        string? name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty");
            name = Console.ReadLine();
        }
        return name;
    }

    internal static int[] GetDivisionNumbers()
    {
        Random random = new Random();
        int firstNumber = random.Next(1, UpperDivisonLimit);
        int secondNumber = random.Next(1, UpperDivisonLimit);

        int[] result = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, UpperDivisonLimit);
            secondNumber = random.Next(1, UpperDivisonLimit);
        }

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }

    internal static void AddToHistory(int score, GameType gameType, GameDifficulty difficulty)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = score,
            Type = gameType,
            Difficulty = difficulty
        });
    }

    internal static void PrintGames()
    {
        Console.Clear();
        Console.WriteLine("Game history: ");
        Console.WriteLine("----------------------------");
        foreach (Game game in games)
        {
            Console.WriteLine($"{game.Date} - Type: {game.Difficulty} {game.Type}: {game.Score} pts");
        }
        Console.WriteLine("----------------------------");
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }

    internal static string? ValidateResult(string? result)
    {
        while (string.IsNullOrEmpty(result) || !int.TryParse(result, out _))
        {
            Console.WriteLine("Your answer must be an integer!");
            result = Console.ReadLine();
        }
        return result;
    }

    internal static void SelectDifficulty()
    {
        Console.Clear();
        Console.WriteLine("Select game difficulty from the options below: ");
        Console.WriteLine("E - Easy");
        Console.WriteLine("N - Normal");
        Console.WriteLine("H - Hard");
        string? userInput = Console.ReadLine();
        string menuSelection = "";
        if (userInput != null)
        {
            menuSelection = userInput.ToUpper().Trim();
        }
        switch (menuSelection)
        {
            case "E":
                UpperLimit = 9;
                UpperDivisonLimit = 99;
                Console.WriteLine("Easy difficulty selected. Press any key to return to the main menu");
                Console.ReadKey();
                break;
            case "N":
                UpperLimit = 99;
                UpperDivisonLimit = 999;
                Console.WriteLine("Normal difficulty selected. Press any key to return to the main menu");
                Console.ReadKey();
                break;
            case "H":
                UpperLimit = 999;
                UpperDivisonLimit = 9999;
                Console.WriteLine("Hard difficulty selected. Press any key to return to the main menu");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Invalid input!");
                break;
        }
    }
    internal static GameDifficulty GetGameDifficulty()
    {
        GameDifficulty difficulty = GameDifficulty.Easy;
        if (UpperLimit == 99)
        {
            difficulty = GameDifficulty.Normal;
        }
        else if (UpperLimit == 999)
        {
            difficulty = GameDifficulty.Hard;
        }
        return difficulty;
    }

    internal static GameDifficulty GetDivisionGameDifficulty()
    {
        GameDifficulty difficulty = GameDifficulty.Easy;
        if (UpperLimit == 999)
        {
            difficulty = GameDifficulty.Normal;
        }
        else if (UpperLimit == 9999)
        {
            difficulty = GameDifficulty.Hard;
        }
        return difficulty;
    }
}

