using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    internal class DivisionProblem : Problem
    {
        public DivisionProblem(int difficulty = 1) : base(difficulty)
        {
        }
        public override void GenerateNextProblem()
        {
            base.GenerateNextProblem();
            if (Number2 > Number1)
            {
                int provisional = Number1;
                Number1 = Number2;
                Number2 = provisional;
            }
            int multiplication = Number1 * Number2;
            ProblemText = $"What is the result of {multiplication} / {Number2}?";
            Answer = Number1;
        }
    }
}
