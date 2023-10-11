namespace MathGame.pcjb.Models;

internal static class MathQuestionFactory
{
    internal static MathQuestion CreateQuestion(GameType type, GameDifficulty difficulty)
    {
        GameType internalType;
        if (GameType.Random == type)
        {

            internalType = RandomGameType();
        }
        else
        {
            internalType = type;
        }

        return internalType switch
        {
            GameType.Addition => new AdditionQuestion(difficulty),
            GameType.Subtraction => new SubtractionQuestion(difficulty),
            GameType.Multiplication => new MultiplicationQuestion(difficulty),
            GameType.Division => new DivisionQuestion(difficulty),
            _ => throw new NotImplementedException(),
        };
    }

    private static GameType RandomGameType()
    {
        var games = new List<GameType>{
            GameType.Addition,
            GameType.Subtraction,
            GameType.Multiplication,
            GameType.Division
        };

        Random rnd = new();
        var index = rnd.Next(games.Count);
        return games[index];
    }
}