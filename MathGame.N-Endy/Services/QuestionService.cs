using MathGame.N_Endy.GameEntities;
using MathGame.N_Endy.GameCore;

namespace MathGame.N_Endy.Services
{
    public class QuestionService : IQuestionService
    {
        public Question GenerateQuestion(Operation operation)
        {
            return new Question();
        }
    }
}