using MathGame.Models;

namespace MathGame.Helpers
{
    internal class QuestionSetHelper
    {
        // TODO: Should take difficulty level into account
        // TODO: Make sure to validate division operations (result in integer division, no zero divisor, etc.,)
        public static QuestionSet GenerateQuestionSet(GameMode gameMode, Random random)
        {
            int result, firstOperand, secondOperand;
            bool haveValidQuestion = false;
            do
            {
                firstOperand = random.Next(50);
                secondOperand = random.Next(50);

                // Most questions are valid - the only strong consideration is for DIVISION
                haveValidQuestion = IsValidQuestion(firstOperand, secondOperand, gameMode);

            } while (!haveValidQuestion);

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

        static bool IsValidQuestion(int firstOperand, int secondOperand,  GameMode gameMode)
        {
            // Any and all operands are valid for ADDITION, SUBTRACTION, MULTIPLICATION
            switch (gameMode)
            {
                case GameMode.ADDITION:
                case GameMode.SUBTRACTION:
                case GameMode.MULTIPLICATION:
                    return true;
                case GameMode.DIVISION:

                    // Any valid integer division will necessarily have no modulus remainder
                    return (secondOperand != 0 && (firstOperand %  secondOperand == 0));
                default:
                    throw new System.NotImplementedException("Unsupported Game Mode provided!");
            }
        }
    }
}
