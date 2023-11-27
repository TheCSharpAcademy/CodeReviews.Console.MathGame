namespace Branch_Console;

internal class MainMenu : State
{

    public override void Print()
    {
        Console.Clear();
        Console.WriteLine(new string('-', Helpers.ConsoleWidth()));
        Console.WriteLine($"Hello {_context._settings.PlayerName}. It's {Helpers.GetDate()} an your current score is: {_context.SessionScore}. This is your math's game. That's great that you're working on improving yourself\n");
        Console.WriteLine(@$"What game would you like to play today? Choose from the options below:
            1 - Game Settings
            2 - View Previous Games
            3 - Addition
            4 - Subtraction
            5 - Multiplication
            6 - Division
            7 - Random Game
            0 - Quit the program");
        Console.WriteLine(new string('-', Helpers.ConsoleWidth()));
    }

    public override State? Process()
    {
        State? newState = null;

        var input = Console.ReadLine();

        if (!int.TryParse(input, out int result))
            result = -1;

        switch (result)
        {
            case 0:
                newState = null;
                break;
            case 1:
                newState = new GameSettings();
                break;
            case 2:
                newState = new PrintGames();
                break;
            case 3:
                newState = new SetUpRun() { operationType = OperationType.Addition };
                break;
            case 4:
                newState = new SetUpRun() { operationType = OperationType.Subtration };
                break;
            case 5:
                newState = new SetUpRun() { operationType = OperationType.Multiplication };
                break;
            case 6:
                newState = new SetUpRun() { operationType = OperationType.Division };
                break;
            case 7:
                newState = new SetUpRun() { operationType = null };
                break;
            default:
                Console.WriteLine($"Invalid input. Select an option from above.\nPress Any Key");
                Console.ReadLine();
                newState = this;
                break;
        }
        return newState;
    }
}