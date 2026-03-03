using MathGame.Models;

namespace MathGame.Services;

public class GameHistory
{
    private readonly List<GameSession> _sessions = new();

    public void Add(GameSession session)
    {
        _sessions.Add(session);
    }

    public IReadOnlyList<GameSession> GetAll()
    {
        return _sessions.AsReadOnly();
    }
}
