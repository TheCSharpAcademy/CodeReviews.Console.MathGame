namespace Math
{
    internal class SelectionMenu
    {

        internal void Selection(string? name, DateTime date, int questions)
        {
            bool gameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($@"Welcome to the Math's Game {name}, Its {date.DayOfWeek} a proper day for you to test your math skills. Please choose from the operators below:
    A = Addition
    S - Subtraction
    M - Multiplication
    D - Division
    Q - Quit the Game
    V - List Game History");
                Console.WriteLine("............................................");

                var gameSelected = Console.ReadLine();


                switch (gameSelected.Trim().ToLower())
                {
                    case "a":
                        Operators.
                            Addition("Addition selected", questions);
                        break;
                    case "m":
                        Operators.Multiplication("multiplication selected", questions);
                        break;
                    case "s":
                        Operators.Subtraction("subtraction selected", questions);
                        break;
                    case "d":
                        Operators.Division("Division selected", questions);
                        break;
                    case "q":
                        Console.WriteLine("Thanks for your time");
                        gameOn = false;
                        Environment.Exit(1);
                        break;
                    case "v":
                        HelperMethods.ListHistory();
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        Environment.Exit(1);
                        break;
                }

            } while (gameOn);
        }
    }
}
