using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csa_maths_game
{
    internal class Subraction : IOperation
    {
        public int Execute(int operandA, int operandB)
        {
            return operandA - operandB;
        }
        public string GetTextString()
        {
            return "Subraction";
        }
        public char GetSymbolChar()
        {
            return '-';
        }
        public bool IsValidOperands(int operandA, int operandB)
        {
            return operandA > operandB;
        }
    }
}
