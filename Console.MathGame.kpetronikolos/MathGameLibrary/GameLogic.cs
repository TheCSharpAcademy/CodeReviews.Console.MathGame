using MathGameLibrary.Models;

namespace MathGameLibrary;

public static class GameLogic
{
    public static int GenerateCorrectAnswer(int[] operands, GameType gameType)
    {
        switch (gameType)
        {
            case GameType.Addition:
                return operands[0] + operands[1];
            case GameType.Subtraction:
                return operands[0] - operands[1];
            case GameType.Multiplication:
                return operands[0] * operands[1];
            case GameType.Division:
                return operands[0] / operands[1];
            default:
                throw new ArgumentException("Invalid Game Type", "gameType");

        }
    }

    public static int[] GenerateOperands(GameType gameType, int upperBound)
    {
        var random = new Random();

        int firstOperand = random.Next(0, upperBound);
        int secondOperand = (gameType == GameType.Division) ? random.Next(1, upperBound) : random.Next(0, upperBound);

        if (gameType == GameType.Division)
        {
            while (IsEvenlyDivisable(firstOperand, secondOperand) == false)
            {
                firstOperand = random.Next(0, upperBound);
                secondOperand = random.Next(1, upperBound);
            }
            
        }

        return new int[] { firstOperand, secondOperand };

    }

    public static string GetOperatorSymbol(GameType gameType)
    {
        switch (gameType)
        {
            case GameType.Addition:
                return "+";
            case GameType.Subtraction:
                return "-";
            case GameType.Multiplication:
                return "*";
            case GameType.Division:
                return "/";
            default:
                throw new ArgumentException("Invalid Game Type", "gameType");

        }
    }

    private static bool IsEvenlyDivisable(int divident, int divisor)
    {
        return divident % divisor == 0;
    }
}
