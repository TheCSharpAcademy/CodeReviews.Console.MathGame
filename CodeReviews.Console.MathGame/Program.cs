using MyFirstProgram;

var menu = new Menu();

var date = DateTime.Now;

string name = Helpers.GetName();

menu.ShowMenu(name, date);



Menu(name);

void Menu(string name)
{
    Console.WriteLine("--------------------->");
    Console.WriteLine($"Hello {name.ToUpper()}. It's {date}. This is your math's game. That's great that you are working on improving yourself.");
    Console.WriteLine("\n");

    bool isGameOn = true;

    do
    {
        Console.WriteLine($@"
    What game would you like to play today? Choose from the options below:
    A - Addition
    S - Substraction
    M - Multiplication
    D - Division
    V - View previous games
    Q - Quit the program");
        Console.WriteLine("--------------------->");

        var gameSelected = Console.ReadLine();
        Console.WriteLine("\n");

        switch (gameSelected.Trim().ToLower())
        {
            case "a":
                GameEngine.AdditionGame("Addition game");
                break;

            case "s":
                GameEngine.SubstractionGame("Substraction game");
                break;

            case "m":
                GameEngine.MultiplicationGame("Multiplication game");
                break;

            case "d":
                GameEngine.DivisionGame("Division game");
                break;


            case "v":
                Helpers.PrintGames();
                break;

            case "q":
                Console.WriteLine("Closing the game");

                isGameOn = false;
                Environment.Exit(1);
                break;

            default:
                Console.WriteLine("Invalid input");
                Environment.Exit(1);
                break;

        }
    } while (isGameOn);
    
}





    










