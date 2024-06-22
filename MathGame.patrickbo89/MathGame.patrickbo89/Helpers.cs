namespace MathGame.patrickbo89;

internal class Helpers
{
    internal static List<Game> _games = new();

    internal static void AddToHistory(GameType gameType, Difficulty difficulty, int score, int numberOfQuestions, string elapsedSeconds)
    {
        _games.Add(new Game()
        {
            Date = DateTime.Now,
            Type = gameType,
            Difficulty = difficulty,
            Score = score,
            NumberOfQuestions = numberOfQuestions,
            ElapsedSeconds = elapsedSeconds
        });
    }

    internal static void DisplayHistory()
    {
        Console.Clear();

        DrawLine();
        foreach (Game game in _games)
        {
            string tabstop = "\t";

            if (game.Type == GameType.Addition || game.Type == GameType.Division || game.Type == GameType.Random)
                tabstop = "\t\t";

            Console.WriteLine($"{game.Date} - {game.Type} ({game.Difficulty}){tabstop} - Score: {game.Score}/{game.NumberOfQuestions}\t - Time: {game.ElapsedSeconds}s");
        }
        DrawLine();

        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadLine();
    }

    internal static Difficulty GetDifficulty(GameType gameType)
    {
        while (true)
        {
            Console.WriteLine($@"On what difficulty will you play the {gameType} game?

1 - Easy
2 - Medium
3 - Hard");

            Console.Write("\nPlease enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return Difficulty.Easy;
                case "2":
                    return Difficulty.Medium;
                case "3":
                    return Difficulty.Hard;
                default:
                    Console.WriteLine("\nInvalid choice. Try again.");
                    break;
            }
        }
    }

    internal static string GetName()
    {
        Console.Write("Please enter your name: ");

        var name = Console.ReadLine();

        while (string.IsNullOrEmpty(name))
        {
            Console.Write("Name must not be empty. Please try again: ");
            name = Console.ReadLine();
        }

        return name;
    }

    internal static int GetNumberOfQuestions(GameType gameType)
    {
        int numberOfQuestions;

        Console.Write($"How many questions of {gameType} will you play? ");
        var input = Console.ReadLine();

        while (!int.TryParse(input, out numberOfQuestions))
        {
            Console.Write("\nInvalid input. Please enter a whole number: ");
            input = Console.ReadLine();
        }

        return numberOfQuestions;
    }

    internal static string ValidateResultInput(string? result, int firstNumber, int secondNumber, char operatorSymbol)
    {
        while (string.IsNullOrEmpty(result) || !int.TryParse(result, out _))
        {
            Console.WriteLine("\nYour answer must be a whole number. Try again.");
            Console.Write($"{firstNumber} {operatorSymbol} {secondNumber} = ");
            result = Console.ReadLine();
        }

        return result;
    }

    internal static void DrawLine() => Console.WriteLine("-------------------------------------------------------------------------------");

    internal static int[] GetAdditionNumbers(Difficulty difficulty)
    {
        var random = new Random();

        int firstNumber;
        int secondNumber;

        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);

        switch (difficulty)
        {
            case Difficulty.Easy:
                firstNumber *= 1;
                secondNumber *= 1;
                break;
            case Difficulty.Medium:
                firstNumber *= random.Next(2, 9);
                secondNumber *= random.Next(2, 9);
                break;
            case Difficulty.Hard:
                firstNumber *= random.Next(-5, 15);
                secondNumber *= random.Next(-5, 15);
                break;
        }

        int[] result = new int[2];

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }

    internal static int[] GetSubtractionNumbers(Difficulty difficulty)
    {
        // Uses the same logic for generating numbers as the addition game and can therefore call its method
        return GetAdditionNumbers(difficulty);
    }

    internal static int[] GetMultiplicationNumbers(Difficulty difficulty)
    {
        var random = new Random();

        int firstNumber;
        int secondNumber;

        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);

        switch (difficulty)
        {
            case Difficulty.Easy:
                firstNumber *= 1;
                secondNumber *= 1;
                break;
            case Difficulty.Medium:
                firstNumber *= 1;
                secondNumber *= 5;
                break;
            case Difficulty.Hard:
                firstNumber *= random.Next(-5, 15);
                secondNumber *= random.Next(-5, 15);
                break;
        }

        int[] result = new int[2];

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }

    internal static int[] GetDivisionNumbers(Difficulty difficulty)
    {
        var random = new Random();

        int firstNumber = 0;
        int secondNumber = 0;

        switch (difficulty)
        {
            case Difficulty.Easy:
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, 99);
                    secondNumber = random.Next(1, 99);
                }
                break;
            case Difficulty.Medium:
                firstNumber = random.Next(1, 199);
                secondNumber = random.Next(1, 99);

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, 199);
                    secondNumber = random.Next(1, 399);
                }
                break;
            case Difficulty.Hard:
                firstNumber = random.Next(1, 999);
                secondNumber = random.Next(1, 399);

                while (firstNumber % secondNumber != 0)
                {
                    firstNumber = random.Next(1, 999);
                    secondNumber = random.Next(1, 399);
                }
                break;
        }

        int[] result = new int[2];

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }

    internal static int CalculateResult(char operatorSymbol, int firstNumber, int secondNumber)
    {
        return operatorSymbol switch
        {
            '+' => firstNumber + secondNumber,
            '-' => firstNumber - secondNumber,
            '*' => firstNumber * secondNumber,
            '/' => firstNumber / secondNumber,
            _ => throw new ArgumentException("ArgumentException: Unknown operator symbol", nameof(operatorSymbol))
        };
    }
}