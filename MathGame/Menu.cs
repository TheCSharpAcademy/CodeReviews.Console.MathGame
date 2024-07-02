using System;
using System.Linq;
using System.Timers;

namespace MathGame
{

    public class Menu
    { 
        public void StartMenu(string name)
        {
            GameMechanics gameMechanics = new GameMechanics();
            Console.WriteLine("--------------");
            Console.WriteLine($"Welcome to the Math Game, {name}, today is {DateTime.UtcNow}.");
            Console.WriteLine("\n");
            
            Console.WriteLine("Please choose difficulty.");
            Console.WriteLine("\n");
            Console.WriteLine("0 - Easy, 1 - Hard");
            Console.WriteLine("\n");

            string diff = Console.ReadLine();
            int difficulty = Int32.Parse(diff);
            Console.WriteLine("\n");
            Console.WriteLine("--------------");
            Console.WriteLine("\n");

            bool gameOn = true;

            while (gameOn)
            {
                Console.WriteLine("A - ADDITION" + "\n");
                Console.WriteLine("S - SUBTRACTION" + "\n");
                Console.WriteLine("D - DIVISION" + "\n");
                Console.WriteLine("M - MULTIPLICATION" + "\n");
                Console.WriteLine("E - EXIT" + "\n");
                Console.WriteLine("H - HISTORY" + "\n");
                Console.WriteLine("R - RANDOM GAME" + "\n");

                string option;
                do
                {
                    option = Console.ReadLine();
                   
                }
                while (option == "");

                switch (option.ToLower())
                {
                    case "a":
                        gameMechanics.additionGame(difficulty); break;
                    case "s":
                        gameMechanics.subtractionGame(difficulty); break;
                    case "d":
                        gameMechanics.divisionGame(difficulty); break;
                    case "m":
                        gameMechanics.multiplicationGame(difficulty); break;
                    case "e":
                        gameOn = false;
                        Console.WriteLine();
                        return;
                    case "h":
                        gameMechanics.Print();
                        Console.WriteLine();
                        break;
                    case "r":
                        gameMechanics.RandomFunction(difficulty, true); break;
                    default:
                        Console.WriteLine("No such command exists");
                        break;
                }
            }
        }


    }
            
    
}
