using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class SavedGame
    {
        public string Username { get; set; }
        public string Operation { get; set; }
        public List<int> Operands { get; set; }
        public bool IsAnswerCorrect { get; set; }

        public SavedGame(string username, string operation, List<int> operands, bool isAnswerCorrect)
        {
            Username = username;
            Operation = operation;
            Operands = operands;
            IsAnswerCorrect = isAnswerCorrect;
        }
    }
}
