using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J.Games;

public class RandomOperation : Game
{
    public RandomOperation(ResultKeeper resultKeeper) : base(resultKeeper)
    {
        Settings.GameType = GameType.Random;
    }

    public override void Start()
    {
        while (!Quit)
        {
            PrintMenu(StylizedTitles.Random,
                "Each question will be a random operation between two numbers.");

            ReadAndRouteUserSelection();
        }
    }

    protected override GameResult GameLogic(int nrOfQuestions, bool timed)
    {
        var score = 0;
        var generator = new Random();
        var lower = Settings.NumberLimits.Lower;
        var upper = Settings.NumberLimits.Upper;

        var start = DateTime.Now;
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
        var stop = DateTime.Now;

        return timed ? new GameResult(score, TimeNeeded: stop - start) : new GameResult(score);
    }

    private static char RandomizeOperations()
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

    private static NumberGeneratorCondition LoadNumberGeneratorConditionDelegate(char operation)
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

    private static OperatorCondition LoadOperatorConditionDelegate(char operation)
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

    private delegate bool NumberGeneratorCondition(int a, int b);
    private static bool NoConditionNecessary(int a, int b) => false;
    private static bool SubtractionLessThanZero(int a, int b) => a - b < 0;
    private static bool DivisionHasRemainder(int a, int b) => a % b != 0;

    private delegate bool OperatorCondition(int a, int b, int c);
    private static bool ValidAddition(int a, int b, int c) => a + b == c;
    private static bool ValidSubtraction(int a, int b, int c) => a - b == c;
    private static bool ValidMultiplication(int a, int b, int c) => a * b == c;
    private static bool ValidDivision(int a, int b, int c) => a / b == c;
}