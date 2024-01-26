using MathGame.Models;

namespace MathGame;

internal class Helpers
{
    internal static List<Game> games = new(); 
    internal static void GetGames()
    {
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("--------------------------");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}/{game.TotalQuestions}pts - {game.Difficulty}");
        }

        Console.WriteLine("--------------------------");
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
    }

    internal static int[] GetDivisionNumbers(string difficulty)
    {
        int[] result = new int[2];
        int firstNumber = SetDifficulty(difficulty);
        int secondNumber = SetDifficulty(difficulty);

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = SetDifficulty(difficulty);
            secondNumber = SetDifficulty(difficulty);
        }

        result[0] = firstNumber;
        result[1] = secondNumber;
        return result;
    }

    internal static void AddToHistory(int gameScore, GameType gameType, DifficultyLevel gameDifficulty, int times)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType,
            Difficulty = gameDifficulty,
            TotalQuestions = times,
        });
    }

    internal static string? ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
            Console.WriteLine("Your answer needs to be an integer. Try again");
            result = Console.ReadLine();
        }

        return result;
    }

    internal static string GetName()
    {
        Console.WriteLine("Please type your name:");
        string? name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name cannot be empty");
            name = Console.ReadLine();
        }

        return name;
    }

    internal static string? GetDifficulty()
    {
        string? difficulty = Console.ReadLine();

        while (string.IsNullOrEmpty(difficulty))
        {
            Console.WriteLine("The difficulty cannot be empty");
            difficulty = Console.ReadLine();
        }

        return difficulty;
    }

    internal static int SetDifficulty(string difficulty)
    {
        Random random = new Random();
        int result = 0;
        do
        {
            switch (difficulty)
            {
                case "e":
                    result = random.Next(1, 12);
                    break;
                case "r":
                    result = random.Next(50, 500);
                    break;
                case "h":
                    result = random.Next(501, 1321);
                    break;
                default:
                    Console.WriteLine("That's not a valid option.");
                    break;
            }
        } while (string.IsNullOrEmpty(difficulty) && result == 0);

        return result;
    }

    internal static DifficultyLevel GetDifficultyLevel(string difficulty)
    {
        DifficultyLevel level = DifficultyLevel.Easy;
        switch (difficulty)
        {
            case "e":
                level = DifficultyLevel.Easy;
                break;
            case "r":
                level = DifficultyLevel.Regular;
                break;
            case "h":
                level = DifficultyLevel.Hard;
                break;
        }

        return level;
    }
}
