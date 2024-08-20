namespace MathGame
{
    internal class UI
    {
        DateTime date = DateTime.Now;
        Games gameEngin = new Games();
        internal void ShowMenu(string name)
        {
            bool isGameOn = true;

            Greeting(name, date);

            while (isGameOn)
            {
                Console.WriteLine(@"What game would you like to play? Choose from the option below:
     V - View Previous Games.
     A - Addition.
     S - Subtraction.
     M - Multiplication.
     D - Division.
     R - Random.
     Q - Quit the program.");
                Console.WriteLine("------------------------------------------------------");

                string gameSelected = Console.ReadLine();

                switch (gameSelected.Trim().ToUpper())
                {
                    case "V":
                        ShowHistory();
                        break;
                    case "A":
                        gameEngin.AdditionGame("Addition Game");
                        break;
                    case "S":
                        gameEngin.SubtractionGame("Subtraction Game");
                        break;
                    case "M":
                        gameEngin.MultiplicationGame("Multiplication Game");
                        break;
                    case "D":
                        gameEngin.DivisionGame("Division Game");
                        break;
                    case "R":
                        gameEngin.RandomGame("Random Game");
                        break;

                    case "Q":
                        Console.WriteLine($"Goodbye.. {name}!");
                        Environment.Exit(0);
                        isGameOn = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Input, try again..\n");
                        break;
                }
            }

        }
        internal void Greeting(string name, DateTime date)
        {
            int hour = Convert.ToInt32(date.Hour.ToString());


            if (hour > 0 && hour <= 12)
            {
                Console.WriteLine($"Good morning.. {name}");
            }
            else if (hour >= 12 && hour <= 5)
            {
                Console.WriteLine($"Good afternoon.. {name}");
            }
            else
            {
                Console.WriteLine($"Good eveing.. {name}");
            }

            Console.WriteLine();

        }
        internal void Header()
        {
            Console.WriteLine("******************************************************");
            Console.WriteLine("*************  WELCOM TO THE MATH GAME  **************");
            Console.WriteLine("******************************************************");

            Console.WriteLine();
        }

        internal void ShowHistory()
        {
            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("-------------------");

            foreach (string item in Helpers.gamesHistory)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------------\n");
            Console.WriteLine("Press any key to go back to the main menu.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
