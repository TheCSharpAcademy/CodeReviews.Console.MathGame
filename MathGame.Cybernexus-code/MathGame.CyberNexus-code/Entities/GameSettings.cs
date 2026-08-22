public class GameSettings
{
    public DifficultyLevel DifficultyLevel {get;}
    public int MinNumber {get;} = 1;
    public int MaxNumber {get;}
    public int QuestionCount {get;}

    public GameSettings(DifficultyLevel difficultyLevel)
    {
        DifficultyLevel = difficultyLevel;
        (MaxNumber, QuestionCount) = DifficultyLevel switch
        {
            DifficultyLevel.Easy => (20,3),
            DifficultyLevel.Normal => (50, 5),
            DifficultyLevel.Hard => (100, 10),
            _=> throw new ArgumentOutOfRangeException()
        };
    }
}