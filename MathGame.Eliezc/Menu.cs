namespace math_game
{
    internal class Menu
    {
        GameEngine engine = new();
        internal void DisplayMenu(string name, string date)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date}. This is your math's game. That's great that you're working on improving yourself\n");

            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"
What game would you like to play today? Choose from the options below:
A - Addition
S - Subtraction
M - Multiplication
D - Division
V - View Previous Games
Q - Quit the program");
                Console.WriteLine("------------------------------------");
                var gameSelected = Console.ReadLine();

                switch (gameSelected.ToLower().Trim())
                {
                    case "a":
                        engine.AdditionGame("Addition game selected");
                        break;
                    case "s":
                        engine.SubtractionGame("Subtraction game selected");
                        break;
                    case "m":
                        engine.MultiplicationGame("Multiplication game selected");
                        break;
                    case "d":
                        engine.DivisionGame("Division game selected");
                        break;
                    case "v":
                        helpers.ViewPreviousGame();
                        break;
                    case "q":
                        Console.WriteLine("See you, bye!");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Please input the correct options.");
                        break;
                }
            } while (isGameOn);
        }

    }
}
