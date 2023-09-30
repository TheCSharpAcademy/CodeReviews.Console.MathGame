using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Display
    {
        private string Name { get; set; }
        public Display() {
            Name = GetName();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"Hello {Name}, please choose one of the 4 basic operations to try or choose to display results from previous games.");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Display results");
        }

        public static void DisplayResults(List<string> results)
        {
            Console.WriteLine("Results:");
            results.ForEach(i => Console.WriteLine(i));
        }

        public static string GetName()
        {
            Console.WriteLine("Please enter your name.");
            var name = Console.ReadLine();
            if (name == null)
            {
                name = "";
            }
            return name;
        }

        public static void DisplayWrongOption()
        {
            Console.WriteLine("Invalid option, please choose again");
        }

        public static void IncorrectNumberInput()
        {
            Console.WriteLine("You need to enter a valid number");
        }

        public static void DisplayQuestion(char operation, int a, int b)
        {
            Console.WriteLine($"Whats the result of {b} {operation} {a}");
        }

        public static void DisplayPlayAgainQuestion()
        {
            Console.WriteLine("Would you like to play again? Type yes or no");
        }

        public static void DisplayDivider()
        {
            Console.WriteLine("------------------------------------------------------------");
        }
        
        public static void DisplayCorrectGuess()
        {
            Console.WriteLine("Correct!");
        }

        public static void DisplayIncorrectGuess() {
            Console.WriteLine("Inccorect, try guessing again");
        }

    }
}
