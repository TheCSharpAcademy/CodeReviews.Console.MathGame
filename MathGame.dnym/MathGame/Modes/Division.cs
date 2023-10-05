using MathGame.Models;

namespace MathGame.Modes
{
    internal class Division : IOperation
    {
        public string DisplayName => "Division";

        public string DisplayPattern => "{0} / {1}";

        public int Calculate(int a, int b)
        {
            return a / b;
        }

        public Tuple<int, int> DecomposeResult(Random rnd, int requiredResult, Tuple<int, int> domainA, Tuple<int, int> domainB)
        {
            var (minA, maxA) = domainA;
            var (minB, maxB) = domainB;
            // According to spec, divisors must be kept non-negative.
            minA = Math.Max(minA, 0);
            // Compensate for exclusive end.
            maxA--;
            maxB--;
            // Remove zero from domain by shrinking.
            if (minB == 0)
            {
                minB++;
            }
            if (maxB == 0)
            {
                maxB--;
            }

            double minQ, maxQ;
            {
                var minAd = (double)minA;
                var maxAd = (double)maxA;
                var minBd = (double)minB;
                var maxBd = (double)maxB;

                // Calculate the possible range of quotients.
                if (minAd >= 0 && minBd > 0)
                {
                    // A non-negative, B positive.
                    minQ = minAd / maxBd;
                    maxQ = maxAd / minBd;
                }
                else if (maxAd < 0 && maxBd < 0)
                {
                    // Both negative.
                    minQ = maxAd / minBd;
                    maxQ = minAd / maxBd;
                }
                else if (minAd >= 0 && maxBd < 0)
                {
                    // A non-negative, B negative.
                    minQ = maxAd / maxBd;
                    maxQ = minAd / minBd;
                }
                else if (maxAd < 0 && minBd > 0)
                {
                    // A negative, B positive.
                    minQ = minAd / minBd;
                    maxQ = maxAd / maxBd;
                }
                else
                {
                    // One or both are mixed.
                    if (minAd >= 0)
                    {
                        // If A is non-negative, B must be mixed and contains -1 and 1.
                        minQ = maxAd / -1;
                        maxQ = maxAd / 1;
                    }
                    else if (maxAd < 0)
                    {
                        // If A is negative, B must be mixed and contains -1 and 1.
                        minQ = minAd / -1;
                        maxQ = minAd / 1;
                    }
                    else if (minBd > 0)
                    {
                        minQ = minAd / minBd;
                        maxQ = maxAd / minBd;
                    }
                    else if (maxBd < 0)
                    {
                        minQ = maxAd / maxBd;
                        maxQ = minAd / maxBd;
                    }
                    else
                    {
                        // Both are mixed, and B must contain both -1 and 1.
                        var max = Math.Max(Math.Abs(minAd), Math.Abs(maxAd));
                        minQ = max / -1;
                        maxQ = max / 1;
                    }
                }
            }

            if (requiredResult < minQ || maxQ < requiredResult)
            {
                throw new ArgumentException("The required result cannot be decomposed into two numbers within the given domains.");
            }

            var pairs = new List<Tuple<int, int>>();
            for (int b = minB; b <= maxB; b++)
            {
                if (b == 0)
                {
                    continue;
                }
                var a = requiredResult * b;
                if (a >= minA && a <= maxA)
                {
                    pairs.Add(new Tuple<int, int>(a, b));
                }
            }
            if (pairs.Count == 0)
            {
                throw new ArgumentException("The required result cannot be decomposed into two numbers within the given domains.");
            }

            var pair = pairs[rnd.Next(pairs.Count)];
            if (pair.Item2 == -1 || pair.Item2 == 1)
            {
                // Just an extra "roll" to minimize the occurrence of the trivial case.
                pair = pairs[rnd.Next(pairs.Count)];
            }
            return pair;
        }
    }
}
