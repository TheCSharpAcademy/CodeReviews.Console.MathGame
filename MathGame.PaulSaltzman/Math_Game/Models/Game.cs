using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Game.Models;

internal class Game
{
//    private int _score;

//    public int Score
//    {
//        get { return _score; }
//        set { _score = value; }
//    }


    public int Score { get; set; }
    public DateTime Date { get; set; }
    public GameType Type { get; set; }
    public DifficultyLevel Level { get; set; }

    internal enum GameType
    {
        Addition,  //0
        Subtraction, //1
        Multiplication, //2
        Division //3
    }

    internal enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }

}
