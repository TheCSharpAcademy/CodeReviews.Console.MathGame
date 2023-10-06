namespace MathGame.Models;

internal class Round
{
    private int? _millisecondsToAnswer;
    public Round(IOperation operation, int firstNumber, int secondNumber, int givenAnswer)
    {
        Operation = operation;
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
        GivenAnswer = givenAnswer;
    }

    public IOperation Operation { get; }
    public int FirstNumber { get; }
    public int SecondNumber { get; }
    public int GivenAnswer { get; }
    public int MillisecondsToAnswer
    {
        get
        {
            if (_millisecondsToAnswer == null)
            {
                throw new InvalidOperationException("MillisecondsToAnswer is not set");
            }
            return _millisecondsToAnswer.Value;
        }
        set
        {
            if (_millisecondsToAnswer != null)
            {
                throw new InvalidOperationException("MillisecondsToAnswer is already set");
            }
            _millisecondsToAnswer = value;
        }
    }
}
