using MathGame.Models;

namespace MathGame;

internal class RoundGenerator
{
    private readonly Random _random = new();
    private readonly Tuple<int, int> _domainA;
    private readonly Tuple<int, int> _domainB;
    private readonly Tuple<int, int> _range;

    public RoundGenerator(Tuple<int, int> domainA, Tuple<int, int> domainB, Tuple<int, int> range)
    {
        _domainA = domainA;
        _domainB = domainB;
        _range = range;
    }

    public Tuple<int, int, int> GenerateQuestion(IOperation operation)
    {
        while (true)
        {
            try
            {
                int result = _random.Next(_range.Item1, _range.Item2 + 1);
                var (a, b) = operation.DecomposeResult(_random, result, _domainA, _domainB);
                return new Tuple<int, int, int>(a, b, result);
            }
            catch (ArgumentException)
            {
                // Ignore.
            }
        }
    }
}
