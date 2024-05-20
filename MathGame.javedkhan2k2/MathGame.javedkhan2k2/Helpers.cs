using MathGame.javedkhan2k2.Models;

namespace MathGame.javedkhan2k2;

internal class Helpers
{
    internal static List<Game> games = new List<Game>();

    internal static int GetGamesNumber() => games.Count;

    internal static (int firstNumber, int secondNumber) GetDivisionNumbers(int difficulty)
    {
        difficulty = difficulty * 10 + 9;
        var random = new Random();
        var firstNumber = random.Next(1, difficulty);
        var secondNumber = random.Next(1, difficulty);

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, difficulty);
            secondNumber = random.Next(1, difficulty);
        }

        return (firstNumber, secondNumber);
    }

    internal static void AddToHistory(Game game) => games.Add(game);

    internal static void PrintGames()
    {
        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-10} {4}", "Time Spent (s)", "Game Type", "Difficulty", "Score", "Total Questions");

        foreach (var game in games)
        {
            double timeSpent = game.EndTime.Subtract(game.StartTime).TotalSeconds;
            Console.WriteLine("{0,-15:F3} {1,-15} {2,-15} {3,-10} {4}", timeSpent, game.Type, game.Difficulty.ToString(), game.Score, game.NumberOfQuestions);
        }
        Console.WriteLine("---------------------------------------------------------------------------------\n");
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
    }

    internal static string ValidateResult(string? result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again.");
            result = Console.ReadLine();
        }

        return result;
    }

    internal static string GetName()
    {
        Console.WriteLine("Please type your name");
        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty");
            name = Console.ReadLine();
        }

        return name;
    }

    internal static char GenerateGameType()
    {
        var random = new Random();
        switch (random.Next(1, 5))
        {
            case 1:
                return '+';
            case 2:
                return '-';
            case 3:
                return '*';
            case 4:
                return '/';
            default:
                return '.';
        }
    }

    internal static int GetResult(int firstNumber, int secondNumber, char op)
    {
        switch (op)
        {
            case '+':
                return firstNumber + secondNumber;
            case '-':
                return firstNumber - secondNumber;
            case '*':
                return firstNumber * secondNumber;
            case '/':
                return firstNumber / secondNumber;
            default:
                return 0;
        }
    }

    internal static GameType GenerateGameType(char op)
    {
        switch (op)
        {
            case '+':
                return GameType.Addition;
            case '-':
                return GameType.Division;
            case '*':
                return GameType.Multiplication;
            case '/':
                return GameType.Division;
            default:
                return GameType.Random;
        }
    }

}