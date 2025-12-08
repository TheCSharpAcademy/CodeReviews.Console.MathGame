using MathGame.Models;

namespace MathGame.Helpers
{
    internal class QuestionSetHelper
    {
        public static QuestionSet GenerateQuestionSet(GameMode gameMode, Random random, int difficulty)
        {
            int result, firstOperand, secondOperand;
            bool haveValidQuestion = false;

            // It may be worth revisiting how we find operands if division does not get 
            // interesting results often
            do
            {
                firstOperand = random.Next((int)Math.Pow(10, difficulty));
                secondOperand = random.Next((int)Math.Pow(10, difficulty));

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
