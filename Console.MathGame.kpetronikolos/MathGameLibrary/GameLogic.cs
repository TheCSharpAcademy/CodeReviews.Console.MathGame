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

    public static int[] GenerateOperands(GameType gameType)
    {
        var random = new Random();

        int firstOperand = random.Next(0, 100);
        int secondOperand = (gameType == GameType.Division) ? random.Next(1, 100) : random.Next(0, 100);

        if (gameType == GameType.Division)
        {
            while (IsEvenlyDivisable(firstOperand, secondOperand) == false)
            {
                firstOperand = random.Next(0, 100);
                secondOperand = random.Next(1, 100);
            }
            
        }

        return new int[] { firstOperand, secondOperand };

    }

    private static bool IsEvenlyDivisable(int divident, int divisor)
    {
        return divident % divisor == 0;
    }
}
