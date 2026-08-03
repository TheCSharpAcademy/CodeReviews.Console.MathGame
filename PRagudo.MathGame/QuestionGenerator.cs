using System;
namespace PRagudo.MathGame;

public class QuestionGenerator
{
    private readonly Random random = new();
    private int _lowerBoundary = 0;
    private int _upperBoundary = 101;


    public void SetNumberBoundaries(int lowerBoundary, int upperBoundary)
    {
        if (upperBoundary <= 0 || upperBoundary < lowerBoundary)
            throw new ArgumentOutOfRangeException(nameof(upperBoundary), "Upper boundary must be greater than zero and cannot be less than the lower boundary.");

        _lowerBoundary = lowerBoundary;
        _upperBoundary = upperBoundary;
    }

    public Question GetQuestion(int operationInt = -1)
    {
        int _operationInt;

        if (operationInt == -1)
        {
            _operationInt = random.Next(4);
        }
        else
        {
            _operationInt = operationInt;
        }

        while(true)
        {
            int firstValue = random.Next(_lowerBoundary, _upperBoundary);
            int secondValue = random.Next(_lowerBoundary, _upperBoundary);

            if(_operationInt == 3 && secondValue == 0)
            {
                continue;
            }
            if (_operationInt == 3 && firstValue % secondValue != 0)
            {
                continue;
            }

            Question question = new();

            (string op, int answer) = _operationInt switch
            {
                0 => ("+", firstValue + secondValue),
                1 => ("-", firstValue - secondValue),
                2 => ("*", firstValue * secondValue),
                3 => ("/", firstValue / secondValue),
                _ => throw new ArgumentOutOfRangeException(nameof(_operationInt), "Invalid operation code.")
            };

            question.Content = $"{firstValue} {op} {secondValue}";
            question.Answer = answer;

            return question;
        }
    }
}
