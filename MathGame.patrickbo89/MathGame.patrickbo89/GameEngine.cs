namespace MathGame.patrickbo89;

internal class GameEngine
{
    private readonly Random _randomizer = new();

    private readonly List<Game> _history = new();
    public List<Game> History
    {
        get => _history;
    }

    internal Game SetupGame(GameType gameType)
    {
        int numberOfQuestions = UserInterface.GetNumberOfQuestions(gameType);
        Difficulty difficulty = UserInterface.GetDifficulty(gameType);

        return new Game()
        {
            StartTime = DateTime.UtcNow,
            Type = gameType,
            Score = 0,
            NumberOfQuestions = numberOfQuestions,
            Difficulty = difficulty
        };
    }

    internal void StartGame(Game game)
    {
        char operatorSymbol = game.Type == GameType.Random ? ' ' : GetOperatorSymbol(game.Type);

        RunGameLoop(game, operatorSymbol);

        var endTime = DateTime.UtcNow;
        game.ElapsedSeconds = ((endTime - game.StartTime).TotalSeconds).ToString(string.Format(".00"));

        UserInterface.DisplayGameResult(game);
        
        _history.Add(game);
    }

    internal void RunGameLoop(Game game, char operatorSymbol)
    {
        int[] numbers;

        for (int i = 0; i < game.NumberOfQuestions; i++)
        {
            UserInterface.DisplayHeader(game, i + 1);

            operatorSymbol = game.Type == GameType.Random ? GetRandomOperatorSymbol() : operatorSymbol;

            numbers = GenerateNumbers(operatorSymbol, game.Difficulty);
            UserInterface.DisplayQuestion(numbers, operatorSymbol);

            string resultInput = UserInterface.GetResultInput(numbers, operatorSymbol);
            int correctResult = CalculateResult(operatorSymbol, numbers);
            bool isCorrectAnswer = int.Parse(resultInput) == correctResult;
            UserInterface.DisplayAnswerOutcome(isCorrectAnswer);

            game.Score += isCorrectAnswer ? 1 : 0;
        }
    }

    private char GetOperatorSymbol(GameType gameType)
    {
        return gameType switch
        {
            GameType.Addition => '+',
            GameType.Subtraction => '-',
            GameType.Multiplication => '*',
            GameType.Division => '/',
            _ => '+' // fallback value
        };
    }

    private char GetRandomOperatorSymbol()
    {
        int selector = _randomizer.Next(0, 4);

        return selector switch
        {
            0 => '+',
            1 => '-',
            2 => '*',
            3 => '/',
            _ => '+' // fallback value
        };
    }

    private int[] GenerateNumbers(char operatorSymbol, Difficulty difficulty)
    {
        int[] numbers;

        int multiplier = difficulty switch
        {
            Difficulty.Easy     => 1,
            Difficulty.Medium   => _randomizer.Next(10, 21),
            Difficulty.Hard     => _randomizer.Next(100, 1001),
            _                   => 1 // fallback value
        };

        if (operatorSymbol == '/')
            numbers = GenerateDivisionNumbers(multiplier);
        else
            numbers = GenerateNumbers(multiplier);

        return numbers;
    }

    private int[] GenerateNumbers(int multiplier)
    {
        int firstNumber = _randomizer.Next(1, 9) * multiplier;
        int secondNumber = _randomizer.Next(1, 9) * multiplier;

        return new int[] { firstNumber, secondNumber };
    }

    private int[] GenerateDivisionNumbers(int multiplier)
    {
        int firstNumber;
        int secondNumber;

        do
        {
            firstNumber = _randomizer.Next(1, 9) * multiplier;
            secondNumber = _randomizer.Next(1, 9) * multiplier;
        } while (firstNumber % secondNumber != 0);

        return new int[] { firstNumber, secondNumber };
    }

    private int CalculateResult(char operatorSymbol, int[] numbers)
    {
        return operatorSymbol switch
        {
            '+' => numbers[0] + numbers[1],
            '-' => numbers[0] - numbers[1],
            '*' => numbers[0] * numbers[1],
            '/' => numbers[0] / numbers[1],
            _ => throw new ArgumentException("ArgumentException: Unknown operator symbol", nameof(operatorSymbol))
        };
    }
}