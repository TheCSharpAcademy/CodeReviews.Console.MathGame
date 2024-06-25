// -------------------------------------------------------------------------------------------------
// Console.MathGame.cjc_sweatbox.Logic.QuestionEngine
// -------------------------------------------------------------------------------------------------
// Question related business logic.
// Generates questions for all game types configured by difficulty and amount of questions.
// -------------------------------------------------------------------------------------------------
using Console.MathGame.cjc_sweatbox.Enums;
using Console.MathGame.cjc_sweatbox.Models;

namespace Console.MathGame.cjc_sweatbox.Logic
{
    public static class QuestionEngine
    {
        #region Methods: Public Static

        public static List<Question> GenerateQuestions(GameType gameType, GameDifficulty gameDifficulty, int questionCount)
        {
            var settings = new DifficultySettings(gameDifficulty, questionCount);

            return gameType switch
            {
                GameType.Addition => GenerateAdditionQuestions(settings),
                GameType.Subtraction => GenerateSubtractionQuestions(settings),
                GameType.Multiplication => GenerateMultiplicationQuestions(settings),
                GameType.Division => GenerateDivisionQuestions(settings),
                GameType.Random => GenerateRandomQuestions(settings),
                _ => throw new ArgumentOutOfRangeException(nameof(gameType))
            };
        }

        #endregion
        #region Methods: Private Static

        private static List<Question> GenerateAdditionQuestions(DifficultySettings settings)
        {
            List<Question> result = [];

            for (int i = 0; i < settings.QuestionCount; i++)
            {
                result.Add(GenerateAdditionQuestion(settings, i));
            }

            return result;
        }

        private static Question GenerateAdditionQuestion(DifficultySettings settings, int index)
        {
            Question result;

            var firstNumber = Random.Shared.Next(settings.AdditionNumberMin, settings.AdditionNumberMax + 1);
            var secondNumber = Random.Shared.Next(settings.AdditionNumberMin, settings.AdditionNumberMax + 1);

            result = new Question()
            {
                Id = index + 1,
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                Type = GameType.Addition
            };

            return result;
        }

        private static List<Question> GenerateSubtractionQuestions(DifficultySettings settings)
        {
            List<Question> result = [];

            for (int i = 0; i < settings.QuestionCount; i++)
            {
                result.Add(GenerateSubtractionQuestion(settings, i));
            }

            return result;
        }

        private static Question GenerateSubtractionQuestion(DifficultySettings settings, int index)
        {
            Question result;

            var firstNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax + 1);
            var secondNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax + 1);

            while (firstNumber < secondNumber)
            {
                firstNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax + 1);
                secondNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax + 1);
            }

            result = new Question()
            {
                Id = index + 1,
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                Type = GameType.Subtraction
            };

            return result;
        }

        private static List<Question> GenerateMultiplicationQuestions(DifficultySettings settings)
        {
            List<Question> result = [];

            for (int i = 0; i < settings.QuestionCount; i++)
            {
                result.Add(GenerateMultiplicationQuestion(settings, i));
            }

            return result;
        }

        private static Question GenerateMultiplicationQuestion(DifficultySettings settings, int index)
        {
            Question result;

            var firstNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax + 1);
            var secondNumber = Random.Shared.Next(settings.SubtractionNumberMin, settings.SubtractionNumberMax + 1);

            result = new Question()
            {
                Id = index + 1,
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                Type = GameType.Multiplication
            };

            return result;
        }

        private static List<Question> GenerateDivisionQuestions(DifficultySettings settings)
        {
            List<Question> result = [];

            for (int i = 0; i < settings.QuestionCount; i++)
            {
                result.Add(GenerateDivisionQuestion(settings, i));
            }

            return result;
        }

        private static Question GenerateDivisionQuestion(DifficultySettings settings, int index)
        {
            Question result;

            var firstNumber = Random.Shared.Next(settings.DivisionNumberMin, settings.DivisionNumberMax + 1);
            var secondNumber = Random.Shared.Next(settings.DivisionNumberMin, settings.DivisionNumberMax + 1);

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = Random.Shared.Next(settings.DivisionNumberMin, settings.DivisionNumberMax + 1);
                secondNumber = Random.Shared.Next(settings.DivisionNumberMin, settings.DivisionNumberMax + 1);
            }
            result = new Question()
            {
                Id = index + 1,
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                Type = GameType.Division
            };

            return result;
        }

        private static List<Question> GenerateRandomQuestions(DifficultySettings settings)
        {
            List<Question> result = [];

            for (int i = 0; i < settings.QuestionCount; i++)
            {
                var gameType = Random.Shared.Next(0, 4);

                switch (gameType)
                {
                    case 0:
                        result.Add(GenerateAdditionQuestion(settings, i));
                        break;
                    case 1:
                        result.Add(GenerateSubtractionQuestion(settings, i));
                        break;
                    case 2:
                        result.Add(GenerateMultiplicationQuestion(settings, i));
                        break;
                    case 3:
                        result.Add(GenerateDivisionQuestion(settings, i));
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        #endregion
    }
}
