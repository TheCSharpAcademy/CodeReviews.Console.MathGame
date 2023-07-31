using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _7vanael.MathGame
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name}, it's {date}. This is your math game. It's lovely that you're working on improving your skills.");
            Console.WriteLine("Press any key to show the menu");
            Console.ReadLine();
            Console.WriteLine("\n");
            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($"What game would you like to play today? Choose from the options listed below:" +
                        $"\nV - View Previous Games" +
                        $"\nA - Addition" +
                        $"\nS - Subtraction" +
                        $"\nM - Multiplication" +
                        $"\nD- Division" +
                        $"\nQ - Quit the program");
                Console.WriteLine("------------------------");
                var gameSelected = Console.ReadLine();

                switch (gameSelected.ToLower().Trim())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        engine.AdditionGame("Addition game");
                        break;
                    case "s":
                        engine.SubtractionGame("Subtraction game");
                        break;
                    case "m":
                        engine.MultiplicationGame("Multiplecation game");
                        break;
                    case "d":
                        engine.DivisionGame("Division game");
                        break;
                    case "q":
                        Console.WriteLine("Good bye!");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        Environment.Exit(1);
                        break;

                }

            } while (isGameOn == true);


        }

    }
}
