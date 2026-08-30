using System;
using System.Collections.Generic;
using System.Text;

namespace MathGameAcademy
{
    internal class Calculator
    {
        public static int MathCalculation(int[] random, char _operator)
        {
            switch (_operator)
            {
                case '+':
                    return (random[0] + random[1]);
                case '-':
                    return (random[0] - random[1]);
                case '*':
                    return (random[0] * random[1]);
                case '/':
                    if (random[1] == 0)
                    {
                        throw new DivideByZeroException("Cannot divide by zero.");
                    }
                    return (random[0] / random[1]);
                default:
                    throw new ArgumentException("Invalid operator.");
            }
        }
    }
}
