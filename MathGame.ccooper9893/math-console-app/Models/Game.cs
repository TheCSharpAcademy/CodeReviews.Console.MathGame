﻿
namespace math_console_app;

internal class Game
{
    private int _score;

    public DateTime Date {  get; set; }

    public int Score { get; set; }

    public GameType Type { get; set; }

    public string Difficulty { get; set; }

}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}

