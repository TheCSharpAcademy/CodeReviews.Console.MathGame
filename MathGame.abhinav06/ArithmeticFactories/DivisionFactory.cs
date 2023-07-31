using MathGame.Entities;

namespace MathGame.ArithmeticFactories;

class DivisionFactory : IArithmeticFactory
{
    readonly Random Random = new();

    Level Difficulty { get; set; }

    public DivisionFactory(Level level) => Difficulty = level;

    public Question GenerateQuestion()
    {
        int number1 = GenerateNumber(isGreater: true);
        int number2 = GenerateNumber(isGreater: false);

        return new Question()
        {
            Title = $"{number1 * number2} / {number2}",
            Answer = number1,
        };
    }

    int GenerateNumber(bool isGreater) => Difficulty switch
    {
        Level.Easy => isGreater ? Random.Next(20, 80) : Random.Next(2, 10),
        Level.Medium => isGreater ? Random.Next(80, 150) : Random.Next(10, 25),
        Level.Hard => isGreater ? Random.Next(150, 400) : Random.Next(25, 50),
        _ => throw new NotSupportedException(),
    };
}
