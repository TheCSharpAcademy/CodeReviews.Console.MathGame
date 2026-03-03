using MathGame.Enums;
using MathGame.Interfaces;
using MathGame.Models;

namespace MathGame.Services;

public class QuestionGenerator : IQuestionGenerator
{
    private readonly Random _random = new();

    public MathQuestion Generate(GameType game, DifficultySettings difficulty)
    {
        if (game == GameType.Division)
            return GenerateDivision(difficulty);
        else if (game == GameType.Multiplication)
            return GenerateMultiplication(difficulty);
        else if (game == GameType.Random)
            return GenerateRandom(difficulty);
        else
            return GenerateStandart(game, difficulty);
    }

    private MathQuestion GenerateStandart(GameType game, DifficultySettings difficulty)
    {
        int a = _random.Next(1, difficulty.MaxValue + 1);
        int b = _random.Next(1, difficulty.MaxValue + 1);
        return new MathQuestion(a, b, game);
    }

    private MathQuestion GenerateDivision(DifficultySettings difficulty)
    {
        int divisor = _random.Next(1, difficulty.MaxValue + 1);
        int maxQuotient = difficulty.MaxValue / divisor;
        int quotient = _random.Next(1, maxQuotient + 1);
        int dividend = divisor * quotient;
        return new MathQuestion(dividend, divisor, GameType.Division);
    }

    private MathQuestion GenerateMultiplication(DifficultySettings difficulty)
    {
        int multiplicand = _random.Next(1, difficulty.MaxValue + 1);
        int multiplier = _random.Next(1, difficulty.MaxValue + 1);
        return new MathQuestion(multiplicand, multiplier, GameType.Multiplication);
    }

    private MathQuestion GenerateRandom(DifficultySettings difficulty)
    {
        int randomEnum = _random.Next(0, 4);
        GameType randomGame = (GameType)randomEnum;
        return Generate(randomGame, difficulty);
    }
}
