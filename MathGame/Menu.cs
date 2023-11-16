using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new GameEngine();

        // Displays game menu and handles user input for selections
        internal void ShowMenu()
        {
            var quitGame = false;

            do
            {
                Helpers.gameType = 0;

                Console.Clear();
                Console.WriteLine(@$"Welcome to the Math Game!
Please select an option from the menu below:

            Game Type:
                A: Addition
                S: Subtraction
                M: Multiplication
                D: Division
                R: Random

            Options:
                L: Leaderboard
                T: Total Rounds: {Helpers.totalRounds}
                G: Game Difficulty: {Helpers.difficultyString}
                Q: Quit Game");

                Console.Write("\nEnter menu selection: ");
                string gameSelection = Console.ReadLine().ToUpper().Trim();

                switch (gameSelection)
                {
                    case "A":
                        Helpers.gameType = 1;
                        Helpers.gameTypeString = "Addition";
                        break;
                    case "S":
                        Helpers.gameType = 2;
                        Helpers.gameTypeString = "Subtraction";
                        break;
                    case "M":
                        Helpers.gameType = 3;
                        Helpers.gameTypeString = "Multiplication";
                        break;
                    case "D":
                        Helpers.gameType = 4;
                        Helpers.gameTypeString = "Division";
                        break;
                    case "R":
                        Helpers.gameType = 5;
                        Helpers.gameTypeString = "Random";
                        break;
                    case "L":
                        Helpers.DisplayScores();
                        break;
                    case "T":
                        Helpers.SelectRounds();
                        break;
                    case "G":
                        Helpers.SelectDifficulty();
                        break;
                    case "Q":
                        quitGame = true;
                        Console.WriteLine("\nGoodbye");
                        break;
                    default:
                        Console.Write("Invalid Input. Please enter an option from the menu.");
                        Helpers.WaitToContinue("Press any key to try again...");
                        break;
                }

                if (Helpers.gameType >= 1 && Helpers.gameType <= 5)
                    gameEngine.PlayGame();

            } while (!quitGame);

        }
    }
}