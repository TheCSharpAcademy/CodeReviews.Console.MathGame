using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class MultiplicationGame : BaseGame
    {
        public MultiplicationGame() : base(GameSettings.GetRoundsLength(), '*', "Multiplication")
        {

        }

        protected override bool Evaluate(Round round, int answer)
        {
            return round.left * round.right == answer;
        }
    }
}
