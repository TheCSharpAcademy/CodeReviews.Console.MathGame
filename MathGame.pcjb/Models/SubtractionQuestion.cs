namespace MathGame.pcjb.Models;

internal class SubtractionQuestion : MathQuestion
{
    public SubtractionQuestion() : base(GameType.Subtraction)
    {
        Random rnd = new();
        var a = rnd.Next(0, maxNumber);
        var b = rnd.Next(0, maxNumber);
        Text = $"{a} - {b}";
        ExpectedAnswer = $"{a - b}";
    }
}