namespace MathGame
{
    internal class Menu
    {
        public GameEngine gameEngine = new();

        internal void ShowMenu()

        {
            Console.WriteLine("\nPlease enter your name");
            var name = Console.ReadLine();

            var date = DateTime.UtcNow;

            Console.WriteLine($"Hello {name} today is {date}, type any key to go to Menu");
            Console.ReadLine();

            var isGameOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
V - View history
A - Addition
S - Subtraction
M - Multiplication
D - Division
Q - Quit the program");
                Console.WriteLine("---------------------------------------------");

                var command = Console.ReadLine();

                switch (command.ToLower().Trim())
                {
                    case "v":
                        Helpers.ShowHistory();
                        break;

                    case "a":
                        gameEngine.Addition("\n Addition game selected");
                        break;

                    case "s":
                        gameEngine.Subtraction("Substraction game selected");
                        break;

                    case "m":
                        gameEngine.Multiplication("Multiplication game selected");
                        break;

                    case "d":
                        gameEngine.Division(" \nDivision game selected");
                        break;

                    case "q":
                        Console.Write("Goodbye...");
                        isGameOn = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("invalid input, press any key to go back to menu");
                        Console.ReadLine();
                        break;
                }
            } while (isGameOn);
        }
    }
}