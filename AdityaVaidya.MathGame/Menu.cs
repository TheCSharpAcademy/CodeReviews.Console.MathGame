using System;

namespace AdityaVaidya.MathGame
{
    internal class Menu
    {
        internal void GameMenu(string name)
        {
            var isGameOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine($@"Hello {name} What game would you like to play today? Choose from options below:

                    A-Addition
                    B-Substraction
                    C-Multiplication
                    D-Division
                    V-Games Score History                    
                    Q-Quit the program");
                Console.WriteLine("-------------------------------------------");

                var selection = Console.ReadLine().ToLower().Trim();

                switch (selection)
                {
                    case "a":
                        GameEngine.AdditionGame("Addition Game"); break;
                    case "b":
                        GameEngine.SubstractionGame("Substraction Game"); break;
                    case "c":
                        GameEngine.MultiplicationGame("Multiplication Game"); break;
                    case "d":
                        GameEngine.DivisionGame("Division Game"); break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    case "v":
                        Helpers.PrintGames(); break;
                    default:
                        Console.WriteLine("Invalid Input");
                        Console.ReadLine();
                        break;
                }

            } while (isGameOn);
        }
    }
}
