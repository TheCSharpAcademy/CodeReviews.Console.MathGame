namespace MathGame
{
    internal class SubtractionGame : BaseGame
    {
        public SubtractionGame() : base(GameSettings.GetRoundsLength(), '-', "Subtraction")
        {

        }

        protected override bool Evaluate(Round round, int answer)
        {
            return round.left - round.right == answer;
        }
    }
}
