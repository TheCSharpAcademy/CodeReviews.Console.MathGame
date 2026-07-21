using MathGame.Models;

namespace MathGame.DataSource;

internal interface IGameHistoryData
{
    List<GameEntry> GameHistory { get; set; }
}
