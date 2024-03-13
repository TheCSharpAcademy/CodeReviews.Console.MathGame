namespace MathGame.Antonderegt;

public class SubstractionQuestion : IQuestion
{
    private static readonly Random random = new();
    public string Question { get => $"{Operand1} - {Operand2}"; }
    public int Operand1 { get; set; }
    public int Operand2 { get; set; }
    public int Answer { get => Operand1 - Operand2; }

    public SubstractionQuestion(int op1, int op2)
    {
        Operand1 = op1;
        Operand2 = op2;
    }

    public SubstractionQuestion()
    {
        Operand1 = random.Next(0, 101);
        Operand2 = random.Next(0, 101);
    }
}