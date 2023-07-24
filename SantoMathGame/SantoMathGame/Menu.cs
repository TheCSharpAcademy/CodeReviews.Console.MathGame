namespace SantoMathGame
{
    internal class Menu
    {
        GameEngine gameEngine = new();
        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear(); 
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Hello {name.ToUpper()}. It's {date}. this is your math's game.\n");
            Console.WriteLine("Press any key to show menu");
            Console.ReadLine();

            var isGameOn = true;

            do
            {
                
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(@$"Choose a game for today!!!
         V - View previous games
         A - Addition
         S - Subtraction
         M - Multiplication 
         D - Division
         Q - Quit the game");
                Console.WriteLine("-------------------------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;
                    case "a":
                        gameEngine.AdditionGame("Addition game :");
                        break;
                    case "s":
                        gameEngine.SubstractionGame("Substraction game :");
                        break;
                    case "m":
                        gameEngine.MultiplicationGame("Multiplication game :");
                        break;
                    case "d":
                        gameEngine.DivisionGame("Division game :");
                        break;
                    case "q":
                        Console.WriteLine("Good bye!!!!!");
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input :v ");
                        break;
                }
                Console.Clear();
            } while (isGameOn);


        }
    }
}
