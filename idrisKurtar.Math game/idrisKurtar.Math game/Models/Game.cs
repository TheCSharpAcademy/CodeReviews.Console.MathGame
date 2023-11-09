using System;
using System.Linq;


namespace idrisKurtar.Math_game.Models
{
    internal class Game
    {
        public DateTime Date { get; set; }
        public GameType Type { get; set; }
        public int Score { get; set; }
    }
    internal enum GameType
    {

        Addition,
        Substraciton,
        Multiplication,
        Division

    }
}
