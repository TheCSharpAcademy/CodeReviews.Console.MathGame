using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static MathGame.Enums;

namespace MathGame.Models
{
    internal class RandomGame : Game, IGame
    {
        public RandomGame(Difficulty difficulty, IUserInterface ui)
            : base(difficulty, ui) { }

        private Operator _operator { get; set; }

        Random rnd = new Random();

        public bool PlayGame()
        {
            int round = 1;
            score = 0;

            startTime = DateTime.Now;
            while (round <= rounds)
            {
                Operation operation = new Operation(difficulty, getRandomOperator());

                var number = _userInterface.PromptInt(operation.displayOperation, "yellow");
                if (number == operation.result)
                {
                    score++;
                    _userInterface.WriteSuccess();
                }
                else
                {
                    _userInterface.WriteError();
                }

                round++;
            }

            endTime = DateTime.Now;
            DisplayResult();

            MockDatabase.GameHistory.Add(this);
            return _userInterface.Confirm("Play again?");
        }

        private Operator getRandomOperator()
        {
            int randomOperator = rnd.Next(1, Enum.GetValues<Operator>().Length);
            return randomOperator switch
            {
                0 => Operator.Add,
                1 => Operator.Subtract,
                2 => Operator.Multiply,
                3 => Operator.Division,
                _ => Operator.Add,
            };
        }
    }
}
