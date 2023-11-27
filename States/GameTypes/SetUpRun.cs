namespace Branch_Console;

internal class SetUpRun : State
{
    internal OperationType operationType;
    private List<MathOperation> operations = new();
    public override void Print()
    {
        Console.Clear();
        Console.WriteLine($"Building your exercises run.....");
        Console.WriteLine();

        for (int i = 1; i <= _context._settings.QuestionsCount; i++)
        {
            Console.CursorTop = Console.CursorTop - 1;
            Console.WriteLine($"Building: {i} of {_context._settings.QuestionsCount}");
            operations.Add(Helpers.GetOperation(operationType, _context._settings.Difficulty));
        }
        Console.WriteLine($"Finished. Good Luck!\nPress any key to start.");

    }

    public override State? Process()
    {

        Console.ReadLine();

        return new GameRun() { operations = this.operations };
    }
}