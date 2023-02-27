using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.chad1082
{
    internal class Menu
    {

        internal void ShowMainMenu(string name, DateTime date)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Hello {name}, Welcome to the Math's game, it is now {date}");
            Console.WriteLine("\n");

            bool gameRunning = true;

            do
            {
                MainMenu();
                Console.Clear();
            } while (gameRunning);


        }

        private void MainMenu()
        {
            GameEngine gameEngine = new GameEngine();

            Console.WriteLine(@"What game would you like to play? Select an option from below:
            A - Addition
            S - Subtraction
            M - Multiplication
            D - Division
            V - View previous scores
            Q - Quit the game :(");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("\n");

            string menuOption = Console.ReadLine();
            if (menuOption == null)
            {
                menuOption = "";
            }

            switch (menuOption.Trim().ToUpper())
            {
                case "A":
                    gameEngine.AdditionGame("Addition Game\n");
                    Console.Clear();
                    break;
                case "S":
                    gameEngine.SubtractionGame("Subtraction Game\n");
                    break;
                case "M":
                    gameEngine.MultiplicationGame("Multiplication Game\n");
                    break;
                case "D":
                    gameEngine.DivisionGame("Division Game\nAll answers should be whole numbers!\n");

                    break;
                case "V":
                    Helpers.ShowScores();

                    break;
                case "Q":
                    Console.WriteLine("Goodbye!");
                    //gameRunning = false;
                    Environment.Exit(1);
                    break;

                default:
                    Console.WriteLine("Unrecognised input, Please select an option from the menu. ");
                    break;
            }
        }
    }
}
