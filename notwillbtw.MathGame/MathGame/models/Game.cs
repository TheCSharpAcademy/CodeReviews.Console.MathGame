﻿namespace MathGame.models;

internal class Game
{
    public TimeSpan Time { get; set; }

    public DateTime Date { get; set; }

    public int Score { get; set; }

    public GameType Type { get; set; }
}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random,
}
