using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MathGame
{
    public class Menu
    {
        void StartMenu (string name, DateTime date)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Hello {name}. It's {date}. Which Math Game would you like to play today?");
            Console.WriteLine("\n");

            var isGameOn = true;
            do
            {
                Console.WriteLine($@"What game would you like to play today? choose from the options below: 
            A- Addition
            S- Subtraction
            M- Multiplication
            D- Division
            Q- Quit the Program");
                Console.WriteLine("------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "a":
                        AdditionGame("Addition Game has been selected");
                        break;
                    case "s":
                        SubtractionGame("Subtraction Game has been selected");
                        break;
                    case "m":
                        MultiplicationGame("Multiplication Game has been selected");
                        break;
                    case "d":
                        DivisionGame("Division Game has been selected");
                        break;
                    case "q":
                        Environment.Exit(1);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            } while (isGameOn);
        }
    }
}

