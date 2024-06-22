namespace MathGame.patrickbo89;

internal class GameEngine
{
    internal void StartGame(GameType gameType, int numberOfQuestions, Difficulty difficulty)
    {
        var startTime = DateTime.UtcNow;
        int score = 0;

        char operatorSymbol = ' ';

        if (gameType != GameType.Random)
        {
            operatorSymbol = GetOperatorSymbol(gameType);
        }

        RunGameLoop(gameType, operatorSymbol, numberOfQuestions, difficulty, ref score);

        var endTime = DateTime.UtcNow;
        var elapsedSeconds = ((endTime - startTime).TotalSeconds).ToString(string.Format(".00"));

        ShowGameResult(score, numberOfQuestions, elapsedSeconds);

        Helpers.AddToHistory(gameType, difficulty, score, numberOfQuestions, elapsedSeconds);
    }

    private void ShowGameResult(int score, int numberOfQuestions, string elapsedSeconds)
    {
        Console.WriteLine($"The game is over. You had {score} of {numberOfQuestions} correct answers. You took {elapsedSeconds} seconds. Press any key to return to the main menu.");
        Console.ReadLine();
    }

    internal void RunGameLoop(GameType gameType, char operatorSymbol, int numberOfQuestions, Difficulty difficulty, ref int score)
    {
        var random = new Random();

        int[] numbers;

        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Clear();
            Console.WriteLine($"{gameType} Game ({difficulty}) - Round {i + 1} of {numberOfQuestions}");

            if (gameType == GameType.Random)
            {
                operatorSymbol = GetRandomOperatorSymbol(random);
            }

            numbers = GenerateNumbers(operatorSymbol, difficulty);

            Console.Write($"{numbers[0]} {operatorSymbol} {numbers[1]} = ");

            var resultInput = Console.ReadLine();
            resultInput = Helpers.ValidateResultInput(resultInput, numbers[0], numbers[1], operatorSymbol);

            int correctResult = Helpers.CalculateResult(operatorSymbol, numbers[0], numbers[1]);

            if (int.Parse(resultInput) == correctResult)
            {
                Console.WriteLine("Correct! Press any key for the next question.");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Incorrect! Press any key for the next question.");
                Console.ReadLine();
            }
        }
    }

    private char GetOperatorSymbol(GameType gameType)
    {
        return gameType switch
        {
            GameType.Addition       => '+',
            GameType.Subtraction    => '-',
            GameType.Multiplication => '*',
            GameType.Division       => '/',
            _                       => '+' // fallback value
        };
    }

    private char GetRandomOperatorSymbol(Random random)
    {
        int selector = random.Next(0, 4);

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
        int[] numbers = new int[2];

        switch (operatorSymbol)
        {
            case '+':
                numbers = Helpers.GetAdditionNumbers(difficulty);
                break;
            case '-':
                numbers = Helpers.GetSubtractionNumbers(difficulty);
                break;
            case '*':
                numbers = Helpers.GetMultiplicationNumbers(difficulty);
                break;
            case '/':
                numbers = Helpers.GetDivisionNumbers(difficulty);
                break;
        }

        return numbers;
    }
}