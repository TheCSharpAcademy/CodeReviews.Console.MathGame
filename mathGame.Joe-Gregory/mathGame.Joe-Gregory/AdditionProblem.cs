using System;

namespace MyFirstProgram
{
    public class AdditionProblem: Problem
    {
        public AdditionProblem(int difficulty = 1) : base(difficulty)
        {
        }
        public override void GenerateNextProblem()
        {
            base.GenerateNextProblem();
            ProblemText = $"What is the result of {Number1} + {Number2}?";
            Answer = Number1 + Number2;
        }
    }
}
