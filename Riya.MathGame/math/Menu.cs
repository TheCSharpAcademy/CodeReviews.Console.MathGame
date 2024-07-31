using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math
{
    //internal means this class can be accessed anywhere within this project 
    internal class Menu
    {
        GameEngine engine = new();
        internal void showMenu(string name , DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name}. It's {date}. This is your math's game. That's great that you're working on improving yourself");
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
V - View Previous Games
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
                Console.WriteLine("---------------------------------------------");

                var gameSelected = Console.ReadLine();
                //Trime remove white spaces from front and end
                switch (gameSelected.Trim().ToLower())
                //switch (gameSelected)
                {

                    case "v":

                        Console.WriteLine("Prev");
                        Helpers.PreviousGame();

                        break;
                    case "a":

                        Console.WriteLine("Addition");
                        engine.Addition();

                        break;
                    case "s":
                        Console.WriteLine("Subtraction");
                        engine.Subtraction();
                        break;

                    case "m":
                        Console.WriteLine("Multiplication");
                        engine.Multiplication();
                        break;
                    case "d":
                        Console.WriteLine("Divison");
                        engine.Division();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid");

                        break;
                }
            } while (isGameOn);

        }
    }
}
