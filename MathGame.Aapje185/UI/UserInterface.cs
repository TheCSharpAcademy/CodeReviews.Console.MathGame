namespace C_Sharp_Academy.UI;

using ArithmeticOperations;
using Game;
using static Int32;

public class UserInterface : IUserInterface
{
    private readonly Dictionary<int, (string, Action)> _options;
    private readonly IGame _game;

    public UserInterface()
    {
        _game = new Game();
        _options = new Dictionary<int, (string, Action)>
        {
            { 1, ("View previous games", () => _game.ShowPreviousResults()) },
            { 2, ("Addition", () => _game.StartGame<Addition>()) },
            { 3, ("Subtraction", () => _game.StartGame<Subtraction>()) },
            { 4, ("Multiplication", () => _game.StartGame<Multiplication>()) },
            { 5, ("Division", () => _game.StartGame<Division>()) },
            { 6, ("Quit the program", () => _game.QuitGame()) }
        };
    }
    public void PresentMenuToUser()
    {
        Console.WriteLine();
        Console.WriteLine("What game would you like to play today? Choose from the options below:");
        
        foreach (var option in _options)
        {
            Console.WriteLine($"{option.Key} - {option.Value.Item1}");
        }

        Console.WriteLine(new string('-', 40));
    }

    public void GetOptionFromUser()
    {
        int userChoice;
        while (!TryParse(Console.ReadLine(), out userChoice) || !_options.ContainsKey(userChoice))
        {
            Console.WriteLine($"The chosen option is not available, please enter a valid option.");
        }

        if (userChoice == 5) return;
        
        _options[userChoice].Item2.Invoke();
        PresentMenuToUser();
        GetOptionFromUser();
    }
}