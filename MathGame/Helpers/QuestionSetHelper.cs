using MathGame.Models;

namespace MathGame.Helpers
{
    internal class QuestionSetHelper
    {
        // TODO: Should take difficulty level into account
        public static QuestionSet GenerateQuestionSet(GameMode gameMode, Random random)
        {
            int firstOperand = random.Next();
            int secondOperand = random.Next();

            int result;

            switch (gameMode)
            {
                case GameMode.ADDITION:
                    result = firstOperand + secondOperand;
                    break;
                case GameMode.SUBTRACTION:
                    result = firstOperand - secondOperand;
                    break;
                case GameMode.MULTIPLICATION:
                    result = firstOperand * secondOperand;
                    break;
                case GameMode.DIVISION:
                    result = firstOperand / secondOperand;
                    break;
                default:
                    throw new System.NotImplementedException("Unsupported Game Mode provided!");
            }

            return new(FormatQuestion(gameMode, firstOperand, secondOperand), result);
        }

        static string FormatQuestion(GameMode gameMode, int firstOperand, int secondOperand)
        {
            return $"{firstOperand} {GameModeExtensions.ToSymbol(gameMode)} {secondOperand} = ?"; 
        }
    }
}
