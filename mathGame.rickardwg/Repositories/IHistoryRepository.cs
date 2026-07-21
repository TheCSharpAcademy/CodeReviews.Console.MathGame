using MathGame.Models;

namespace MathGame.Repositories;

internal interface IHistoryRepository
{
    List<GameEntry> GetGameHistory();
    bool AddGameEntry(GameEntry entry);
}
