using MathGame.Entities;

namespace MathGame.ArithmeticFactories;

static class ArithematicFactory
{
    public static IArithmeticFactory GetFactory(Operation operation, Level level) => operation switch
    {
        Operation.Addition => new AdditionFactory(level),
        Operation.Subtraction => new SubtractionFactory(level),
        Operation.Multiplication => new MultiplicationFactory(level),
        Operation.Division => new DivisionFactory(level),
        _ => throw new NotSupportedException(),
    };
}
