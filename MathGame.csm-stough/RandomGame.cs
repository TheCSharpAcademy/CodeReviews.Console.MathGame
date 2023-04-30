using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class RandomGame : BaseGame
    {

        private enum Operator
        {
            ADD = '+', SUB = '-', MUL = '*', DIV = '/'
        }
        private Operator currentOperator;

        public RandomGame() : base(GameSettings.GetRoundsLength(), '?', "Random")
        {

        }

        protected override Round CreateRound()
        {
            currentOperator = GetRandomOperator();
            this.operation = (char)currentOperator;
            return base.CreateRound();
        }

        protected override bool Evaluate(Round round, int answer)
        {
            switch(currentOperator) {
                case Operator.ADD:
                    return round.left + round.right == answer;
                case Operator.SUB:
                    return round.left - round.right == answer;
                case Operator.MUL:
                    return round.left * round.right == answer;
                case Operator.DIV:
                    return round.left / round.right == answer;
            }
            return false;
        }

        private Operator GetRandomOperator()
        {
            Array ops = Enum.GetValues(typeof(Operator));
            return (Operator)ops.GetValue(rand.Next(ops.Length));
        }
    }
}
