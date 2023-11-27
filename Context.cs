namespace Branch_Console;

internal class Context
{
    private State? _state = null;
    internal Settings? _settings = null;
    internal int SessionScore = 0;
    internal List<Game> gameHistory = new List<Game>();
    internal Context(State state)
    {
        _settings = new() { Difficulty = Difficulty.Normal, PlayerName = "", QuestionsCount = 5 };
        TransitionTo(state);
    }

    internal void TransitionTo(State? state)
    {
        _state = state;
        if (_state != null)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
            _state.SetContext(this);
        }
    }

    internal void SetUpConsole()
    {
        _state.Print();
    }

    internal void ProcessInput()
    {
        TransitionTo(_state.Process());
    }

    internal bool GetGameOn()
    {
        return _state != null;
    }
}