using MathGame.Controllers;

namespace MathGame.Services;

public class Calculator
{
    private int Add(int numA, int numB)
    {
        return numA + numB;
    }

    private int Subtract(int numA, int numB)
    {
        return numA - numB;
    }

    private int Multiply(int numA, int numB)
    {
        return numA * numB;
    }

    private int Divide(int numA, int numB)
    {
        return numA / numB;
    }

    public int Calculate(int numA, int numB, Operation operation)
    {
        switch (operation)
        {
            case Operation.Addition:
                return Add(numA, numB);
            case Operation.Subtraction:
                return Subtract(numA, numB);
            case Operation.Multiplication:
                return Multiply(numA, numB);
            case Operation.Division:
                return Divide(numA, numB);
            default:
                return -1;
        }
    }
}
