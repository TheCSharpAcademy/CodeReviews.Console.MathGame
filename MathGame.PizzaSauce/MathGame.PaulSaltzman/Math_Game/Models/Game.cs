using System;
using System.Linq;


namespace Math_Game.Models;

internal class Game
{


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
