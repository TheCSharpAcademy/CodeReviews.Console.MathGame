public class Question
{
    public readonly int number1;
    public readonly int number2;
    private readonly Operation operation;
    public int CorrectAnswer;
    public int UserAnswer;

    public Question(int number1, int number2, Operation operation)
    {
        this.operation = operation;
        this.number1 = number1;
        this.number2 = number2;
    }

    public override string ToString()
    {
        return $"{number1} {operation} {number2} - User Answer: {UserAnswer} | Correct Answer: {CorrectAnswer}";
    }

}