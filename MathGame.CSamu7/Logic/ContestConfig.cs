using MathGame.Views;

namespace MathGame.Logic
{
    public record ContestConfig
    {
        public Difficulty Difficulty { get; init; }
        public string Operator { get; init; }
        private ContestConfig(Difficulty difficulty, string op)
        {
            Difficulty = difficulty;
            Operator = op;
        }
        public static ContestConfig RandomContest(Difficulty difficulty) =>
            new ContestConfig(difficulty, String.Empty);
        public static ContestConfig NormalContest(Difficulty difficulty, string op) =>
            new ContestConfig(difficulty, op);
    }
    public enum ContestType { Normal, Random };
}
