using MathGame.Enums;

namespace MathGame.Views;

internal interface IGameView
{
    void DisplayGame(GameMode gameMode, Difficulty difficulty);
}
