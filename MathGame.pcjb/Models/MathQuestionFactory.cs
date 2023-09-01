namespace MathGame.pcjb.Models;

internal static class MathQuestionFactory
{
    internal static MathQuestion CreateQuestion(GameType type)
    {
        return type switch
        {
            GameType.Addition => new AdditionQuestion(type),
            GameType.Subtraction => new SubtractionQuestion(type),
            GameType.Multiplication => new MultiplicationQuestion(type),
            GameType.Division => new DivisionQuestion(type),
            _ => throw new NotImplementedException(),
        };
    }
}