namespace C_Sharp_Academy.Game;

using ArithmeticOperations;
using Enums;

public interface IGame
{
    void StartGame<T>() where T : IArithmeticOperation, new();
    void QuitGame();
    void ShowPreviousResults();
    Difficulty SelectDifficulty();
}