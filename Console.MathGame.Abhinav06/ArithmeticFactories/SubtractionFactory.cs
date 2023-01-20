using MathGame.Entities;

namespace MathGame.ArithmeticFactories;

class SubtractionFactory : IArithmeticFactory
{
    readonly Random Random = new();

    Level Difficulty { get; set; }

    public SubtractionFactory(Level level) => Difficulty = level;

    public Question GenerateQuestion()
    {
        int number1 = GenerateNumber(isGreater: true);
        int number2 = GenerateNumber(isGreater: false);

        return new Question()
        {
            Title = $"{number1} - {number2}",
            Answer = number1 - number2,
        };
    }

    int GenerateNumber(bool isGreater) => Difficulty switch
    {
        Level.Easy => isGreater ? Random.Next(40, 80) : Random.Next(2, 40),
        Level.Medium => isGreater ? Random.Next(150, 200) : Random.Next(80, 150),
        Level.Hard => isGreater ? Random.Next(600, 1000) : Random.Next(200, 600),
        _ => throw new NotSupportedException(),
    };
}