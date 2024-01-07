using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.frockett.Models;

internal class Game
{
    /*private int _score;
    public int Score
    { 
        get { return _score; } 
        set { _score = value; }
    } 
    */

    public DateTime Date { get; set; }
    public int Score { get; set; }
    public string Type { get; set; }
    public Difficulty Difficulty { get; set; }
}

internal struct Level
{
    public int maximum { get; set; }
    public Difficulty difficulty { get; set; }
}

internal enum Difficulty
{
    Easy,
    Medium,
    Hard,
    Insane,
}
