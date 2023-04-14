using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    internal class MultiplicationProblem: Problem
    {
        public MultiplicationProblem(int difficulty = 1) : base(difficulty)
        {
        }
        public override void GenerateNextProblem()
        {
            base.GenerateNextProblem();
            ProblemText = $"What is the result of {Number1} * {Number2}?";
            Answer = Number1 * Number2;
        }
    }
}
