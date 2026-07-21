using MathGame.Enums;
using MathGame.Models;

namespace MathGame.Services;

internal interface IQuestionService
{
    MathQuestion GenerateQuestion(GameMode gameMode, Difficulty difficulty);
}
