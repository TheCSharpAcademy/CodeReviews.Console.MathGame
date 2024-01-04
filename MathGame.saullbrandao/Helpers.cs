namespace MathGame.saullbrandao;

internal class Helpers
{
    internal static List<Game> games = [];

    internal static void AddToGames(GameType type, int gameScore, GameDifficulty difficulty, TimeSpan time, int totalQuestions)
    {
        games.Add(new Game { Date = DateTime.Now, Score = gameScore, Type = type, Difficulty = difficulty, Time = time, TotalQuestions = totalQuestions });
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
            Console.WriteLine($"{game.Date} - {game.Type}: Total Questions = {game.TotalQuestions}, Score = {game.Score}, Difficulty = {game.Difficulty}, Time = {game.Time.Seconds} seconds");
        }
        Console.WriteLine("Press any key to return to menu");
        Console.ReadLine();
    }

    internal static int[] GetValidDivisionNumbers(GameDifficulty difficulty)
    {
        var random = new Random();

        int firstNumber = random.Next(1, (int)difficulty);
        int secondNumber = random.Next(1, (int)difficulty);

        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(1, (int)difficulty);
            secondNumber = random.Next(1, (int)difficulty);
        }

        return [firstNumber, secondNumber];
    }

    internal static int GetValidAnswer()
    {
        int validAnswer;
        var answer = Console.ReadLine();

        while (string.IsNullOrEmpty(answer) || !int.TryParse(answer, out validAnswer))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again.");
            answer = Console.ReadLine();
        }

        return validAnswer;
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
