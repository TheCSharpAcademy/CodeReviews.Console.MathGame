namespace MathGame.Logic
{
    public record Interval
    {
        public int Min { get; init; }
        public int Max { get; init; }
        public Interval(int min, int max)
        {
            if (min > max) throw new ArgumentException();

            Min = min;
            Max = max;
        }
    }
}
