// See https://aka.ms/new-console-template for more information
using MathGame;
using MathGame.Constants;

Console.WriteLine("Hello, World!");

var ExitApp = false;
Dictionary<int, string> MainMenu = new Dictionary<int, string> {
    { 1, "Addition" },
    { 2, "Subtraction"},
    { 3, "Multiplication" },
    { 4, "Division" },
    { 5, "Game History" },
    { 6, "Exit" }
    };

Start();

void Start()
{
    ShowMenu();
    do
    {

        var cki = Console.ReadKey().Key;

        switch (cki)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
            case ConsoleKey.Add:
                GameEngine.Instance.StartGame(Operand.Addition);
                ShowMenu();
                break;
            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
            case ConsoleKey.Subtract:
                GameEngine.Instance.StartGame(Operand.Subtraction);
                ShowMenu();
                break;
            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
            case ConsoleKey.Multiply:
                GameEngine.Instance.StartGame(Operand.Multiplication);
                ShowMenu();
                break;
            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:
            case ConsoleKey.Divide:
                GameEngine.Instance.StartGame(Operand.Division);
                ShowMenu();
                break;
            case ConsoleKey.D5:
            case ConsoleKey.NumPad5:
                ShowHistory();
                break;
            case ConsoleKey.D6:
            case ConsoleKey.NumPad6:
            case ConsoleKey.Escape:
                ExitApp = true;
                break;
            default:
                Console.WriteLine("\r\nInvalid input. Please try again");
                break;
        }

    } while (!ExitApp);
}

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("Welcome to Math Game\r\n");
    foreach (var menu in MainMenu)
    {
        Console.WriteLine($"{menu.Key}. {menu.Value}");
    }
}
void ShowHistory()
{
    Console.Clear();
    Console.WriteLine("\r______________________________________________");
    Console.WriteLine("\r||GameType      ||Score ||TimeTaken(s) ||");
    foreach (var score in GameHistory.Instance.Scores)
    {
        var gameTypeText = score.Operand switch
        {
            Operand.Addition => nameof(Operand.Addition),
            Operand.Subtraction => nameof(Operand.Subtraction),
            Operand.Division => nameof(Operand.Division),
            Operand.Multiplication => nameof(Operand.Multiplication)
        };

        Console.WriteLine($"\r\n||{gameTypeText,-14}||{score.Score + "/" + score.TotalQuestions,-6}||{score.TimeTaken,-13}||");

    }
    Console.WriteLine("\r______________________________________________");

    Console.WriteLine("Press any key to return back to the Main Menu");
    Console.ReadKey();
    ShowMenu();
}