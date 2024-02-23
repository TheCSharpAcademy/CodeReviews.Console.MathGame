using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGamer
{
    internal class Menu
    {
        GameLogic logic = new GameLogic();
        public void ShowMenu(string name)
        {
            bool playAgain = true;
            while (playAgain)
            {
                Console.WriteLine(Figgle.FiggleFonts.Ogre.Render("Math Game"));
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine($"Hello, {name}, it's {DateTime.Now}");
                Console.WriteLine();
                Console.WriteLine($@"What game would you like to play today?
A- Addition
S - Subtraction
M - Multiplication
D - Division
V - View History
Q - Quit");
                Console.WriteLine("----------------------------------------------------");

                string operation = (Console.ReadLine().ToLower());
                Console.Clear();

                while (operation != "a" && operation != "s"&& operation != "m" && operation !="d" && operation != "v")
                {
                    Console.WriteLine($"{operation.ToString()} is not an option...");
                    operation = Console.ReadLine().ToLower().Trim();
                }

                switch (char.Parse(operation.Trim()))
                {
                    case 'a':
                        Console.WriteLine(Figgle.FiggleFonts.Ogre.Render("Addition"));
                        logic.AdditionGame("Addition game selected");
                        break;
                    case 's':
                        Console.WriteLine(Figgle.FiggleFonts.Ogre.Render("Subtraction"));
                        logic.SubtractionGame("Subtraction game selected");
                        break;
                    case 'm':
                        Console.WriteLine(Figgle.FiggleFonts.Ogre.Render("Multiplication"));
                        logic.MultiplicationGame("Multiplication game selected");
                        break;
                    case 'd':
                        Console.WriteLine(Figgle.FiggleFonts.Ogre.Render("Division"));
                        logic.DivisionGame("Division game selected");
                        break;
                    case 'q':
                        Console.WriteLine("Bye");
                        Environment.Exit(1);
                        break;
                    case 'v':
                        Helpers.GetGames();
                        break;
                    default:
                        Console.WriteLine("Invalid Input...");
                        break;
                }

                if (char.Parse(operation.Trim()) != 'v')
                {
                    Console.WriteLine("Type (Y) to play again:");
                    string sPlayAgain = Console.ReadLine().Trim().ToLower();
                    if (sPlayAgain == "y")
                    {
                        playAgain = true;
                        Console.Clear();
                    }
                    else
                    {
                        playAgain = false;
                    }
                }

            }
        }
    }
}
