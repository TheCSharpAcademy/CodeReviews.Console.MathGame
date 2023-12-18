using MathGameLib.Enums;
using System.Diagnostics;

namespace MathGameLib
{
    public class MathGame
    {
        public TimeOnly GameStartedAt { get; set; }
        public TimeOnly GameEndedAt { get; set; }
        public int QuestionCount { get; set; }
        public DIFFICULTY Difficulty { get; set; }
        public MODE Mode { get; set; }
        public List<MathExpression> MathExpressions { get; set; }
        public int Answer { get; set; }
        public MathGame()
        {
            MathExpressions = new List<MathExpression>();
        }

        public int getRandomNo()
        {
            int result;
            switch (Difficulty)
            {
                case DIFFICULTY.EASY:
                    result = new Random().Next(1, 10);
                    break;
                case DIFFICULTY.MEDIUM:
                    result = new Random().Next(1, 30);
                    break;
                case DIFFICULTY.HARD:
                    result = new Random().Next(1, 50);
                    break;
                default:
                    result = new Random().Next(1, 100);
                    break;
            }
            return result;
        }
        public MathExpression getQuestion()
        {
            MathExpression output;

            switch (Mode)
            {
                case MODE.ADDITION:
                    output = new MathExpression(getRandomNo(), getRandomNo(), '+');
                    break;
                case MODE.SUBTRACTION:
                    int firstOperand = getRandomNo();
                    int secondOperand = getRandomNo();
                    int temp;
                    if (firstOperand < secondOperand)
                    {
                        temp = firstOperand;
                        firstOperand = secondOperand;
                        secondOperand = temp;
                    }
                    output = new MathExpression(firstOperand, secondOperand, '-');
                    break;
                case MODE.MULTIPLICATION:
                    output = new MathExpression(getRandomNo(), getRandomNo(), '*');
                    break;
                case MODE.DIVISION:
                    firstOperand = getRandomNo();
                    secondOperand = getRandomNo();
                    output = new MathExpression(firstOperand * secondOperand, firstOperand, '/');
                    break;
                default:
                    Random random = new Random();
                    int rand = random.Next(1, 5);
                    if (rand == 1)
                    {
                        output = new MathExpression(getRandomNo(), getRandomNo(), '+');

                    }
                    else if (rand == 2)
                    {
                        firstOperand = getRandomNo();
                        secondOperand = getRandomNo();
                        if (firstOperand < secondOperand)
                        {
                            temp = firstOperand;
                            firstOperand = secondOperand;
                            secondOperand = temp;
                        }
                        output = new MathExpression(firstOperand, secondOperand, '-');
                    }
                    else if (rand == 3)
                    {
                        output = new MathExpression(getRandomNo(), getRandomNo(), '*');
                    }
                    else
                    {
                        int fOperand = getRandomNo();
                        int sOperand = getRandomNo();
                        output = new MathExpression(fOperand * sOperand, fOperand, '/');
                    }
                    break;
            }

            switch (Difficulty)
            {

                case DIFFICULTY.EASY:
                    output.Difficulty = "EASY";
                    break;
                case DIFFICULTY.MEDIUM:
                    output.Difficulty = "MEDIUM";
                    break;
                case DIFFICULTY.HARD:
                    output.Difficulty = "HARD";
                    break;
                case DIFFICULTY.EXTREME:
                    output.Difficulty = "EXTREME";
                    break;

            }
            MathExpressions.Add(output);
            return output;
        }
    }
}