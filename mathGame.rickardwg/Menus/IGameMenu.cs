using MathGame.Enums;

namespace MathGame.Menus;

internal interface IGameMenu
{
    GameMode SelectGameMode();
    Difficulty SelectDifficulty();
}
