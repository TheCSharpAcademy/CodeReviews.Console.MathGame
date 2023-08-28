using System.IO;
using System.Collections;

// See https://aka.ms/new-console-template for more information
// You need to create a Math game containing the 4 basic operations
//The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
//Users should be presented with a menu to choose an operation
//You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
//You don't need to record results on a database. Once the program is closed the results will be deleted.

namespace MathGame
{
    public class Game
    {
        public char mainMenu() //function is returning upper case char and this means selection of type of challange.
        {
            char playerChoice = ' ';
            Console.WriteLine("=========================");
            Console.WriteLine("Welcome to the Math Game!");
            Console.WriteLine("Please chose what kind of math problem would you like to solve:");
            Console.WriteLine("A. Addition");
            Console.WriteLine("B. Substraction");
            Console.WriteLine("C. Multiplication");
            Console.WriteLine("D. Division");
            Console.WriteLine("X. Exit");
            Console.WriteLine($"\nYour choice: ");
            playerChoice = char.Parse(Console.ReadLine()!);
            char.ToUpper(playerChoice);
            return playerChoice;
        }

        public void additionChallange()
        {
            Console.WriteLine("========================");

        }
    }

    class Programm
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            while (true)
            {
                game.mainMenu();
            }
        }
    }
}