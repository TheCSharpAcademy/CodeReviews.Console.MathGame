using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbraheemKarim.MathGame
{
    internal class Menu
    {
        public void ShowGreetings(string name, DateTime dateAndTime)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name}. It's {dateAndTime}. This is your math's game.\nIt's great that you're working on improving yourself\n");
            Console.WriteLine("You can press any key to continue");
            Console.ReadKey();
        }

        public ActionType GetDesiredAction()
        {
            bool firstIteration = true;
            do
            {
                Console.Clear();

                if (!firstIteration)
                    Console.WriteLine("Invalid input!! \n");

                Console.WriteLine(@$"
Choose one of the options below:
1 - Start playing the game
2 - View previous games history
3 - Quit the Game");
                Console.WriteLine("---------------------------------------------");

                if (int.TryParse(Console.ReadLine(), out int selection))
                {
                    if (selection < 4 && selection > 0)
                        return (ActionType)selection;
                }

                firstIteration = false;
            } while (true);

        }


        public void ProcessActionType(ActionType action)
        {
            switch (action)
            {
                case ActionType.PlayTheGame:
                    Console.WriteLine("play the game selected");
                    break;
                case ActionType.ViewPreviousGames:
                    Console.WriteLine("View previous games selected");
                    break;
                case ActionType.QuitTheProgram:
                    Console.WriteLine("Quit the program selected");
                    Environment.Exit(0);
                    break;
            }

        }

    }
}
