using Calculator.Gautatyr.Models;

namespace Calculator.Gautatyr;

internal class Helpers
{
    internal static List<Game> games = new();

    internal static void GetGames()
    {
        var gamesToPrint = games.OrderBy(x => x.Date).OrderByDescending(x => x.Score);

        Console.Clear();
        Console.WriteLine("Games history:");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
        foreach (var game in gamesToPrint)
        {
            Console.WriteLine($"{game.Date} - {game.GameType}: {game.Score}pts");
        }
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Press any key to go back to the menu");
        Console.ReadLine();
    }

    internal static int[] GetDivisionNumbers(GameDifficulty difficulty)
    {
        var random = new Random();

        var result = new int[2];

        int numberSize = 99;

        switch (difficulty)
        {
            case GameDifficulty.Easy:
                numberSize = 99;
                break;
            case GameDifficulty.Medium:
                numberSize = 999;
                break;
            case GameDifficulty.Hard:
                numberSize = 9999;
                break;
        }

        result[0] = random.Next(1, numberSize);
        result[1] = random.Next(1, numberSize);

        while (result[0] % result[1] != 0)
        {
            result[0] = random.Next(1, numberSize);
            result[1] = random.Next(1, numberSize);
        }
        return result;
    }

    internal static void AddToHistory(int gameScore, GameType gameType)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            GameType = gameType
        });
    }

    internal static string? ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !int.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again.");
            result = Console.ReadLine();
        }
        return result;
    }

    internal static string GetName()
    {
        Console.WriteLine("Please type your name");
        string name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty");
            name = Console.ReadLine();
        }

        Console.Clear();
        return name;
    }

    internal static GameDifficulty ChooseDifficulty()
    {
        bool input = false;
        GameDifficulty difficulty = new GameDifficulty();
        do
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($@"Choose a difficulty:
                            E - Easy
                            M - Medium
                            H - Hard");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            var gameDifficulty = Console.ReadLine().ToLower().Trim();

            switch (gameDifficulty)
            {
                case "e":
                    difficulty = Models.GameDifficulty.Easy;
                    input = true;
                    break;
                case "m":
                    difficulty = Models.GameDifficulty.Medium;
                    input = true;
                    break;
                case "h":
                    difficulty = Models.GameDifficulty.Hard;
                    input = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input, press any key to go back in the menu.");
                    Console.ReadLine();
                    break;
            }
        } while (input == false);
        return difficulty;
    }
}
