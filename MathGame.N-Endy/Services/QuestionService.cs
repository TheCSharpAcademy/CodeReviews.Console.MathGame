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

        public Question GetQuestion(string userChoice)
        {
            Question question = null;
            switch (userChoice)
            {
                case "1":
                    question = GenerateQuestion("+");
                    break;
                case "2":
                    question = GenerateQuestion("-");
                    break;
                case "3":
                    question = GenerateQuestion("*");
                    break;
                case "4":
                    question = GenerateQuestion("/");
                    break;
            }

            return question;
        }

        public int CheckAnswer()
        {
            // Construct the arithmetic expression
            string expression = $"{_question.Operand1} {_question.Operation} {_question.Operand2}";

            // Use System.Data.DataTable.Compute to evaluate the expression
            object result = new System.Data.DataTable().Compute(expression, null);

            // Check if the result is a valid integer
            int parsedResult;
            if (result != null && int.TryParse(result.ToString(), out parsedResult))
            {
                return parsedResult;
            }
            else
            {
                // Handle the case where the expression couldn't be evaluated or the result is not a valid integer
                throw new InvalidOperationException("Failed to evaluate the arithmetic expression.");
            }
        }
    }
}