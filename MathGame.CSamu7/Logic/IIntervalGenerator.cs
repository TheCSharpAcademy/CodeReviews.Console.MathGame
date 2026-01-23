namespace MathGame.Logic
{
    public interface IIntervalFactory
    {
        public Interval GetInterval(string op);
    }
    public class EasyIntervalFactory : IIntervalFactory
    {
        public Interval GetInterval(string op)
        {
            return op switch
            {
                "+" or "-" => new Interval(0, 10),
                "*" => new Interval(0, 10),
                "/" => new Interval(1, 60),
                _ => new Interval(0, 10)
            };
        }
    };
    public class MediumIntervalFactory : IIntervalFactory
    {
        public Interval GetInterval(string op)
        {
            return op switch
            {
                "+" or "-" => new Interval(0, 50),
                "*" => new Interval(0, 15),
                "/" => new Interval(3, 120),
                _ => new Interval(0, 50)
            };
        }
    }
    public class HardIntervalFactory : IIntervalFactory
    {
        public Interval GetInterval(string op)
        {
            return op switch
            {
                "+" or "-" => new Interval(0, 100),
                "*" => new Interval(0, 20),
                "/" => new Interval(4, 240),
                _ => new Interval(0, 100)
            };
        }
    }
}
