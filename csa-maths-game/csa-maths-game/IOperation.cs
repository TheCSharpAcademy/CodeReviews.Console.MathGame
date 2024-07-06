using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csa_maths_game
{
    public interface IOperation
    {
        public int Execute(int operandA, int operandB);
        public string GetTextString();
        public char GetSymbolChar();
        public bool IsValidOperands(int operandA, int operandB);
    }
}
