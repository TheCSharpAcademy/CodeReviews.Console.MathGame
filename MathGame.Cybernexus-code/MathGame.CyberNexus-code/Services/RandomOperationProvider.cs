using System.Buffers;

public class RandomOperationProvider : IOperationProvider
{
    public  string DisplayName {get;} = "Random";
    private readonly Random _rand;
    private readonly List<Operation> _operations;
    public RandomOperationProvider(Random rand, List<Operation> operations)
    {
        _rand = rand;
        _operations = operations;

    }
    public Operation GetOperation()
    {
        int index = _rand.Next(_operations.Count);
        return _operations[index];
    }
}