namespace MathGame.lordWalnuts;
internal class Menu
{

    GameEngine gameEngine = new();

    internal void ShowMenu()
    {
        string name = Helpers.GetName();
        var date = DateTime.UtcNow;
        //Enter name
        Console.Clear();
        Console.WriteLine($"Hello {name}. It's {date}. This is your math's game. That's great that you're working on improving yourself");
        Console.WriteLine("Press any key to show menu");
        Console.ReadLine();
        Console.WriteLine("\n");

        var isGameOn = true;

        do
        {
            //select game
            Console.Clear();
            Console.WriteLine(
@$"What game would you like to play today? Choose from the options below:
    V - View Previous Games
    A - Addition
    S - Subtraction
    M - Multiplication
    D - Division
    R - Random
    Q - Quit the program");

            Console.WriteLine("---------------------------------------------");

            var gameSelected = Console.ReadLine();


            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintGames();
                    break;
                case "a":
                    //message, difficulty, numberOfQuestions, addToDatabase
                    gameEngine.AdditionGame("Addition game", Helpers.ChooseDifficulty(), Helpers.NumberOfQuestions(), false);
                    break;
                case "s":
                    gameEngine.SubtractionGame("Subtraction game", Helpers.ChooseDifficulty(), Helpers.NumberOfQuestions(), false);
                    break;
                case "m":
                    gameEngine.MultiplicationGame("Multiplication game", Helpers.ChooseDifficulty(), Helpers.NumberOfQuestions(), false);
                    break;
                case "d":
                    gameEngine.DivisionGame("Division game", Helpers.ChooseDifficulty(), Helpers.NumberOfQuestions(), false);
                    break;
                case "r":
                    gameEngine.RandomGame("Random game", Helpers.ChooseDifficulty(), Helpers.NumberOfQuestions());
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

