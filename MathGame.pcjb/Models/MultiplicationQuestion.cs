namespace MathGame.pcjb.Models;

internal class MultiplicationQuestion : MathQuestion
{
    public MultiplicationQuestion(GameDifficulty difficulty) : base (GameType.Multiplication, difficulty)
    {
        Random rnd = new();
        var a = rnd.Next(0, maxNumber);
        var b = rnd.Next(0, maxNumber);
        Text = $"{a} * {b}";
        ExpectedAnswer = $"{a * b}";
    }
}