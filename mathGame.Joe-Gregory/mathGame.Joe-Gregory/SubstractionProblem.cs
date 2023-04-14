using System;

namespace MyFirstProgram
{
    internal class SubstractionProblem: Problem
    {
        public SubstractionProblem(int difficulty = 1) : base(difficulty)
        {
        }

        public override void GenerateNextProblem()
        {
            base.GenerateNextProblem();
            if(Number2 > Number1)
            {
                int provisional = Number1;
                Number1 = Number2;
                Number2 = provisional;
            }
            ProblemText = $"What is the result of {Number1} - {Number2}?";
            Answer = Number1 - Number2;
        }
    }
}
