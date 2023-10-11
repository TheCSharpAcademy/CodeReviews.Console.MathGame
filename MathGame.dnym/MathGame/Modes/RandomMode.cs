using MathGame.Models;

namespace MathGame.Modes;

internal class RandomMode : IOperation
{
    public string DisplayName => "Random";

    public string DisplayPattern => "{0} ? {1}";

    public int Calculate(int a, int b)
    {
        throw new NotImplementedException();
    }

    public Tuple<int, int> DecomposeResult(Random rnd, int requiredResult, Tuple<int, int> domainA, Tuple<int, int> domainB)
    {
        throw new NotImplementedException();
    }
}
