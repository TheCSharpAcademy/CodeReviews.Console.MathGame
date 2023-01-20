namespace MathGame.Entities;

class HistoryRecord
{
    public DateTime Date { get; set; }

    public int Score { get; set; }

    public Operation GameType { get; set; }

    public Level Difficulty {  get; set; }

    public TimeSpan Duration { get; set; }

    public HistoryRecord GetDeepClone() => new()
    {
        Date = Date,
        Score = Score,
        GameType = GameType,
        Difficulty = Difficulty,
        Duration = Duration
    };
}
