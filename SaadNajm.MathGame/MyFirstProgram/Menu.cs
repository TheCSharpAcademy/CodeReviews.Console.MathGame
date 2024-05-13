

namespace MyFirstProgram
{
    internal class Menu
    {
        GameEngine gameEngine=new();
       internal void ShowMenu(string name, DateTime date)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date.DayOfWeek}. This is your math's game. That's great that you're working on improving yourself\n");
            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"What game would you like to play today? Choose from the options below:
                          V - View Previous Games
                          A - Addition
                          S - Substraction
                          M - Multiplication
                          D - Division
                          R - Random
                          Q - Quit the program");
                Console.WriteLine("------------------------------------------------");

                var gameSelected = Console.ReadLine();
                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.GetGames();
                        break;
                    case "a":
                        gameEngine.AdditionGame("Addition game");
                        break;

                    case "s":
                        gameEngine.SubstractionGame("Substraction game");
                        break;

                    case "m":
                        gameEngine.MultiplicationGame("Multiplication game");
                        break;

                    case "d":
                        gameEngine.DivisionGame("Division game");
                        break;
                    case "r":
                        gameEngine.RandomGame("Random game");
                        break;
                    case "q":
                        Console.WriteLine("GoodBye");
                        isGameOn = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        Environment.Exit(0);
                        break;
                }
            } while (isGameOn);

        }
    }
}
