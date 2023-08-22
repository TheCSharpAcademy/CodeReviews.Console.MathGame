using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Game
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Answer { get; set; }
        public int Input { get; set; }
        public string Question { get; set; } = "";
        public SELECTOR Selector { get; set; }
        public bool IsDifficult { get; set; }

        public Game(SELECTOR selector, bool isDifficult)
        {
            Random rand = new();
            Selector = selector;
            IsDifficult = isDifficult;

            X = rand.Next(20);
            Y = rand.Next(20);
            Z = IsDifficult ? rand.Next(20) : 0;

            Action();
        }

        private void Action()
        {
            switch (Selector)
            {
                case SELECTOR.Addition:
                    Console.WriteLine("Addition Game");
                    Question = IsDifficult ? $"{X} + {Y} + {Z}" : $"{X} + {Y}";
                    Answer = IsDifficult ? (X + Y + Z) : (X + Y);
                    break;

                case SELECTOR.Substraction:
                    Console.WriteLine("Substraction Game");
                    Question = IsDifficult ? $"{X} - {Y} - {Z}" : $"{X} - {Y}";
                    Answer = IsDifficult ? (X - Y - Z) : (X - Y);
                    break;

                case SELECTOR.Multiplication:
                    Console.WriteLine("Multiplication Game");
                    Question = IsDifficult ? $"{X} * {Y} * {Z}" : $"{X} * {Y}";
                    Answer = IsDifficult ? (X * Y * Z) : (X * Y);
                    break;

                case SELECTOR.Division:
                    var _division_numbers = GetDivisionNumbers(X, Y);
                    var x_div = _division_numbers.x;
                    var y_div = _division_numbers.y;

                    Console.WriteLine("Division Game");
                    Question = $"{x_div} / {y_div}";
                    Answer = x_div / y_div;
                    break;
            }
        }

        public (string question, int answer, int input, string resultMessage, string resultType) GetResult()
        {
            string ResultMessage = (Answer == Input) ? "Your answer was correct!" : "Your answer was wrong!";
            string ResultType = (Answer == Input) ? "CORRECT" : "WRONG";
            return (Question, Answer, Input, ResultMessage, ResultType);
        }
        private (int x, int y) GetDivisionNumbers(int x, int y)
        {
            Random rand = new();
            int MAX_NUM = IsDifficult? 1000 : 100;

            while (x % y != 0)
            {
                x = rand.Next(1, MAX_NUM);
                y = rand.Next(1, MAX_NUM);
            }
            return (x, y);
        }
    }
}
