using MathGame.Models;

namespace MathGame;

internal class Helpers
{
    internal static List<Game> games = new List<Game>();

    internal static void GetGames()
    {
        List<Game> gamesToPrint = games.OrderBy(x => x.Date).ToList();

        Console.Clear();
        Console.WriteLine("Game History");
        Console.WriteLine("-------------------------------------------");

        foreach (Game game in gamesToPrint)
        {
            Console.WriteLine($"{game.Date} - {game.Difficulty} - {game.Type} - {game.Score} out of {game.Limit}");
        }

        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Press any key to return to Menu.");
        Console.ReadLine();
    }

    internal static void AddToHistory(int score, GameType gameType, int limit, string difficulty)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = score,
            Type = gameType,
            Limit = limit,
            Difficulty = difficulty
        }) ;
    }

    internal static int[] GetDivisionNumbers(string difficulty, Random random, int[] numbers, int easyLimit, int mediumLimit, int hardLimit)
    {
        switch (difficulty)
        {
            case "Easy":
                numbers[0] = random.Next(1, easyLimit);
                numbers[1] = random.Next(2, easyLimit);

                while ((numbers[0] == numbers[1]) || (numbers[0] % numbers[1] != 0))
                {
                    numbers[0] = random.Next(1, easyLimit);
                    numbers[1] = random.Next(2, easyLimit);
                }

                break;

            case "Medium":
                numbers[0] = random.Next(1, mediumLimit);
                numbers[1] = random.Next(2, mediumLimit);

                while ((numbers[0] == numbers[1]) || (numbers[0] % numbers[1] != 0))
                {
                    numbers[0] = random.Next(1, mediumLimit);
                    numbers[1] = random.Next(2, mediumLimit);
                }

                break;

            case "Hard":
                numbers[0] = random.Next(1, hardLimit);
                numbers[1] = random.Next(2, hardLimit);

                while ((numbers[0] == numbers[1]) || (numbers[0] % numbers[1] != 0))
                {
                    numbers[0] = random.Next(1, hardLimit);
                    numbers[1] = random.Next(2, hardLimit);
                }

                break;
        }

        return numbers;
    }

    internal static string? ValidateResult(string? result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again.");
            result = Console.ReadLine();
            return ValidateResult(result);
        }

        return result;
    }

    internal static int SetLimit()
    {
        Console.Clear();
        Console.WriteLine("Type how many game to set up.");
        string noOfGames = Console.ReadLine();

        noOfGames = ValidateResult(noOfGames);

        while (int.Parse(noOfGames) <= 0)
        {
            Console.Clear();
            Console.WriteLine("Integer must be positive. Try again.");
            noOfGames = Console.ReadLine();
            noOfGames = ValidateResult(noOfGames);
        }

        int limit = int.Parse(noOfGames);

        return (limit);
    }

    internal static string SetDifficulty()
    {
        Console.Clear();
        Console.WriteLine("Type the difficulty you want.");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("E - Easy");
        Console.WriteLine("M - Medium");
        Console.WriteLine("H - Hard");
        Console.WriteLine("-------------------------------------------");
        string difficulty = Console.ReadLine();

        switch (difficulty.Trim().ToLower())
        {
            case "e":
                difficulty = "Easy";
                break;

            case "m":
                difficulty = "Medium";
                break;
            
            case "h":
                difficulty = "Hard";
                break;

            default:
                Console.WriteLine("Invalid input. Please try again.");
                Console.ReadLine();
                difficulty = SetDifficulty();
                break;
        }

        return difficulty;
    }

    internal static int[] ChooseNumbers(string difficulty, GameType type)
    {
        Random random = new Random();
        int[] numbers = new int[2];

        if (type.Equals(GameType.Addition) || type.Equals(GameType.Subtraction))
        {
            numbers = GetNumbers(difficulty, random, numbers, 10, 50, 100);
        }
        else if (type.Equals(GameType.Multiplication))
        {
            numbers = GetNumbers(difficulty, random, numbers, 5, 10, 15);
        }
        else
        {
            numbers = GetDivisionNumbers(difficulty, random, numbers, 30, 100, 300);
        }

        return numbers;
    }

    internal static int[] GetNumbers(string difficulty, Random random, int[] numbers, int easyLimit, int mediumLimit, int hardLimit)
    {
        switch (difficulty)
        {
            case "Easy":
                numbers[0] = random.Next(1, easyLimit);
                numbers[1] = random.Next(1, easyLimit);
                break;

            case "Medium":
                numbers[0] = random.Next(1, mediumLimit);
                numbers[1] = random.Next(1, mediumLimit);
                break;

            case "Hard":
                numbers[0] = random.Next(1, hardLimit);
                numbers[1] = random.Next(1, hardLimit);
                break;
        }

        return numbers;
    }
}