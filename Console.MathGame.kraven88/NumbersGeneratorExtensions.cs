using MathGame.Models;

namespace MathGame;

internal static class NumbersGeneratorExtensions
{
    internal static Equasion SetNumbersForDivision(this Equasion eq, int range)
    {
        bool isValidResult = false;
        while (isValidResult == false)
        {
            eq.A = Random.Shared.Next(range / 5, range);
            eq.B = Random.Shared.Next(1, range / 2);
            isValidResult = eq.A % eq.B == 0;
        }

        return eq;
    }

    internal static Equasion SetNumbers(this Equasion eq, int range)
    {
        eq.A = Random.Shared.Next(1, range);
        eq.B = Random.Shared.Next(1, range);
        return eq;
    }
}
