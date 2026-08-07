public class GameRunRecording
{
    public string GamePlayMode { get; set; } = "";
    public int FinalTime { get; set; }
    public int CorrectAnswers { get; set; }
    public int BestStreak { get; set; }
    public int Score { get; set; }

    public override string ToString()
    {
        return $"{GamePlayMode,-10}\t\t\t\t{Text.FinalRunTime}: {FinalTime}s\t\t{Text.FinalCorrectAnswers} {CorrectAnswers}\t\t{Text.FinalBestStreak} {BestStreak}\t\t{Text.FinalScore} {Score}";
    }
}