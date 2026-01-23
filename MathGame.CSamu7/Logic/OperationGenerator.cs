namespace MathGame.Logic
{

    public class OperationGenerator(IIntervalFactory interval)
    {
        private readonly Random _rnd = new();
        private readonly IIntervalFactory _interval = interval;
        private readonly DivisionValidation _divValidation = new();
        public Operation Generate(string op)
        {
            while (true)
            {
                Interval interval = _interval.GetInterval(op);

                int n1 = _rnd.Next(interval.Min, interval.Max);
                int n2 = _rnd.Next(interval.Min, interval.Max);

                if (op == "/" && !_divValidation.IsValid(n1, n2))
                    continue;

                return new Operation(n1, n2, op);
            }
        }
    }
}
