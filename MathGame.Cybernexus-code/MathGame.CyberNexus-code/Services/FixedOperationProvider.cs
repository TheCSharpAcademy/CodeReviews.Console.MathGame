public class FixedOperationProvider(Operation operation) : IOperationProvider
{
    public string DisplayName {get;} = operation.ToString();
    private readonly Operation _operation = operation;

    public Operation GetOperation()
    {
        return _operation;
    }
}