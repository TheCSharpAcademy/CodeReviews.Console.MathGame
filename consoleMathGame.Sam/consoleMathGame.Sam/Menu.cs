using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using consoleMathGame;

namespace consoleMathGame.Sam
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu(string? name, DateTime date)
        {
            Console.WriteLine($"Hello {name}. Today is {date}.");
            Console.WriteLine("------------------------------");
            Console.WriteLine("\n");

            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play today? Choose the options below:
        V - View Previous Games
        A - Addition
        S - Subtraction
        M - Multuplication
        D - Division
        Q - Quit the program");
                Console.WriteLine("------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "a":
                        gameEngine.AdditionGame("Addition game");
                        break;
                    case "s":
                        gameEngine.SubtractionGame("division game");
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("Multiplcation game");
                        break;
                    case "d":
                        gameEngine.DivisionGame("Division game");
                        break;
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (isGameOn);

        }
    }
}
