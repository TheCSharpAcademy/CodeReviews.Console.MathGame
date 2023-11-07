using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameV2.Models
{
    internal class GameModel
    {
        internal DateTime timeStamp { get; set; }
        internal int scoreOfGame { get; set; }
        internal int attemptsOfGame { get; set; }
        internal string typeOfGame { get; set; }
    }
}
