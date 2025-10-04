namespace MathGame
{
    
    internal class Menu
    {
        GameEngine engine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Hello {name}. It's {date.DayOfWeek}. This is your math's game. That's great that you're working on improving yourself\n");
            Console.WriteLine("Press any key to show menu.");
            Console.ReadLine();
            Console.WriteLine("\n");

            bool isGameOn = true;

            do
            {

                Console.WriteLine($@"What game would you like to play today? Choose from the options below:
                            V - View Previous Games
                            A - Addition
                            S - Substraction
                            M - Multiplication
                            D - Division
                            Q - Quit the program");
                Console.WriteLine("----------------------------------------");

                string gameSelected = Console.ReadLine();
                //trim - cleans spaces
                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":

                        engine.AdditionGame("Addition");
                        break;

                    case "s":

                        engine.SubstractionGame("Substraction");
                        break;

                    case "m":

                        engine.MultiplicationGame("Multiplication");
                        break;
                    case "d":

                        engine.DivisionGame("Division");
                        break;
                    case "q":

                        Console.WriteLine("Goodbye");
                        isGameOn = false;
                        break;
                    default:

                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (isGameOn);
        }
    }
}
