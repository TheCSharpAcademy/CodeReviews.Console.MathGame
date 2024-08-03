using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Game.Helpers
{
    internal class Problem
    {
        private static Random _random = new();

        internal static int[]? Generate(Types? type)
        {
            int[] numbers = new int[(_random.Next(5) + 1) * 2];

            switch (type)
            {
                case Types.Addition:
                case Types.Multiplication:
                    return AdditionMultiplication(numbers);
                case Types.Subtraction:
                    return Subtraction(numbers);
                case Types.Division:
                    return Division(numbers);
                default:
                    return default;
            }
        }

        internal static bool CheckAnswer(Types type, int x, int y, int answer)
        {
            switch (type)
            {
                case Types.Addition:
                    return answer == x + y;
                case Types.Multiplication:
                    return answer == x * y;
                case Types.Subtraction:
                    return answer == x - y;
                case Types.Division:
                    return answer == x / y;
                default:
                    return default;
            }
        }

        private static int[] AdditionMultiplication(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = _random.Next(100);
            }

            return numbers;
        }

        private static int[] Subtraction(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i += 2)
            {
                numbers[i] = _random.Next(100);
                numbers[i + 1] = _random.Next(numbers[i]);
            }

            return numbers;
        }

        private static int[] Division(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i += 2)
            {
                numbers[i + 1] = _random.Next(100);
                numbers[i] = _random.Next(100) * numbers[i + 1];
            }

            return numbers;
        }
    }
}
