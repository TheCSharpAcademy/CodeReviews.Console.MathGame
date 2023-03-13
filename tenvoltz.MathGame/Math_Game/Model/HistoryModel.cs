using Math_Game.Model.Problems;
namespace Math_Game.Model;

internal class HistoryModel
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public ProblemType Type { get; set; }
    public TimeSpan AverageDuration { get; set; }
    public override string ToString()
    {
        return $"{Date} - {Type}: {Score}pts with average time of {AverageDuration.ToString(@"hh\:mm\:ss")}";
    }
}
