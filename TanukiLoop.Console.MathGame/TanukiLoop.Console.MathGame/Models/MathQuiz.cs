using System.Collections;

namespace TanukiLoop.Console.MathGame.Models;

public class MathQuiz : IEnumerable<MathQuestion>
{
    public string? QuizType { get; set; }
    public List<MathQuestion> MathQuestions { get; } = new();
    public DateTime StartTime { get; set; } = DateTime.Now;

    public int NumQuestionsCorrect => MathQuestions
        .Count(q => q.UserAnswer == q.ExpectedAnswer);

    private int CurrentQuestionNumber { get; set; } = -1;


    public void AddQuestion(MathQuestion mathQuestion)
    {
        MathQuestions.Add(mathQuestion);
    }

    public MathQuestion? Next()
    {
        if (HasNext())
        {
            CurrentQuestionNumber++;
            return MathQuestions[CurrentQuestionNumber];
        }
        else
        {
            return null;
        }
    }

    public IEnumerator<MathQuestion> GetEnumerator()
    {
        // throw new NotImplementedException();
        return MathQuestions.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public MathQuestion this[int index]
    {
        get => MathQuestions[index];

        set => MathQuestions[index] = value;
    }

    public bool HasNext()
    {
        return CurrentQuestionNumber < MathQuestions.Count - 1;
    }
}