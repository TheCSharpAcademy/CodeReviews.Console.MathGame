using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using static MathGame.Enums;

namespace MathGame.Models
{
    internal class TrainingGame : Game, IGame
    {
        private Operator _operator { get; set; }

        public TrainingGame(Difficulty difficulty, Operator op, IUserInterface ui)
            : base(difficulty, ui)
        {
            _operator = op;
        }

        public bool PlayGame()
        {
            int round = 1;
            score = 0;

            startTime = DateTime.Now;
            while (round <= rounds)
            {
                Operation operation = new Operation(difficulty, _operator);

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
    }
}
