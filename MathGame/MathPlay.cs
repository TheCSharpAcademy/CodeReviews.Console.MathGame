using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MathGame
{
    internal class MathPlay
    {
        public static Func<int, int, int> GetMathOp(string operation) => operation switch
        {
            "a" => (n1, n2) => n1 + n2,
            "d" => (n1, n2) => n1 / n2,
            "m" => (n1, n2) => n1 * n2,
            "s" => (n1, n2) => n1 - n2,
            _ => throw new ArgumentException("Mathematical operation not recognized."),
        };

        public static MathOperation ToMathOpEnum(string operation) => operation switch
        {
            "a" => MathOperation.Addition,
            "d" => MathOperation.Division,
            "m" => MathOperation.Multiplication,
            "s" => MathOperation.Subtraction,
            _ => throw new ArgumentException("Mathematical operation not recognized."),
        };

        public static string GetMathOpPhrase(string operation) => operation switch
        {
            "a" => "plus",
            "d" => "divided by",
            "m" => "times",
            "s" => "minus",
            _ => throw new ArgumentException("Mathematical operation not recognized."),
        };

        public static void PlayGame(string username, string selection)
        {
            var currentGame = new SavedGame { Username = username };
            currentGame.Operation = ToMathOpEnum(selection);
            Func<int, int, int> operation = GetMathOp(selection);

            var n1 = new Random().Next(2, 101);
            var n2 = new Random().Next(1, 101);

            if (currentGame.Operation is MathOperation.Division)
            {
                var possibleDivisors = Enumerable.Range(1, n1)
                    .Where(n => n1 % n == 0 && n1 != n)
                    .ToList()
                    ;
                n2 = possibleDivisors[new Random().Next(possibleDivisors.Count())];
            }

            currentGame.Operands = Tuple.Create(n1, n2);

            Console.WriteLine();
            Console.WriteLine($"What is {n1} {GetMathOpPhrase(selection)} {n2}?");

            var answer = string.Empty;

            do
            {
                Console.Write("Your answer: ");
                answer = Console.ReadLine();
                Console.WriteLine();
            } while (!int.TryParse(answer, out _));

            if (int.Parse(answer) == operation(n1, n2))
            {
                Console.WriteLine("Congratulations! That's correct.");
                currentGame.IsAnswerCorrect = true;
            }
            else
            {
                Console.WriteLine($"Sorry, that's wrong. The correct answer is {operation(n1, n2)}");
            }

            FileIO.Save(currentGame);
        }
    }
}
