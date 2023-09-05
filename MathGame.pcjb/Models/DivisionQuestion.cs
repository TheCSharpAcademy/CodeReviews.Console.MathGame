namespace MathGame.pcjb.Models;

internal class DivisionQuestion : MathQuestion
{
    public DivisionQuestion(GameDifficulty difficulty) : base(GameType.Division, difficulty)
    {
        Random rnd = new();
        int dividend, divisor;

        do
        {
            dividend = rnd.Next(1, maxNumber);
            divisor = rnd.Next(1, maxNumber);
        } while (divisor == 0 || dividend % divisor != 0);
        
        Text = $"{dividend} / {divisor}";
        ExpectedAnswer = $"{dividend / divisor}";
    }
}