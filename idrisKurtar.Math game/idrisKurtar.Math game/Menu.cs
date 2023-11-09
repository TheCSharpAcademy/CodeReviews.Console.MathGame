using System;
using System.Linq;


namespace idrisKurtar.Math_game
{
    internal class Menu
    {
        GameEngine engine = new GameEngine();
        Helpers helpers = new Helpers();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}.It's {date.DayOfWeek}.This is your math's game. That's great that you're working on improving yourself\n");

            var isGameOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play today? Choose from the options below:
V- View Previous GAmes
A - Addition
S - Substraction
M - Multipliction
D - Division
Q - Quit the program");
                Console.WriteLine("---------------------------------");

                var gameSelected = Console.ReadLine();
                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        GameEngine.AdditionGame("Addition game ");
                        break;
                    case "s":
                        GameEngine.SubstractionGame("Substraction game ");
                        break;
                    case "m":
                        GameEngine.MultiplictionGame("Multiplication game ");
                        break;
                    case "d":
                        GameEngine.DivisionGame("Divison game ");
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
