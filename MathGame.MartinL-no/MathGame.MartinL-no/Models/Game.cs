namespace MathGame.MartinL_no.Models;

internal class Game
{
    internal readonly DateTime StartTime;
    internal readonly GameType Type;
    internal int ValueOne;
    internal int ValueTwo;
    internal int Answer => GetAnswer();
    internal int Attempts;
    internal int Score;
    internal bool IsGameOver;

    internal Game(DateTime startTime, GameType type, int valueOne, int valueTwo)
    {
        StartTime = startTime;
        Type = type;
        ValueOne = valueOne;
        ValueTwo = valueTwo;
        Score = 0;
        IsGameOver = false;
    }

    internal int GetAnswer()
    {
        switch (Type)
        {
            case GameType.Addition:
                return ValueOne + ValueTwo;
            case GameType.Subtraction:
                return ValueOne - ValueTwo;
            case GameType.Multiplication:
                return ValueOne * ValueTwo;
            case GameType.Division:
                return ValueOne / ValueTwo;
            default:
                throw new NotImplementedException();
        }
    }
}