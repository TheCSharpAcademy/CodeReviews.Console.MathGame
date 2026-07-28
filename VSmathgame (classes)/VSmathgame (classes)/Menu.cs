namespace VSmathgame__classes_
{
    internal class Menu
    {

        internal void ShowMenu(string name, DateTime date)
        {

            GameEngine engine = new();
            //instantiate engine in the menu class so we can call on it

            Console.WriteLine();
            Console.WriteLine($"Hello {name.ToUpper()},\nIts currently {date} welcome to the method Maths game!");
            Console.WriteLine();
            Console.WriteLine(@"What game would you like to play today?
    Please choose from the options below:

    V - View previous games
    A - Addition
    S - Subtraction
    M - Multiplication
    D - Division
    Q - Quit the program");

            while (true)
                // allows to repeat consistently until q is pressed 
            {
                string? menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "a":
                        engine.Addition("Addition game!");
                        return;

                    case "s":
                        engine.Subtraction("Subtraction game!");
                        return;

                    case "m":
                        engine.Multiplication("Multiplication game!");
                        return;

                    case "d":
                        engine.Division("Division game!");
                        return;

                    case "v":
                        Helpers.PreviousGames();
                        return;

                    case "q":
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        return;

                    default:
                        Console.WriteLine("Please enter a valid option");
                        Environment.Exit(0);
                        break; // exits the switch, while loop then repeats
                }
            }
        }

    }
}
