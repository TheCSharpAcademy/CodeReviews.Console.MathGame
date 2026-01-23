using MathGame.Logic;

namespace MathGame.Views
{
    public class ContestConfigView
    {
        private readonly OperationMenu _menuOperation = new();
        private readonly DifficultyMenu _difficultyView = new();
        private readonly ContestTypeMenu _contestType = new();
        public Contest GetContest()
        {
            Difficulty difficulty = _difficultyView.GetDifficulty();
            ContestType type = _contestType.GetGameType();
            ContestConfig config;
            Contest contest;

            if (type.Equals(Logic.ContestType.Random))
            {
                config = ContestConfig.RandomContest(difficulty);
                contest = new ContestRandom(config);
            } else
            {
                string operation = _menuOperation.GetOperation();
                config = ContestConfig.NormalContest(difficulty, operation);
                contest = new Contest(config);
            }

            return contest;
        }
    }
}
