namespace MathGame.Dknx8888;

public static class GameResultTemplate
{
    public record QuestionResult (
        int Num1,
        int Num2,
        char Sign,
        double PlayerAnswer,
        int CorrectAnswer,
        bool IsCorrect
        );
    
    public record GameResult (
        GameMode GameMode,
        Difficulty Difficulty,
        int Score,
        double RoundTime,
        List<QuestionResult> Questions,
        DateTime StartTime
    );
}