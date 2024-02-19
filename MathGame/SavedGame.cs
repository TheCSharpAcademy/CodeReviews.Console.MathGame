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
        public MathOperation Operation { get; set; }
        public List<int> Operands { get; set; }
        public bool IsAnswerCorrect { get; set; }

        public SavedGame()
        {
        }

        public SavedGame(string username, MathOperation operation, List<int> operands, bool isAnswerCorrect)
        {
            Username = username;
            Operation = operation;
            Operands = operands;
            IsAnswerCorrect = isAnswerCorrect;
        }

        public override string ToString()
        {
            return $"{Username};{Operation};{String.Join(',', Operands)};{IsAnswerCorrect}";
        }

        public static SavedGame ParseFromFile(string line)
        {
            var data = line.Split(';');
            return new SavedGame
            {
                Username = data[0],
                Operation = (MathOperation)Enum.Parse(typeof(MathOperation), data[1]),
                Operands = data[2]
                .Split(',')
                .Select(int.Parse)
                .ToList(),
                IsAnswerCorrect = bool.Parse(data[3])
            };
        }
    }
}
