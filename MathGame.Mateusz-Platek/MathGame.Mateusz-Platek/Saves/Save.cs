using MathGame.Mateusz_Platek.Questions;

namespace MathGame.Mateusz_Platek.Saves;

public class Save
{
    private Question question;
    private int userAnswer;
    private bool isCorrect;
    private TimeSpan timeSpan;

    public Save(Question question, int userAnswer, TimeSpan timeSpan)
    {
        this.question = question;
        this.userAnswer = userAnswer;
        this.isCorrect = question.Result == userAnswer;
        this.timeSpan = timeSpan;
    }

    public override string ToString()
    {
        return $"Correct answer: {question} Your answer: {userAnswer} Result: {isCorrect} Time: {timeSpan.Seconds}s:{timeSpan.Milliseconds}ms";
    }
}