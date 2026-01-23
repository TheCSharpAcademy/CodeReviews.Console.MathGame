using MathGame.Utils;
using MathGame.Views;

namespace MathGame.Logic
{
    public class Contest
    {
        private readonly int _noQuestions = 5;
        private int points = 0;
        private readonly Question _question;
        public ContestConfig Config { get; init; }
        public Contest(ContestConfig config)
        {
            Config = config;

            IIntervalFactory interval = Config.Difficulty switch
            {
                Difficulty.Easy => new EasyIntervalFactory(),
                Difficulty.Medium => new MediumIntervalFactory(),
                _ => new HardIntervalFactory()
            };

            _question = new Question(new OperationGenerator(interval));
        }
        public int Play()
        {
            for (int i = 0; i < _noQuestions; i++)
            {
                string op = GetOperator();

                int point = _question.Prompt(op);
                points += point;
            }

            return points;
        }
        protected virtual string GetOperator() => Config.Operator; 
    }
}
