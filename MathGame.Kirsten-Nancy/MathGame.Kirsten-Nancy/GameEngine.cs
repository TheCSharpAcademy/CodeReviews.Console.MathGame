using MathGame.Models;

namespace MathGame;
internal class GameEngine
{
    internal (GameType, string, int) AdditionGame(int num1, int num2)
    {
        string game = $"{num1} + {num2}";
        int answer = num1 + num2;
        return (GameType.Addition, game, answer);
    }
    internal (GameType, string, int) SubtractionGame(int num1, int num2)
    {
        string game = $"{num1} - {num2}";
        int answer = num1 - num2;
        return (GameType.Subtraction, game, answer);
    }
    internal (GameType, string, int) MultiplicationGame(int num1, int num2)
    {
        string game = $"{num1} * {num2}";
        int answer = num1 * num2;
        return (GameType.Multiplication, game, answer);
    }
    internal (GameType, string, int) DivisionGame(int num1, int num2)
    {
        string game = $"{num1} / {num2}";
        int answer = num1 / num2;
        return (GameType.Division, game, answer);
    }
}
