
namespace MathGame;

internal class Helper
{
    private List<Game> _games = new List<Game>();

    // Difficulty level of the game
    public int lvl = 1;

    // Question amount that are being asked
    public int ask = 5;

    // Create a class that returns 2 random numbers in an array
    internal int[] GetTwoNumbers()
    {
        Random random = new Random();
        int first = random.Next(1, 10 * lvl);
        int second = random.Next(1, 10 * lvl);

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
        int first = random.Next(2, 101 * lvl);
        int second = random.Next(2, 101 * lvl);

        while (first % second != 0)
        {
            first = random.Next(2, 101 * lvl);
            second = random.Next(2, 101 * lvl);
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
        lvl++;
        if (lvl > 3)
        {
            lvl = 1;
        }
    }

    internal void QuestionCount()
    {
        Console.Clear();
        Console.WriteLine($"{ask} questions are beeing asked now. 1 minimum, 10 maximum");
        Console.WriteLine("How many questions to ask during a game:");

        int input = VerifyResultsInput();

        if (input >= 1 && input <= 10)
        {
            ask = input;
            Console.WriteLine($"Successfuly changed question amount to {ask}");
            Console.ReadLine();
        } else
        {
            Console.WriteLine($"{input} is invalid. Minimum question amount is 1 and Maximum is 10");
            Console.ReadLine();
        }


    }
}
