namespace Branch_Console;

internal abstract class State
{
    protected Context? _context;

    public void SetContext(Context context)
    {
        _context = context;
    }

    public abstract void Print();

    public abstract State? Process();
}