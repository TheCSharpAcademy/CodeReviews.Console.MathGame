namespace MathGame.pcjb.Models;

internal static class MathQuestionFactory
{
    internal static MathQuestion CreateQuestion(GameType type)
    {
        return type switch
        {
            GameType.Addition => new AdditionQuestion(),
            GameType.Subtraction => new SubtractionQuestion(),
            GameType.Multiplication => new MultiplicationQuestion(),
            GameType.Division => new DivisionQuestion(),
            _ => throw new NotImplementedException(),
        };
    }
}