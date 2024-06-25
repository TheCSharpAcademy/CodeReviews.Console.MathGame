// -------------------------------------------------------------------------------------------------
// Console.MathGame.cjc_sweatbox.Models.DifficultySettings
// -------------------------------------------------------------------------------------------------
// Configuration settings for the allowed game types.
// -------------------------------------------------------------------------------------------------
using Console.MathGame.cjc_sweatbox.Enums;

namespace Console.MathGame.cjc_sweatbox.Models
{
    public class DifficultySettings
    {
        #region Constructors

        public DifficultySettings(GameDifficulty gameDifficulty, int questionCount)
        {
            switch (gameDifficulty)
            {
                case GameDifficulty.Easy:
                    AdditionNumberMin = 1;
                    AdditionNumberMax = 9;
                    SubtractionNumberMin = 1;
                    SubtractionNumberMax = 9;
                    MultiplicationNumberMin = 1;
                    MultiplicationNumberMax = 9;
                    DivisionNumberMin = 1;
                    DivisionNumberMax = 9;
                    break;
                case GameDifficulty.Normal:
                    AdditionNumberMin = 10;
                    AdditionNumberMax = 99;
                    SubtractionNumberMin = 10;
                    SubtractionNumberMax = 99;
                    MultiplicationNumberMin = 10;
                    MultiplicationNumberMax = 99;
                    DivisionNumberMin = 2;
                    DivisionNumberMax = 20;
                    break;
                case GameDifficulty.Hard:
                    AdditionNumberMin = 20;
                    AdditionNumberMax = 999;
                    SubtractionNumberMin = 20;
                    SubtractionNumberMax = 999;
                    MultiplicationNumberMin = 20;
                    MultiplicationNumberMax = 999;
                    DivisionNumberMin = 3;
                    DivisionNumberMax = 100;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameDifficulty));
            }

            QuestionCount = questionCount;
        }

        #endregion
        #region Properties

        public int QuestionCount { get; }

        public int AdditionNumberMin { get; }

        public int AdditionNumberMax { get; }

        public int SubtractionNumberMin { get; }

        public int SubtractionNumberMax { get; }

        public int MultiplicationNumberMin { get; }

        public int MultiplicationNumberMax { get; }

        public int DivisionNumberMin { get; }

        public int DivisionNumberMax { get; }

        #endregion
    }
}