using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal abstract class Operation
    {
        protected int FirstOperand { get; init; }
        protected int SecondOperand { get; init; }

        public Operation(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    FirstOperand = GlobalRandom.Instance.Next(0, 11);
                    SecondOperand = GlobalRandom.Instance.Next(0, 11);
                    break;
                case Difficulty.Medium:
                    FirstOperand = GlobalRandom.Instance.Next(10, 101);
                    SecondOperand = GlobalRandom.Instance.Next(10, 101);
                    break;
                case Difficulty.Hard:
                    FirstOperand = GlobalRandom.Instance.Next(100, 201);
                    SecondOperand = GlobalRandom.Instance.Next(100, 201);
                    break;
                default:
                    throw new InvalidEnumArgumentException($"The difficulty {Enum.GetName(typeof(Difficulty), difficulty)} isn't valid");
            }
        }

        public abstract int PerformOperation();
    }
}
