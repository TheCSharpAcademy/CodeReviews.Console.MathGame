using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathGame;


namespace MathGame
{
    internal class Menu
    {

        //Variables
        string name = "";
        DateTime date = DateTime.Now;
        string option = "";


        //FilePath Variable

        string docPath = @"C:\Users\Duezt\source\repos\MathGame\MathGame\GameHistory.txt";
        //List
        GameEngine game = new GameEngine();
        Helpers helper = new Helpers(); 
        //Display menu and user name's input
        public void MainMenu()
        {

            //Variables
            string name = "";
            DateTime date = DateTime.Now;
            string option = "";

            //List

            //Display menu and user name's input
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();

            do
            {


                Console.WriteLine($@"Welcome to the math game {name}, today is {date.DayOfWeek}
Please select one of the following games option:
A - Addition 
S - Substraction 
M - Multiplication
D - Division
P - Previous games history
Q - Quit the game");


                //User input for options and logic
                option = Console.ReadLine().ToLower().Trim();

                switch (option)
                {
                    case "a":
                        game.AdditionGame();
                       
                        break;
                    case "s":
                        game.SubtractionGame();
                        break;
                    case "m":
                        game.MultiplicationGame();
                        break;
                    case "d":
                        game.DivisionGame();
                        break;
                    case "p":
                        if (game.previousGames.Count() == 0)
                        {
                            Console.WriteLine("There has not been any game played at this time");
                        }
                        else
                        {
                            foreach (var gameScore in game.previousGames)
                            {
                                Console.WriteLine(gameScore);
                            }
                        }

                        break;
                    case "q":
                        helper.SaveGameHistory(docPath, game.previousGames);
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

             
                Console.WriteLine("Press any key to go back to the menu");
                Console.ReadLine();
                Console.Clear();


            } while (true);

        }




 
    }
}
