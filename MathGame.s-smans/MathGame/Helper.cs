namespace MathGame;

internal class Helper
{
    private List<Game> _games = new List<Game>();
    public int DifficultyLevel = 1;
    public int QuestionAmount = 5;

    internal int[] GetTwoNumbers()
    {
        Random random = new Random();
        int first = random.Next(1, 10 * DifficultyLevel);
        int second = random.Next(1, 10 * DifficultyLevel);

        return new int[] { first, second };
    }

    internal int VerifyResultsInput()
    {
        string input = Console.ReadLine();

        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out int result))
        {
            Console.WriteLine(input.GetType().Name);
            Console.WriteLine("Input has to be a number");
            input = Console.ReadLine();
        }

        return int.Parse(input);
    }

    internal int[] GetDivisionNumbers()
    {
        Random random = new Random();
        int first = random.Next(2, 101 * DifficultyLevel);
        int second = random.Next(2, 101 * DifficultyLevel);

        while (first % second != 0)
        {
            first = random.Next(2, 101 * DifficultyLevel);
            second = random.Next(2, 101 * DifficultyLevel);
        }

        return new int[] { first, second };
    }

    internal void History()
    {
        foreach (Game game in _games)
        {
            Console.WriteLine($"{game.Date} - {game.Type}({game.Level}): {game.Score}pts in {game.Time}. {game.Questions} questions");
        }

        Console.ReadLine();
    }

    internal void AddHistory(GameType type, int score, Difficulty level, string time, int questions)
    {
        _games.Add(new Game
        {
            Date = DateTime.Now,
            Score = score,
            Type = type,
            Level = level,
            Time = time,
            Questions = questions
        });
    }

    internal void ChangeDifficulty()
    {
        DifficultyLevel++;
        if (DifficultyLevel > 3)
        {
            DifficultyLevel = 1;
        }
    }

    internal void QuestionCount()
    {
        Console.Clear();
        Console.WriteLine($"{QuestionAmount} questions are beeing asked now. 1 minimum, 10 maximum");
        Console.WriteLine("How many questions to ask during a game:");

        int input = VerifyResultsInput();

        if (input >= 1 && input <= 10)
        {
            QuestionAmount = input;
            Console.WriteLine($"Successfuly changed question amount to {QuestionAmount}");
            Console.ReadLine();
        } else
        {
            Console.WriteLine($"{input} is invalid. Minimum question amount is 1 and Maximum is 10");
            Console.ReadLine();
        }
    }
}