namespace MathGame.Antonderegt;

public interface IQuestion
{
    public string Question { get; }
    public int Operand1 { get; set; }
    public int Operand2 { get; set; }
    public int Answer { get; }
}