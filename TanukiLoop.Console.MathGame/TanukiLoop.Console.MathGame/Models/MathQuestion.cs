namespace TanukiLoop.Console.MathGame.Models;

public class MathQuestion
{
    public int Operand1 { get; set; }
    public int Operand2 { get; set; }
    public MathOperation Operation { get; set; }
    public string OperationSymbol { get; set; }
    public int ExpectedAnswer { get; set; }
    public int UserAnswer { get; set; }
}

public enum MathOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}