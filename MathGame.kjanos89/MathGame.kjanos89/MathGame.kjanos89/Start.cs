using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.kjanos89
{
    public class Start
    {
        public void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine($"Hello! {GameData.Name}, Choose an option from the menu below by pressing the proper key:");
            Console.WriteLine("A - Addition");
            Console.WriteLine("S - Subtraction");
            Console.WriteLine("M - Multiplication");
            Console.WriteLine("D - Division");
            Console.WriteLine("Q - Quit the program");
            Console.WriteLine("__________________________________________________________________");
            string selection = Console.ReadLine().ToLower();
            char firstChar = selection[0];
            Console.WriteLine(GameSelected(firstChar));
        }

        public static string GameSelected(char selected)
        {
            string result = "";
            switch (selected)
            {
                case 'a':
                    AdditionGame addition = new AdditionGame();
                    addition.Result();
                    break;
                case 's':
                    result = "You chose Subtraction.";
                    break;
                case 'm':
                    result = "You chose Multiplication.";
                    break;
                case 'd':
                    result = "You chose Division.";
                    break;
                case 'q':
                    result = "Program closes. Hope to see you soon!";
                    break;

                default:
                    result = "Wrong input, please choose from the menu.";
                    break;
            }
            return result;
        }
        public void QuitGame()
        {
            Console.Clear();
            Console.WriteLine("Bye-Bye!");
            Environment.Exit(2);
        }
    }
}
