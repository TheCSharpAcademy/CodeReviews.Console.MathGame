using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J.Games;

internal class RandomOperation(List<GameResult> resultKeeper) : Game(resultKeeper)
{
    protected override void Loop()
    {
        while (!Quit)
        {
            PrintMenu(
                StylizedTitles.Random,
                "Each question will be a random operation between two numbers.",
                Settings.Difficulty,
                Settings.Mode);

            if (Settings.Mode is Mode.Custom)
                Settings.NumberOfQuestions = 10;

            ReadAndRouteUserSelection();
        }
    }

    protected override void StandardGame()
    {
        GameCountDown();

        var result = GameLogic(Settings.NumberOfQuestions);
        result.SaveGameSettings(Settings);

        GameOverPresentation(result);
    }

    protected override void TimedGame()
    {
        GameCountDown();

        var start = DateTime.Now;
        var result = GameLogic(Settings.NumberOfQuestions);
        var stop = DateTime.Now;
        result.SaveGameSettings(Settings);

        GameOverPresentation(result);
    }

    protected override void CustomGame()
    {
        SetNumberOfQuestions();

        GameCountDown();

        var result = GameLogic(Settings.NumberOfQuestions);
        result.SaveGameSettings(Settings);

        GameOverPresentation(result);
    }

    protected override GameResult GameLogic(int nrOfQuestions)
    {
        var score = 0;
        var generator = new Random();
        var lower = Settings.NumberLimits.Lower;
        var upper = Settings.NumberLimits.Upper;

        for (int i = 0; i < nrOfQuestions; i++)
        {
            var operation = RandomizeOperations();
            var numberGeneratorCondition = LoadNumberGeneratorConditionDelegate(operation);
            var operatorCondition = LoadOperatorConditionDelegate(operation);
            int a, b;

            do
            {
                a = generator.Next(lower, upper);
                b = generator.Next(lower, upper);
            } while (numberGeneratorCondition(a, b));

            Console.Write($"\t{a} {operation} {b} = ");

            var c = ConsoleHelperMethods.ReadUserInteger();

            if (operatorCondition(a, b, c))
                score++;
        }

        return new GameResult(score);
    }

    private char RandomizeOperations()
    {
        return new Random().Next(1, 5) switch
        {
            1 => '+',
            2 => '-',
            3 => '*',
            4 => '/',
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private OperatorCondition LoadOperatorConditionDelegate(char operation)
    {
        OperatorCondition? operatorCondition = null;

        return operatorCondition += operation switch
        {
            '+' => ValidAddition,
            '-' => ValidSubtraction,
            '*' => ValidMultiplication,
            '/' => ValidDivision,
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }

    private NumberGeneratorCondition LoadNumberGeneratorConditionDelegate(char operation)
    {
        NumberGeneratorCondition? numberGeneratorCondition = null;

        return numberGeneratorCondition += operation switch
        {
            '+' => NoConditionNecessary,
            '-' => SubtractionLessThanZero,
            '*' => NoConditionNecessary,
            '/' => DivisionHasRemainder,
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }

    private delegate bool OperatorCondition(int a, int b, int c);
    private static bool ValidAddition(int a, int b, int c) => a + b == c;
    private static bool ValidSubtraction(int a, int b, int c) => a - b == c;
    private static bool ValidMultiplication(int a, int b, int c) => a * b == c;
    private static bool ValidDivision(int a, int b, int c) => a / b == c;

    private delegate bool NumberGeneratorCondition(int a, int b);
    private static bool NoConditionNecessary(int a, int b) => false;
    private static bool SubtractionLessThanZero(int a, int b) => a - b < 0;
    private static bool DivisionHasRemainder(int a, int b) => a % b != 0;
}