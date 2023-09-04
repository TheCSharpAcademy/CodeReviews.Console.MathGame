namespace MathGame.pcjb.Models;

internal class AdditionQuestion : MathQuestion
{
    public AdditionQuestion() : base(GameType.Addition)
    {
        Random rnd = new();
        var a = rnd.Next(0, maxNumber);
        var b = rnd.Next(0, maxNumber);
        Text = $"{a} + {b}";
        ExpectedAnswer = $"{a + b}";
    }
}