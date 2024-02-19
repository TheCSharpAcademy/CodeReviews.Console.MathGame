using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class SavedGame
    {
        public string Username { get; set; }
        public MathOperation Operation { get; set; }
        public Tuple<int, int> Operands { get; set; }
        public bool IsAnswerCorrect { get; set; }

        public SavedGame()
        {
        }

        public SavedGame(string username, MathOperation operation, Tuple<int, int> operands, bool isAnswerCorrect)
        {
            Username = username;
            Operation = operation;
            Operands = operands;
            IsAnswerCorrect = isAnswerCorrect;
        }

        public override string ToString()
        {
            return $"{Username};{Operation};{Operands};{IsAnswerCorrect}";
        }

        public static SavedGame ParseFromFile(string line)
        {
            var data = line.Split(';');
            return new SavedGame
            {
                Username = data[0],
                Operation = (MathOperation)Enum.Parse(typeof(MathOperation), data[1]),
                Operands = ToTuple(data[2]),                
                IsAnswerCorrect = bool.Parse(data[3])
            };
        }

        private static Tuple<int, int> ToTuple(string data)
        {
            var nums = data
                .Trim(['(',')'])
                .Split(',')
                .Select(int.Parse)
                .ToList();
            return Tuple.Create(nums[0], nums[1]);
        }
    }
}
