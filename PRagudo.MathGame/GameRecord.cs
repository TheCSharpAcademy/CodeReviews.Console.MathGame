namespace PRagudo.MathGame;

public record GameRecord
{
    public int Id { get; set; }
    public int TotalPoints { get; set; }
    public List<QuestionRecord> QuestionRecords { get; set; } = [];
}