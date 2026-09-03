using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame
{
    public class Validation
    {
        public static int Validate(string? input)
        {
            while (!int.TryParse(input, out int result) || string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write("\nAnswer: ");
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }
    }
}