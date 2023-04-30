namespace MathGame
{
    internal class DivisionGame : BaseGame
    {
        public DivisionGame() : base(GameSettings.GetRoundsLength(), '/', "Division")
        {

        }

        protected override bool Evaluate(Round round, int answer)
        {
            return round.left / round.right == answer;
        }
    }
}
