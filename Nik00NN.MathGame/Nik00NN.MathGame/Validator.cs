using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nik00NN.MathGame
{
    public class Validator
    {
        private bool ValidateDifficulty(int a)
        {
            if (a <= 3 && a >= 1)
            {
                return true;
            }
            else
                return false;
        }
        public int SetDifficultyLevel()
        {
            Console.WriteLine(@"Set your level of difficulty(1-3):
                    1-Easy
                    2-Medium
                    3-Hard");
            int difficulty;
            while (!int.TryParse(Console.ReadLine(), out difficulty) || !ValidateDifficulty(difficulty))
            {
                Console.WriteLine("value must be between 1 and 3");
                Console.WriteLine("Enter another value:");
            }
            return difficulty;
        }
    }
}
