using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7vanael.MathGame;

internal class Game
{
    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }

}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}
