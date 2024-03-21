using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Arashi256
{
    internal class Menu
    {
        GameEngine engine = new();

        public void ShowMenu(string name, DateTime date)
        {
            bool isGameOn = true;
            Console.Clear();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your maths game. That's great that you're working on improving yourself.\n");
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();
            do
            {
                Console.WriteLine("\nWhat game would you like to play today? Choose from the options below:");
                Console.WriteLine("V - View previous games");
                Console.WriteLine("A - Addition");
                Console.WriteLine("S - Subtraction");
                Console.WriteLine("M - Multiplication");
                Console.WriteLine("D - Division");
                Console.WriteLine("R - Random");
                Console.WriteLine("Q - Quit the program");
                Console.WriteLine("-------------------------------------------------");
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
                        engine.MultiplicationGame("Multiplication game");
                        break;
                    case "d":
                        engine.DivisionGame("Division game");
                        break;
                    case "r":
                        engine.RandomGame("Random game");
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (isGameOn);
        }
    }
}
