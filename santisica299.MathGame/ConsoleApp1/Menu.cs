namespace ConsoleApp1;
public class Menu
{
    GameEngine engine = new();
    public void ShowMenu(string name, DateTime date)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"Hello {name}. It's {date}. This is your math's game.");
        Console.WriteLine("\n");
        Console.ReadLine();

        var isGameOn = true;

        do
        {
            Console.Clear();

            Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
                             V - View previous games
                             A - Addition
                             S - Subtraction
                             M - Multiplication
                             D - Division
                             R - Random
                             Q - Quit the program");
            Console.WriteLine("---------------------------------------------");

            var gameSelected = Console.ReadLine();

            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.ViewPrevGames();
                    break;
                case "a":
                    engine.NewGame('+',"Addition game");
                    break;
                case "s":
                    engine.NewGame('-',"Subtraction game");
                    break;
                case "m":
                    engine.NewGame('*',"Multiplication game");
                    break;
                case "d":
                    engine.NewGame('/',"Division game");
                    break;
                case "r":
                    engine.NewGame('r',"Random game");
                    break;
                case "q":
                    Console.WriteLine("Goodbye");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    Console.ReadLine();
                    break;
            }
        } while (isGameOn);
    }

}
