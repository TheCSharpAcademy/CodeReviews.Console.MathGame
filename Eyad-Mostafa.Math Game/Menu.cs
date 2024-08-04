namespace Math_Game;

internal class Menu
{
    internal static void ShowMenu()
    {
        Console.Write("Please Enter Your Name: ");
        var name = Helpers.GetName();
        var date = DateTime.UtcNow;
        Console.WriteLine($"Welcome {name} it's {date.AddHours(3)} and this is the Math Game, Are you ready?\n");
        while (true)
        {
            var gameMode = Helpers.Mode();
            var game = ChooseGame();
            DetermineGame(game, gameMode);
        }
    }

    static void DetermineGame(string game, string mode)
    {
        switch (game)
        {
            case "v":
                Helpers.ShowHistory();
                break;
            case "a":
                GameEngine.AdditionGame(mode, ChooseNumberOfWuestions());
                break;
            case "s":
                GameEngine.SubtractionGame(mode, ChooseNumberOfWuestions());
                break;
            case "m":
                GameEngine.MultiplicationGame(mode, ChooseNumberOfWuestions());
                break;
            case "d":
                GameEngine.DivisionGame(mode, ChooseNumberOfWuestions());
                break;
            case "r":
                string modes = "asmd";
                DetermineGame(modes[Random.Shared.Next(0, 4)].ToString(), mode);
                break;
            case "q":
                Console.WriteLine("Good Bye");
                Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Invalid character, Please try again");
                DetermineGame(ChooseGame(), mode);
                break;
        }
    }

    private static int ChooseNumberOfWuestions()
    {
        Console.Clear();
        Console.WriteLine("Please Choose number of questions");
        var numberOfQuestions = Console.ReadLine().Trim();
        numberOfQuestions = Helpers.ValidateResult(numberOfQuestions);
        return int.Parse(numberOfQuestions);
    }

    static string ChooseGame()
    {
        Console.WriteLine(@"Please Choose GAME :
V - Show History
A - Addition
S - Substraction
M - Multiplication
D - Division
R - Random Game
Q - Quit Game");
        string? operatrion = Console.ReadLine().Trim();
        return operatrion.ToLower();
    }

}
