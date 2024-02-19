using MathGame.Models;

namespace MathGame;

internal class Helpers
{
    static List<Game> games = new();
    Random random = new Random();
    //Asks the player for the number of questions
    //they would like to answer/play and sets the variable
    // to the result
    internal static int QuestionsCount()
    {
        string? result;
        Console.Clear();
        Console.WriteLine("MATH GAME");
        Console.WriteLine("----------");
        int num;
        Console.WriteLine("Enter the amount of questions you want to answer: ");
        result = Console.ReadLine();
        result = ValidateResult(result);
        num = Convert.ToInt32(result);
        return num;
    }
    // sets the numbers for the DivisionGame
    internal static int[] DivisionNumbers(string difficulty)
    {
        var random = new Random();
        int[] Numbers = new int[2];
        Numbers[0] = random.Next(1, 100);
        Numbers[1] = random.Next(1, 100);

        while (Numbers[0] % Numbers[1] != 0)
        {
            switch (difficulty)
            {
                case "1":
                    Numbers[0] = random.Next(1, 50);
                    Numbers[1] = random.Next(1, 50);
                    break;
                case "2":
                    Numbers[0] = random.Next(1, 100);
                    Numbers[1] = random.Next(1, 100);
                    break;
                case "3":
                    Numbers[0] = random.Next(1, 1000);
                    Numbers[1] = random.Next(1, 1000);
                    break;
                case "4":
                    Numbers[0] = random.Next(1, 10000);
                    Numbers[1] = random.Next(1, 10000);
                    break;
            }

        }
        return Numbers;
    }
    // Adds the games to the list of games history
    internal static void AddToHistory(GameType gamemode, int points, string difficulty)
    {
        switch (difficulty)
        {
            case "1":
                difficulty = "Easy";
                break;
            case "2":
                difficulty = "Medium";
                break;
            case "3":
                difficulty = "Hard";
                break;
            case "4":
                difficulty = "Impossible";
                break;
        }
        games.Add(new Game
        {
            Score = points,
            Mode = gamemode,
            difficulty = difficulty
        });
    }
    // Shows the history
    internal static void ShowHistory()
    {
        Console.Clear();
        Console.WriteLine("MATH GAME");
        Console.WriteLine("----------\n");
        Console.WriteLine("HISTORY");
        foreach (var game in games)
        {
            Console.WriteLine($"{game.Mode} - {game.difficulty} - {game.Score}pts");
        }
        Console.ReadLine();
    }
    // validates result
    internal static string ValidateResult(string? result)
    {
        while (string.IsNullOrEmpty(result))
        {
            Console.WriteLine("Enter a valid answer");
            result = Console.ReadLine();
        }
        return result;
    }

    internal static int[] ChangeDifficulty(int number1, int number2, string difficulty)
    {
        Random random = new Random();
        int[] Numbers = new int[2] { number1, number2 };
        switch (difficulty)
        {
            case "1":
                Numbers[0] = random.Next(1, 10);
                Numbers[1] = random.Next(1, 10);
                break;
            case "2":
                Numbers[0] = random.Next(1, 100);
                Numbers[1] = random.Next(1, 100);
                break;
            case "3":
                Numbers[0] = random.Next(1, 1000);
                Numbers[1] = random.Next(1, 1000);
                break;
            case "4":
                Numbers[0] = random.Next(1, 10000);
                Numbers[1] = random.Next(1, 10000);
                break;
        }
        return Numbers;
    }
}
