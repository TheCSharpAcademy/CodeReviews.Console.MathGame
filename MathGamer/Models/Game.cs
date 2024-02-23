using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGamer.Models;

internal class Game
{
    private int _score;
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }


    public override string ToString()
    {
        return $"{Date} - {Type}: {Score} pts";
    }

    public enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }
}
