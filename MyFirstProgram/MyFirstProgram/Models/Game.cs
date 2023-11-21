using static System.Formats.Asn1.AsnWriter;
using System.Security.AccessControl;

namespace MyFirstProgram.Models;

internal class Game
{
    /*
    private int _score;

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
    */

    public DateTime Date {  get; set; }
    public int Score { get; set; }
    public GameType Type { get; set; }

    public double TotalSeconds { get; set; }

    public override string ToString()
    {
        return $"{this.Date} - {this.Type}: {this.Score} pts - {this.TotalSeconds} seconds";
    }

}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}
