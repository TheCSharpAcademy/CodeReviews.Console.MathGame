using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.frockett;

internal class Menu
{
    GameEngine engine = new GameEngine();
    bool isGameOn = true;

    internal void ShowMenu(DateTime date)
    {
        string? readResult;
        string menuSelection = "";

        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to Frockett's Mathematics Bonanza!");
            Console.WriteLine($"Today is {date.DayOfWeek}");
            Console.WriteLine();
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Addition Challenge");
            Console.WriteLine("2. Subtraction Challenge");
            Console.WriteLine("3. Multiplication Challenge");
            Console.WriteLine("4. Division Challenge");
            Console.WriteLine("5. View Session History");
            Console.WriteLine();
            Console.WriteLine("Or type 'Exit' to close the application\n");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower().Trim();
            }

            switch (menuSelection)
            {
                case "1":
                    engine.MainGameLoop('+');
                    break;
                case "2":
                    engine.MainGameLoop('-');
                    break;
                case "3":
                    engine.MainGameLoop('*');
                    break;
                case "4":
                    engine.MainGameLoop('/');
                    break;
                case "5":
                    AuxFunctions.PrintHistory();
                    break;
                case "exit":
                    Console.WriteLine("\nGoodbye");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid menu selection");
                    break;
            }
        }
        while (isGameOn);
    }
}
