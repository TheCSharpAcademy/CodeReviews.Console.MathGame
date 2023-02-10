namespace Kolejarz.MathGame.GameEngine.PuzzleProviders;

internal abstract class PuzzleProvider : IPuzzleProvider
{
    protected readonly Random _random = new();

    public Puzzle GetPuzzle(Operation operation)
    {
        return operation switch
        {
            Operation.Random => GetPuzzle(Enum.GetValues<Operation>().Except(new[] { Operation.Random }).OrderBy(x => _random.Next()).First()),
            Operation.Addition => GetAddition(),
            Operation.Subtraction => GetSubtraction(),
            Operation.Multiplication => GetMultiplication(),
            Operation.Division => GetDivision(),
            _ => throw new ArgumentException($"{nameof(operation)}={operation} is not valid {nameof(Operation)}")
        };
    }

    public abstract Puzzle GetAddition();

    public abstract Puzzle GetDivision();

    public abstract Puzzle GetMultiplication();

    public abstract Puzzle GetSubtraction();

    protected Puzzle GetAddition(int minTerm, int maxTerm)
    {
        var firstTerm = _random.Next(minTerm, maxTerm + 1);
        var secondTerm = _random.Next(minTerm, maxTerm + 1);

        return new Puzzle($"{firstTerm} + {secondTerm}", firstTerm + secondTerm);
    }

    protected Puzzle GetSubtraction(int minTerm, int maxTerm)
    {
        var firstTerm = _random.Next(minTerm, maxTerm + 1);
        var secondTerm = _random.Next(minTerm, maxTerm + 1);

        return firstTerm > secondTerm ?
            new Puzzle($"{firstTerm} - {secondTerm}", firstTerm - secondTerm) :
            new Puzzle($"{secondTerm} - {firstTerm}", secondTerm - firstTerm);
    }

    protected Puzzle GetMultiplication(int minFactor, int maxFactor)
    {
        var firstFactor = _random.Next(minFactor, maxFactor + 1);
        var secondFactor = _random.Next(minFactor, maxFactor + 1);

        return new Puzzle($"{firstFactor} * {secondFactor}", firstFactor * secondFactor);
    }

    protected Puzzle GetDivision(int minDivisor, int maxDivisor, int maxDividend)
    {
        var divisor = _random.Next(minDivisor, maxDivisor + 1);
        var dividend = divisor * _random.Next(minDivisor, maxDividend / divisor);

        return new Puzzle($"{dividend} / {divisor}", dividend / divisor);
    }
}
