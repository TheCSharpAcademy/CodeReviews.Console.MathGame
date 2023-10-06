namespace MathGame.Models;

internal interface IOperation
{
    public string DisplayName { get; }
    public string DisplayPattern { get; }
    public int Calculate(int a, int b);

    /// <summary>
    /// Randomly decomposes the required result into two numbers that can be used by the operation to get the result. The numbers must be within the given domains (exclusive end). May throw an <see cref="ArgumentException"/> if the result cannot be decomposed.
    /// </summary>
    public Tuple<int, int> DecomposeResult(Random rnd, int requiredResult, Tuple<int, int> domainA, Tuple<int, int> domainB);
}
