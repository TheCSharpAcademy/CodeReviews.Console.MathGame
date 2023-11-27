namespace Branch_Console;

internal class MathOperation
{
    internal OperationType Operator { get; set; }
    internal Difficulty OperationDifficulty { get; set; }
    internal List<int> Operands { get; set; }
    internal int OperationResult { get; set; }

    public override string ToString()
    {
        return $"{GetExpression()} = {OperationResult}";
    }
    public string GetExpression()
    {
        return $"{string.Join(Helpers.GetOperationSymbol(Operator), Operands.ToArray())}";
    }
}

internal enum OperationType
{
    Addition, Subtration, Multiplication, Division
}