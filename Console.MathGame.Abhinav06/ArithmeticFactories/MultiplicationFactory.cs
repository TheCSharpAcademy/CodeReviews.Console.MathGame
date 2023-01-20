using MathGame.Entities;

namespace MathGame.ArithmeticFactories;

class MultiplicationFactory : IArithmeticFactory
{
    readonly Random Random = new();

    Level Difficulty { get; set; }

    public MultiplicationFactory(Level level) => Difficulty = level;

    public Question GenerateQuestion()
    {
        int number1 = GenerateNumber();
        int number2 = GenerateNumber();

        return new Question()
        {
            Title = $"{number1} x {number2}",
            Answer = number1 * number2
        };
    }

    int GenerateNumber() => Difficulty switch
    {
        Level.Easy => Random.Next(2, 20),
        Level.Medium => Random.Next(20, 50),
        Level.Hard => Random.Next(50, 100),
        _ => throw new NotSupportedException(),
    };
}
