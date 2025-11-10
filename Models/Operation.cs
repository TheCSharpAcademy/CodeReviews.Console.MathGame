using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static MathGame.Enums;

namespace MathGame.Models
{
    internal class Operation
    {
        private Operator _operator { get; set; }
        private int number1 { get; set; }
        private int number2 { get; set; }
        public int result { get; set; }
        Difficulty difficulty { get; set; }

        Random rnd = new Random();
        public string displayOperation => $"{number1} {operatorSymbols[_operator]} {number2}";

        public Operation(Difficulty diff, Operator op)
        {
            difficulty = diff;
            _operator = op;
            GenerateOperation();
        }

        private static readonly Dictionary<Operator, string> operatorSymbols = new()
        {
            { Operator.Add, "+" },
            { Operator.Subtract, "-" },
            { Operator.Multiply, "x" },
            { Operator.Division, "/" },
        };

        private void GenerateOperation()
        {
            switch (_operator)
            {
                case Operator.Add:
                    (number1, number2) = GenerateAddition();
                    result = number1 + number2;
                    break;
                case Operator.Subtract:
                    (number1, number2) = GenerateSubtraction();
                    result = number1 - number2;
                    break;
                case Operator.Multiply:
                    (number1, number2) = GenerateMultiplication();
                    result = number1 * number2;
                    break;
                case Operator.Division:
                    var numbers = GenerateDivision();
                    number1 = numbers.a * numbers.b;
                    number2 = numbers.a;
                    result = numbers.b;
                    break;
            }
        }

        public (int a, int b) GenerateAddition()
        {
            return difficulty switch
            {
                Difficulty.Easy => (rnd.Next(1, 20), rnd.Next(1, 20)),
                Difficulty.Medium => (rnd.Next(10, 50), rnd.Next(10, 50)),
                Difficulty.Hard => (rnd.Next(50, 200), rnd.Next(50, 200)),
                _ => (rnd.Next(1, 20), rnd.Next(1, 20)),
            };
        }

        public (int a, int b) GenerateSubtraction()
        {
            return difficulty switch
            {
                Difficulty.Easy => (rnd.Next(10, 20), rnd.Next(1, 10)),
                Difficulty.Medium => (rnd.Next(50, 100), rnd.Next(10, 50)),
                Difficulty.Hard => (rnd.Next(100, 200), rnd.Next(10, 100)),
                _ => (rnd.Next(10, 20), rnd.Next(1, 10)),
            };
        }

        public (int a, int b) GenerateMultiplication()
        {
            return difficulty switch
            {
                Difficulty.Easy => (rnd.Next(1, 6), rnd.Next(1, 6)),
                Difficulty.Medium => (rnd.Next(3, 12), rnd.Next(3, 12)),
                Difficulty.Hard => (rnd.Next(6, 20), rnd.Next(6, 20)),
                _ => (rnd.Next(1, 6), rnd.Next(1, 6)),
            };
        }

        public (int a, int b) GenerateDivision()
        {
            return difficulty switch
            {
                Difficulty.Easy => (rnd.Next(2, 10), rnd.Next(2, 10)),
                Difficulty.Medium => (rnd.Next(2, 20), rnd.Next(2, 20)),
                Difficulty.Hard => (rnd.Next(6, 25), rnd.Next(6, 25)),
                _ => (rnd.Next(2, 10), rnd.Next(2, 10)),
            };
        }
    }
}
