using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J;

public class OperatorSwitch
{
    public char Operator { get; set; }

    public OperatorSwitch(GameType gameType)
    {
        Operator = (char)gameType;

        if (gameType == GameType.Random)
        {
            Operator = (char)RandomizeOperation();
        }
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
    
    public delegate bool NumberGeneratorCondition(int a, int b);

    public delegate bool OperatorCondition(int a, int b, int c);
    
    public NumberGeneratorCondition NumberGeneratorConditionDelegate => LoadNumberGeneratorConditionDelegate((GameType)Operator);
    
    public OperatorCondition OperatorConditionDelegate => LoadOperatorConditionDelegate((GameType)Operator);

    private static NumberGeneratorCondition LoadNumberGeneratorConditionDelegate(GameType gameType)
    {
        NumberGeneratorCondition numberGeneratorCondition = gameType switch
        {
            GameType.Addition => NoConditionNecessary,
            GameType.Subtraction => SubtractionLessThanZero,
            GameType.Multiplication => NoConditionNecessary,
            GameType.Division => DivisionHasRemainder,
            _ => throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null)
        };

        return numberGeneratorCondition;
    }

    private static bool NoConditionNecessary(int a, int b) => false;

    private static bool SubtractionLessThanZero(int a, int b) => a - b < 0;

    private static bool DivisionHasRemainder(int a, int b) => a % b != 0;

    private static OperatorCondition LoadOperatorConditionDelegate(GameType gameType)
    {
        OperatorCondition operatorCondition = gameType switch
        {
            GameType.Addition=> ValidAddition,
            GameType.Subtraction => ValidSubtraction,
            GameType.Multiplication => ValidMultiplication,
            GameType.Division => ValidDivision,
            _ => throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null)
        };

        return operatorCondition;
    }
    
    private static bool ValidAddition(int a, int b, int c) => a + b == c;
    
    private static bool ValidSubtraction(int a, int b, int c) => a - b == c;
    
    private static bool ValidMultiplication(int a, int b, int c) => a * b == c;
    
    private static bool ValidDivision(int a, int b, int c) => a / b == c;
}