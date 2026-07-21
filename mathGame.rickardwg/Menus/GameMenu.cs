using MathGame.Enums;
using MathGame.Helpers;

namespace MathGame.Menus;

internal class GameMenu : IGameMenu
{
    private const string GameModeTitle = "Select Game Mode:";
    private readonly GameMode[] _gameModes = [GameMode.Addition, GameMode.Subtraction, GameMode.Multiplication, GameMode.Division, GameMode.Random];
    private const string DifficultyTitle = "Select Difficulty:";
    private readonly Difficulty[] _difficulties = [Difficulty.Easy, Difficulty.Medium, Difficulty.Hard];
    public GameMode SelectGameMode()
    {
        return ConsoleHelper.Prompt<GameMode>(GameModeTitle, _gameModes);
    }

    public Difficulty SelectDifficulty()
    {
        return ConsoleHelper.Prompt(DifficultyTitle, _difficulties);
    }
}
