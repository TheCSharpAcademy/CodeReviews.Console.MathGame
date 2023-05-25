namespace MathGame
{
    internal class AdditionGame : BaseGame
    {
        public AdditionGame() : base(GameSettings.GetRoundsLength(), '+', "Addition")
        {

        }

        protected override bool Evaluate(Round round, int answer)
        {
            return round.left + round.right == answer;
        }
    }
}
