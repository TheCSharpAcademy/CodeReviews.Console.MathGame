using Spectre.Console;

namespace MathGame.Louis_dub.Calculation;

internal class RandomCalculation : IBaseCalculation
{
    public int Operation(int mode)
    {
        int score = 0;
        Func<int, int>[] operations = {
            AdditionCalculation.Sum, SubtractionCalculation.Sub, MultiplicationCalculation.Mul, DivisionCalculation.Div
        };
        Random op = new();

        for (int i = 0; i < 5; i++)
            score += operations[op.Next(0, 4)](mode);
        return score;
    }
    public int EasyMode()
    {
        return Operation(10);
    }

    public int MediumMode()
    {
        return Operation(100);
    }

    public int HardMode()
    {
        return Operation(1000);
    }
}