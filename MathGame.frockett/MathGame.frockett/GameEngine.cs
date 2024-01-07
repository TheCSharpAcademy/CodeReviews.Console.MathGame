using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.frockett
{
    internal class GameEngine
    {
        char[] operations = { '+', '-', '*', '/' };
        string[] gameTitle = { "Addition", "Subtraction", "Multiplication", "Division" };

        internal void MainGameLoop(char operation, int difficulty = 1)
        {
            int index;
            string result;
            int score = 0;

            Random random = new Random();
            int firstNum;
            int secondNum;

            Console.Clear();
            if (operations.Contains(operation))
            {
                index = Array.IndexOf(operations, operation);
                Console.WriteLine($"{gameTitle[index]} Game");
            }
            else
            {
                throw new ArgumentException("Unexpected operator char: " + operation);
            }

            for (int i = 0; i < 5; i++)
            {
                if (operation == '/')
                {
                    do
                    {
                        firstNum = random.Next(1, 10);
                        secondNum = random.Next(1, 10);
                    } while (firstNum % secondNum != 0);
                }
                else
                {
                    firstNum = random.Next(1, 10);
                    secondNum = random.Next(1, 10);
                }

                Console.WriteLine($"\n{firstNum} {operation} {secondNum}");
                result = Console.ReadLine();

                if (int.Parse(result) == PerformCalculation(operation, firstNum, secondNum))
                {
                    Console.WriteLine("Your answer is correct!\n");
                    score++;
                }
                else { Console.WriteLine("Your Answer is incorrect!\n"); }
            }
            Console.WriteLine($"Your final score is {score}");
            Console.ReadLine();

            AuxFunctions.AddToHistory(score, gameTitle[index]);
        }

        internal int PerformCalculation(char operation, int firstNum, int secondNum)
        {
            switch (operation)
            {
                case '+':
                    return firstNum + secondNum;
                case '-':
                    return firstNum - secondNum;
                case '*':
                    return firstNum * secondNum;
                case '/':
                    return firstNum / secondNum;
                default:
                    throw new ArgumentException("Unexpected operator string: " + operation);
            }
        }
    }
}
