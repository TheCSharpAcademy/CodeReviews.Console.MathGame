using MathGame.N_Endy.GameEntities;
using MathGame.N_Endy.GameCore;

namespace MathGame.N_Endy.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly Random _random;
        private readonly Question _question;

        public QuestionService(Question question)
        {
            _random = new Random();
            _question = question;
        }

        public Question GenerateQuestion(string operation)
        {
            _question.Operation = operation;

            if (operation == "/")
            {
                do
                {
                    _question.Operand1 = _random.Next(1, 99);
                    _question.Operand2 = _random.Next(1, 99);
                } while (_question.Operand1 % _question.Operand2 != 0);
            }
            else
            {
                _question.Operand1 = _random.Next(1, 11);
                _question.Operand2 = _random.Next(1, 11);
            }

            return _question;
        }

        public int CheckAnswer()
        {
            string expression = $"{_question.Operand1}{_question.Operation}{_question.Operand2}";
            return (int)new System.Data.DataTable().Compute(expression, null);
        }
    }
}