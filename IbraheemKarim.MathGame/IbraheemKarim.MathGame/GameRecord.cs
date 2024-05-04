using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbraheemKarim.MathGame
{
    internal class GameRecord
    {
        public DateTime Date { get; set; }

        public int Score { get; set; }

        public GameType Type { get; set; }


        public override string ToString()
        {
            return $"{Date} - {Type}: {Score}pts";
        }
    }
}
