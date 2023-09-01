namespace C_Sharp_Academy.ArithmeticOperations;

public interface IArithmeticOperation
{
    string OperationMessage { get; }
    char ArithmeticOperator { get; }
    int PerformOperation(int int1, int int2);
}