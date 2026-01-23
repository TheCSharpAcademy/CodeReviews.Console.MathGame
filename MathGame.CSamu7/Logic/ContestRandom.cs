namespace MathGame.Logic
{
    public class ContestRandom : Contest
    {
        public ContestRandom(ContestConfig config) : base(config)
        {

        }
        protected override string GetOperator()
        {
            List<string> operators = ["+", "-", "*", "/"];
            Random rnd = new Random();

            int rndIndex = rnd.Next(operators.Count);

            return operators[rndIndex];
        }
    }
}
