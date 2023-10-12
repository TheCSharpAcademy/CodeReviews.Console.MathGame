namespace MathGame_CSA;

public class Puzzle
{
    int _firstOperand;
    int _secondOperand;
    MathOperation _operation;
    public bool IsCorrect { get; private set; }

    public Puzzle(Random random, MathOperation op)
    {
        _operation = op == MathOperation.Random ? (MathOperation)random.Next((int)MathOperation.Random) : op;
        _firstOperand = random.Next(1, 99);
        _secondOperand = random.Next(1, 99);

        if (_operation == MathOperation.Division)
        {
            while (_firstOperand < _secondOperand || _firstOperand % _secondOperand != 0)
            {
                _firstOperand = random.Next(1, 99);
                _secondOperand = random.Next(1, 99);
            }
        }
    }

    public void Play()
    {
        Console.WriteLine($"\nSolve this puzzle:\n{_firstOperand} {_operation.ToOperatorString()} {_secondOperand}");
        var input = Console.ReadLine();

        if (int.TryParse(input, out var answer)
            && answer == _operation.Calculate(_firstOperand, _secondOperand))
        {
            Console.WriteLine("Correct!");
            IsCorrect = true;
        }
        else
        {
            Console.WriteLine($"Wrong.\nRight answer was: {_operation.Calculate(_firstOperand, _secondOperand)}");
            IsCorrect = false;
        }
    }
}
