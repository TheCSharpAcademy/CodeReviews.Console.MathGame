using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstProgram
{
    public class Problem
    {
        public string ProblemText { get; protected set; } = string.Empty;
        public int Number1 { get; protected set; }
        public int Number2 { get; protected set; }
        public int Answer { get; protected set; }
        public int Difficulty { get; private set; }

        public Problem(int difficulty = 1)
        {
            Difficulty = difficulty;
        }
                
        public void GenerateRandomInts()
        {
            Random random = new();

            switch (Difficulty)
            {
                case 1:
                    Number1 = random.Next(1, 10);
                    Number2 = random.Next(1, 10);
                    break;
                case 2:
                    Number1 = random.Next(10, 100);
                    Number2 = random.Next(10, 100);
                    break;
                case 3:
                    Number1 = random.Next(100, 1000);
                    Number2 = random.Next(100, 1000);
                    break;
                case 4:
                    Number1 = random.Next(1000, 10000);
                    Number2 = random.Next(1000, 10000);
                    break;
                default:
                    break;
            }
        }

        public virtual void GenerateNextProblem()
        {
            GenerateRandomInts();
            //ProblemText = $"What is the result of {Number1} [OPERATION] {Number2}?";
            //Answer = Number1 [OPERATION] Number2. For Division and Substraction arrange for positive first.
        }
       
        public bool CheckAnswer(int answer)
        {
            if (answer == Answer) return true;
            else return false;
        }

    }
}
