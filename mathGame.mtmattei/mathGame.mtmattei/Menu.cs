using mathGame.mtmattei;

namespace mathGame.mtmattei
{
    internal class Menu
    {
        GameEngine gamesClass = new();

        internal void ShowMenu(string name, DateTime date)
        {
            Console.Clear();
            Console.WriteLine($"Hello {name}. Its {date} This is your math game. Thats great that youre working on improviong yourself");
            Console.WriteLine("Press any key to show the menu");
            Console.ReadLine();
            Console.WriteLine("\n");

            var isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"What game would you like to play today? Choose from the menu below
    V - View Previous games
    A - Addition
    S - Substraction 
    M - Multiplication
    D - Division
    Q - Quit the game");
                Console.WriteLine("---------------------------------------");

                var gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToLower())
                {
                    case "v":
                        Helpers.PrintGames();
                        break;

                    case "a":
                        gamesClass.AdditionGame("Addition game");
                        break;

                    case "s":
                        gamesClass.SubstractionGame("Substraction game");
                        break;

                    case "m":
                        gamesClass.MultiplicationGame("Multiplicatiom game");
                        break;

                    case "d":
                        gamesClass.DivisionGame("Division game");
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
