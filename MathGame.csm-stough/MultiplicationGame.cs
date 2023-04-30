namespace MathGame
{
    internal class MultiplicationGame : BaseGame
    {
        public MultiplicationGame() : base(GameSettings.GetRoundsLength(), '*', "Multiplication")
        {

        }

        protected override bool Evaluate(Round round, int answer)
        {
            return round.left * round.right == answer;
        }
    }
}
