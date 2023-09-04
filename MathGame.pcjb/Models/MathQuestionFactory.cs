namespace MathGame.pcjb.Models;

internal static class MathQuestionFactory
{
    internal static MathQuestion CreateQuestion(GameType type, GameDifficulty difficulty)
    {
        return type switch
        {
            GameType.Addition => new AdditionQuestion(difficulty),
            GameType.Subtraction => new SubtractionQuestion(difficulty),
            GameType.Multiplication => new MultiplicationQuestion(difficulty),
            GameType.Division => new DivisionQuestion(difficulty),
            _ => throw new NotImplementedException(),
        };
    }
}