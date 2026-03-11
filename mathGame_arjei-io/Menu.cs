using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame
{
    internal class Menu
    {
        internal void ShowMenu()
        {
            ChooseGame chooseGame = new ChooseGame();
            string difficulty = "Easy";
            bool displayMenu = true;
            string? userInput;

            Console.WriteLine("Welcome to MathGame.\n-Press 'enter' to show menu-");
            Console.ReadLine();

            do
            {
                Console.Clear();
                Console.WriteLine($@"Choose an operation and press enter to continue:
+:  Addition
-:  Subtraction
/:  Division
*:  Multiply
r:  Random game
H:  Display game history
Q:  Exit the program

Difficulty: {difficulty}

D:  Change difficulty");

                userInput = Console.ReadLine();
                

                switch (userInput.Trim().ToLower())
                {
                    case "+":
                        Console.Clear();
                        Console.WriteLine("+ chosen.");
                        chooseGame.AdditionGame(difficulty);
                        break;

                    case "-":
                        Console.Clear();
                        Console.WriteLine("- chosen.");
                        chooseGame.SubtractionGame(difficulty);
                        break;

                    case "/":
                        Console.Clear();
                        Console.WriteLine("/ chosen.");
                        chooseGame.DivisionGame(difficulty);
                        break;

                    case "*":
                        Console.Clear();
                        Console.WriteLine("* chosen.");
                        chooseGame.MultiplyGame(difficulty);
                        break;

                    case "r":
                        Console.Clear();
                        Console.WriteLine("random chosen.");
                        chooseGame.RandomGame(difficulty);
                        break;

                    case "h":
                        Console.Clear();
                        Console.WriteLine("Displaying history:");
                        Helpers.DisplayHistory();
                        break;

                    case "d":
                        Console.Clear();
                        difficulty = DifficultySetting.ChooseDifficulty();
                        break;

                    case "q":
                        Console.WriteLine("Hope you enjoyed your stay :)");
                        displayMenu = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please type a valid operation: (Enter to show menu)");
                        Console.ReadLine();
                        break;
                }
            } while (displayMenu);
        }

    }
}
