using MathGameLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGameLib
{
    public class MathExpression
    {
        public int FirstOperand { get; set; }
        public int SecondOperand { get; set; }
        public char Operation { get; set; }
        public int? Answer { get; set; }
        public long answerDuration { get; set; }
        public string Difficulty { get; set; }
        public MathExpression(int firstOperand, int secondOperand, char operationMode )
        {
            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operation = operationMode;
        }
    }
}
