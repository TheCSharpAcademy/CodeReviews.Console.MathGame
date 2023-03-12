using Math_Game.Controller;
using Math_Game.Model;
using Math_Game.Model.Problems;

namespace Math_Game.View;

internal class Menu
{
    GameController controller;

    internal Menu()
    {
        ProblemModel problem = new ProblemModel();
        ProblemView view = new ProblemView(problem);
        controller = new GameController(problem, view);
    }

    internal void ShowMenu(string name, DateTime date)
    {
        Console.Clear();
        Console.WriteLine($"Hello {name}. It's {date}. Many of the problems are based on Number Sense competitions");
        Helpers.PrintContinue();

        bool isGameOn = true;

        do
        {
            Console.Clear();
            Console.WriteLine(@$"
What game would you like to play today? Choose from the options below:
V - View Previous Games
Q - Quit the program");
            int index = 0;
            foreach (string type in Enum.GetNames(typeof(ProblemType)))
            {
                Console.WriteLine($"{index++} - {type}");
            }
            Helpers.PrintDivider();
            string gameSelected = Console.ReadLine();

            int gameType;
            if(Int32.TryParse(gameSelected, out gameType))
            {
                if (Enum.IsDefined(typeof(ProblemType), gameType)) {
                    controller.SetProblem((ProblemType)gameType);

                    Console.WriteLine("How many problem?: ");
                    string amount = Console.ReadLine();
                    int amountInt;
                    if (Int32.TryParse(amount, out amountInt))
                    {
                        controller.RunProblem(amountInt);
                    }
                    else Console.WriteLine("Invalid Input");
                }
                else Console.WriteLine("Invalid Input");
            }
            else
            {
                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintHistory();
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        } while (isGameOn);
    }
}
