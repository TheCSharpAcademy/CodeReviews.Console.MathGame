namespace MathGame.WinnieNgina
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Hello {name}. It's {date}. This is yout math's game. That's great that you are working on improving yourself");
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();
            Console.WriteLine("\n");
            var isGameOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play? Choose from the options below:
                             V - View Previous Games
                             A - Addition
                             S - Subtraction
                             M - Multiplication
                             D - Division
                             R - Random Game
                             Q - Quit the program");
                Console.WriteLine("-----------------------------------------");
                var gameSelected = Console.ReadLine();
                var gameChoice = gameSelected.Trim().ToLower();
                switch (gameChoice)
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        engine.AdditionGame("Addition game selected");
                        break;
                    case "s":
                        engine.SubtractionGame("Substraction game selected");
                        break;
                    case "m":
                        engine.MultiplicationGame("Multiplication game selected");
                        break;
                    case "d":
                        engine.DivisionGame("Division game selected");
                        break;
                    case "r":
                        engine.RandomGame("Random game selected");
                        break;
                    case "q":
                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (isGameOn);


        }
    }
}
