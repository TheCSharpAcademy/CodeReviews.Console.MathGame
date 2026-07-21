using MathGame.DataSource;
using MathGame.Models;

namespace MathGame.Repositories;

internal class HistoryRepository(IGameHistoryData dataSource) : IHistoryRepository
{
    private readonly IGameHistoryData _dataSource = dataSource;

    public List<GameEntry> GetGameHistory()
    {
        return _dataSource.GameHistory;
    }

    public bool AddGameEntry(GameEntry entry)
    {
        entry.Id = _dataSource.GameHistory.Count + 1;
        _dataSource.GameHistory.Add(entry);
        return true;
    }
}
