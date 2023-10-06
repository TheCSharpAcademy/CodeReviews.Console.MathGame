using MathGame.Models;

namespace MathGame.Modes;

internal class Multiplication : IOperation
{
    public string DisplayName => "Multiplication";

    public string DisplayPattern => "{0} * {1}";

    public int Calculate(int a, int b)
    {
        return a * b;
    }

    public Tuple<int, int> DecomposeResult(Random rnd, int requiredResult, Tuple<int, int> domainA, Tuple<int, int> domainB)
    {
        var (minA, maxA) = domainA;
        var (minB, maxB) = domainB;
        int minProduct = Math.Min(Math.Min(minA * minB, minA * maxB), Math.Min(maxA * minB, maxA * maxB));
        int maxProduct = Math.Max(Math.Max(minA * minB, minA * maxB), Math.Max(maxA * minB, maxA * maxB));

        if (requiredResult < minProduct || maxProduct < requiredResult)
        {
            throw new ArgumentException("The required result cannot be decomposed into two numbers within the given domains.");
        }

        HashSet<int> factors = new();
        for (int i = 1; i <= (int)Math.Ceiling(Math.Sqrt(Math.Abs(requiredResult))); i++)
        {
            if (requiredResult % i == 0)
            {
                factors.Add(i);
                factors.Add(-i);
            }
        }

        int a = factors.ElementAt(rnd.Next(factors.Count));
        int b = requiredResult / a;

        if (a == 1 || a == -1 || b == 1 || b == -1)
        {
            // Just an extra "roll" to minimize the occurrence of the trivial case.
            a = factors.ElementAt(rnd.Next(factors.Count));
            b = requiredResult / a;
        }

        return new Tuple<int, int>(a, b);
    }
}
