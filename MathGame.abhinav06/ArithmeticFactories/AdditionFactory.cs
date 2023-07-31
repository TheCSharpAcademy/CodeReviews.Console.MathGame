using MathGame.Entities;

namespace MathGame.ArithmeticFactories;

class AdditionFactory : IArithmeticFactory
{
    readonly Random Random = new();

    Level Difficulty {  get; set; }

    public AdditionFactory(Level level) => Difficulty = level;

    public Question GenerateQuestion()
    {
        int number1 = GenerateNumber();
        int number2 = GenerateNumber();

        return new Question()
        {
            Title = $"{number1} + {number2}",
            Answer = number1 + number2
        };
    }

    int GenerateNumber() => Difficulty switch
    {
        Level.Easy => Random.Next(2, 80),
        Level.Medium => Random.Next(80, 200),
        Level.Hard => Random.Next(200, 1000),
        _ => throw new NotSupportedException(),
    };
}
