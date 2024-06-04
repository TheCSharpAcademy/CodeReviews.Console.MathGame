using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.kjanos89
{
    public class MultiplicationGame
    {
        int c = 0;
        Start startObject = new Start();
        public void Result()
        {
            Random numberGen = new Random();
            int a = numberGen.Next(1, 101);
            int b = numberGen.Next(1, 101);
            Console.Clear();
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine($"You currently have {GameData.Points} amount of points.");
            Console.WriteLine("Your choice was Multiplication Game mode. The rules are simple: multiply the numbers");
            Console.WriteLine($"First number is {a}");
            Console.WriteLine($"Second number is {b}");
            Console.WriteLine("Pressing B will return you to the main menu.");
            Console.WriteLine("__________________________________________________________________");
            Validation(a, b);
        }

        public void Validation(int a, int b)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "b")
            {
                startObject.StartMenu();
            }
            else if (Int32.TryParse(input, out c))
            {
                if (c == a*b)
                {
                    Console.WriteLine("Nice one! You just earned one point for Gryffindor!");
                    Console.WriteLine("Starting again in 3 seconds!");
                    Thread.Sleep(3000);
                    GameData.Points++;
                    Result();
                }
                else
                {
                    Console.WriteLine("Not exactly, try again!");
                    Validation(a, b);
                }
            }
            else
            {
                Console.WriteLine("Not a number, try again!");
                Validation(a, b);
            }
        }
    }
}
