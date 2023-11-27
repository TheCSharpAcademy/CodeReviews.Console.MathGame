namespace Branch_Console;

internal class GameSettings : State
{
    public override void Print()
    {
        Console.Clear();
        Console.WriteLine(new string('-', Helpers.ConsoleWidth()));
        Console.WriteLine(@$"Current player name is: {_context._settings.PlayerName}.
Current difficulty is: {_context._settings.Difficulty}.
Current question per round is: {_context._settings.QuestionsCount}.");
        Console.WriteLine(new string('-', Helpers.ConsoleWidth()));
        Console.WriteLine(@$"What option would you like to change? Please select from the list below:
            1 - Player name
            2 - Game difficulty
            3 - Question per round
            0 - Return to main menu");
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
                newState = new MainMenu();
                break;
            case 1:
                newState = new SetPlayerName();
                break;
            case 2:
                newState = new SetDifficulty();
                break;
            case 3:
                newState = new SetQuestions();
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