using System;
using System.Linq;

namespace MathGameV2.Models
{
    internal class GameModel
    {
        internal DateTime TimeStamp { get; set; }
        internal int ScoreOfGame { get; set; }
        internal int AttemptsOfGame { get; set; }
        internal string TypeOfGame { get; set; }
    }
}
