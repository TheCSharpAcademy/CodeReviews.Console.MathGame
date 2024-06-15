namespace MathGame
{
    public class Menu
    {
        internal void ShowMenu(string name)
        {
            var menu = new Menu();
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Hello {name}. Which Math Game would you like to play today?");
            Console.WriteLine("\n");
            
            var isGameOn = true;
            do
            {
                Console.WriteLine($@"What game would you like to play today? choose from the options below: 
                A- Addition
                S- Subtraction
                M- Multiplication
                D- Division
                V- View Previous Games
                Q- Quit the Program");
                Console.WriteLine("------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        GameEngine.AdditionGame("Addition Game has been selected");
                        break;
                    case "s":
                        GameEngine.SubtractionGame("Subtraction Game has been selected");
                        break;
                    case "m":
                        GameEngine.MultiplicationGame("Multiplication Game has been selected");
                        break;
                    case "d":
                        GameEngine.DivisionGame("Division Game has been selected");
                        break;
                    case "q":
                        Environment.Exit(1);
                        isGameOn = false;
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            } while (isGameOn);
        }
    }
}

