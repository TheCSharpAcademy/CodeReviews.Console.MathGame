using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram.Models;

internal class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType Type { get; set; }
    public GameDifficulty Difficulty { get; set; }
    public double secondsInGame { get; set; }
}
internal enum GameType
{
    Addition,
    Substraction,
    Multiplication,
    Division,
    Random
}
internal enum GameDifficulty
{
    Easy,
    Hard,
    Medium
}