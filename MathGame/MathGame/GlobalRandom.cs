namespace MathGame;

internal sealed class GlobalRandom
{
    private static readonly Random _random = new Random();
    private GlobalRandom() { }

    public static Random Instance
    {
        get
        {
            return _random;
        }
    }
}
