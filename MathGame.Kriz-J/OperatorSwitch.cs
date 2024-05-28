using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J;

public class OperatorSwitch
{
    public NumberGeneratorCondition NumberGeneratorConditionDelegate { get; set; }
    
    public OperatorCondition OperatorConditionDelegate { get; set; }

    public char Operator { get; set; }

    public OperatorSwitch(GameType gameType)
    {
        Operator = (char)gameType;

        if (gameType == GameType.Random)
        {
            Operator = (char)RandomizeOperation();
        }

        NumberGeneratorConditionDelegate = LoadNumberGeneratorConditionDelegate((GameType)Operator);
        OperatorConditionDelegate = LoadOperatorConditionDelegate((GameType)Operator);
    }

    public static GameType RandomizeOperation()
    {
        return new Random().Next(1, 5) switch
        {
            1 => GameType.Addition,
            2 => GameType.Subtraction,
            3 => GameType.Multiplication,
            4 => GameType.Division,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static NumberGeneratorCondition LoadNumberGeneratorConditionDelegate(GameType gameType)
    {
        NumberGeneratorCondition? numberGeneratorCondition = null;

        return numberGeneratorCondition += gameType switch
        {
            GameType.Addition => NoConditionNecessary,
            GameType.Subtraction => SubtractionLessThanZero,
            GameType.Multiplication => NoConditionNecessary,
            GameType.Division => DivisionHasRemainder,
            _ => throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null)
        };
    }

    public static OperatorCondition LoadOperatorConditionDelegate(GameType gameType)
    {
        OperatorCondition? operatorCondition = null;

        return operatorCondition += gameType switch
        {
            GameType.Addition=> ValidAddition,
            GameType.Subtraction => ValidSubtraction,
            GameType.Multiplication => ValidMultiplication,
            GameType.Division => ValidDivision,
            _ => throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null)
        };
    }

    public delegate bool NumberGeneratorCondition(int a, int b);

    private static bool NoConditionNecessary(int a, int b) => false;
    private static bool SubtractionLessThanZero(int a, int b) => a - b < 0;
    private static bool DivisionHasRemainder(int a, int b) => a % b != 0;

    public delegate bool OperatorCondition(int a, int b, int c);

    private static bool ValidAddition(int a, int b, int c) => a + b == c;
    private static bool ValidSubtraction(int a, int b, int c) => a - b == c;
    private static bool ValidMultiplication(int a, int b, int c) => a * b == c;
    private static bool ValidDivision(int a, int b, int c) => a / b == c;
}