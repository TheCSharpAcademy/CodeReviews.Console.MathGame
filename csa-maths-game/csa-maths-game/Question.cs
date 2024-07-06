using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csa_maths_game
{
    internal class Question
    {
        public int OperandA { get; private set; }
        public int OperandB { get; private set; }
        public int Result { get; private set; }
        public IOperation Operation { get; private set; }
        public Question(int opA, int opB, IOperation op)
        {
            
        }
    }
}
