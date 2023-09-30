using System;
using System.Collections.Generic;
using System.Linq;

namespace MathGame
{
    internal class ActionHandler
    {
        public static string HandleAddition()
        {
            List<int> numbers = GetRandomInts();
            static int Addition(int a, int b) => a + b;
            return HandleOperation('+', Addition, numbers[0], numbers[1]);
        }
        public static string HandleSubtraction()
        {
            List<int> numbers = GetRandomInts();
            static int Subtraction(int a, int b) => b - a;
            return HandleOperation('-', Subtraction, numbers[0], numbers[1]);
        }
        public static string HandleMultiplication()
        {
            List<int> numbers = GetRandomInts();
            static int Multiplication(int a, int b) => a * b;
            return HandleOperation('*', Multiplication, numbers[0], numbers[1]);
        }
        public static string HandleDivision()
        {
            List<int> numbers = GetRandomDivisableInts();
            static int Division(int a, int b) => b / a;
            return HandleOperation('/', Division, numbers[0], numbers[1]);
        }

        public static List<int> GetRandomInts()
        {
            Random r = new();
            int smInt = r.Next(0, 100);
            int lgInt = r.Next(smInt, 100);
            return new List<int> { smInt, lgInt };
        }
        public static List<int> GetRandomDivisableInts()
        {
            Random r = new();
            int smInt = r.Next(0, 100);
            int lgInt = 0;
            do
            {
                lgInt = r.Next(smInt, 100);
            } while (lgInt % smInt != 0);
            return new List<int> { smInt, lgInt };
        }

        private static string HandleOperation(char operation, Func<int, int, int> action, int a, int b)
        {
            Display.DisplayQuestion(operation, a, b);
            string result = "";
            int tries = 0;
            bool operationEnded;
            do
            {
                operationEnded = true;
                var number = Console.ReadLine();
                try
                {
                    int convertedNumber = Int32.Parse(number);
                    if (convertedNumber == action(a, b))
                    {
                        Display.DisplayCorrectGuess();
                        result = $"{b} {operation} {a} = {convertedNumber}, incorrect tries: {tries}";
                    }
                    else
                    {
                        Display.DisplayIncorrectGuess();
                        operationEnded = false;
                        tries++;
                    }

                }
                catch (Exception ex)
                {
                    if (ex is ArgumentNullException || ex is FormatException)
                    {
                        Display.IncorrectNumberInput();
                        operationEnded = false;
                    }
                    else
                    {
                        throw;
                    }

                }
            } while (!operationEnded);
            return result;
        }
    }
}
