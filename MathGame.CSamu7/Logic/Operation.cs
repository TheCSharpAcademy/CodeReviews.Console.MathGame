namespace MathGame.Logic
{
    public record Operation
    {
        public int N1 { get; private set; }
        public int N2 { get; private set; }
        public string Operator { get; private set; }
        public Operation(int n1, int n2, string op)
        {
            N1 = n1;
            N2 = n2;
            Operator = op;
        }
        public int Calculate()
        {
            return Operator switch
            {
                "+" => N1 + N2,
                "-" => N1 - N2,
                "*" => N1 * N2,
                "/" => N1 / N2,
            };
        }
    }
}
