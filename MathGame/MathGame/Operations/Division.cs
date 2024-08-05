namespace MathGame;

internal class Division : Operation
{
    public Division(Difficulty difficulty) : base(difficulty)
    {
        int dividend;
        int divisor;

        do
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    dividend = GlobalRandom.Instance.Next(0, 501);
                    break;
                case Difficulty.Medium:
                    dividend = GlobalRandom.Instance.Next(10, 701);
                    break;
                case Difficulty.Hard:
                    dividend = GlobalRandom.Instance.Next(100, 1001);
                    break;
                default:
                    throw new Exception($"The difficulty {Enum.GetName(typeof(Difficulty), difficulty)} isn't valid");
            }
            divisor = GlobalRandom.Instance.Next(80, 101);
        }
        while (dividend % divisor != 0);

        FirstOperand = dividend;
        SecondOperand = divisor;
    }

    public override int PerformOperation()
    {
        return FirstOperand / SecondOperand;
    }

    public override string ToString()
    {
        return $"{FirstOperand} / {SecondOperand}";
    }
}
