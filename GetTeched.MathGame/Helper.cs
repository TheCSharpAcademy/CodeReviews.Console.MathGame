namespace CSharp_Study_ConsoleMathGame;

internal class Helper
{
    internal static List<GameTables> gameTables = new List<GameTables>();
    internal static string GetName()
    {
        Console.Clear();
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can not be empty.");
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
        }
        return name.Trim();
    }

    internal static void AddGames(int gameScore, GameType gameType, string gameTime, string gameName)
    {
        gameTables.Add(new GameTables
        {
            Date = DateTime.Now,
            Score = gameScore,
            Type = gameType,
            Time = gameTime,
            Name = gameName
        });
    }

    internal static void ShowHistory()
    {
        Console.Clear();
        Console.WriteLine("Game History");
        Console.WriteLine("Date | Player | Game | Score | Time\n");
        foreach (var game in gameTables)
        {
            Console.WriteLine($"{game.Date} | {game.Name} | {game.Type} Game | {game.Score} pts | {game.Time}");
        }
        Console.ReadLine();
    }

    internal static string? TextInputValidation(string result)
    {
        while (string.IsNullOrEmpty(result) || Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your input should be text only and should not be blank. Please try again.");
            result = Console.ReadLine();
        }
        return result.ToLower().Trim();
    }

    internal static string? NumberInputValidation(string result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your input should be a number value only. Please try again.");
            result = Console.ReadLine();
        }
        return result;
    }

    internal static int[] DivisionPossible(string difficulty)
    {
        //Easy mode too easy with division
        if (difficulty == "Easy")
            difficulty = "Normal";

        int firstNumber = RandomNumber(difficulty);
        int secondNumber = RandomNumber(difficulty);
        int[] result = new int[2];

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = RandomNumber(difficulty);
            secondNumber = RandomNumber(difficulty);
        }
        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }

    internal static int RandomNumber(string difficulty)
    {
        Random random = new Random();
        int value = 0;
        switch (difficulty)
        {
            case "Easy":
                value = random.Next(1, 10); ;
                break;
            case "Normal":
                value = random.Next(1, 50); ;
                break;
            case "Hard":
                value = random.Next(50, 200); ;
                break;
            case "Impossible":
                value = random.Next(1000, 999999); ;
                break;
        }

        return value;
    }


}
