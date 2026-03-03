using MathGame.Enums;
using MathGame.Models;

namespace MathGame.Interfaces;

public interface IQuestionGenerator
{
    MathQuestion Generate(GameType game, DifficultySettings difficulty);
}
