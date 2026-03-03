using MathGame.Enums;
using MathGame.Models;

namespace MathGame.Interfaces;

public interface IGameEngine
{
    GameSession Play(GameType game, Difficulty difficulty);
}
