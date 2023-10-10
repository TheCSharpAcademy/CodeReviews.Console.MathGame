﻿namespace MathGame.gmonestere.Models
{
    internal class Game
    {
        //private int _score;

        //public int Score
        //{
        //    get { return _score; }
        //    set { _score = value; }
        //}
        internal DateTime Date { get; set; }

        internal int Score { get; set; }

        internal GameType Type { get; set; }
    }

    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}

