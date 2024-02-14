public class Menu
{
    public void ShowMenu(string name, DateTime date)
    {
        Console.Clear();
        Console.WriteLine($"Hello {name}, it is {date}. Welcome to the math game!");
        Console.WriteLine("----------------------------------------------------------------------------");

        var gameRunning = true;

        do
        {
            Console.Clear();
            Console.WriteLine($@"What game would you like to play? You may select from the following options:
V - View history
A - Addition game
S - Subtraction game
M - Multiplication game
D - Division game
Q - Quit");
            Console.WriteLine("----------------------------------------------------------------------------");
            var gameSelection = Console.ReadLine()?.Trim().ToUpper();

            switch (gameSelection)
            {
                case "V":
                    Console.WriteLine("View history");
                    break;
                case "A":
                    GameEngine.AdditionGame("Addition game");
                    break;
                case "S":
                    Console.WriteLine("Subtraction game");
                    break;
                case "M":
                    Console.WriteLine("Multiplication game");
                    break;
                case "D":
                    Console.WriteLine("Division Game");
                    break;
                case "Q":
                    Console.WriteLine("Thank you for playing!");
                    gameRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection, press any key to try again!");
                    Console.ReadKey();
                    break;
            }
        } while (gameRunning);
    }
}