using MathGame.Models;

namespace MathGame.DataSource;

internal class GameHistoryData : IGameHistoryData
{
    public List<GameEntry> GameHistory { get; set; } = [];
}
