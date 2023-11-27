namespace Branch_Console;

internal class SetQuestions : State
{
    public override void Print()
    {
        Console.Clear();
        Console.WriteLine(new string('-', Helpers.ConsoleWidth()));
        Console.WriteLine(@$"Current problem sets per round is:{_context._settings.QuestionsCount}");
        Console.WriteLine($"How many problem sets per round would you like? Choose a integer from 1 to 10:");
    }

    public override State? Process()
    {
        State? newState = null;
        var input = Console.ReadLine();

        if (!int.TryParse(input, out int result))
            result = -1;

        if (result >= 1 && result <= 10)
        {
            _context._settings.QuestionsCount = result;
            newState = new GameSettings();
        }
        else
        {
            Console.WriteLine($"Invalid input. Choose a integer from 1 to 10.\nPress Any Key");
            Console.ReadLine();
            newState = this;
        }
        return newState;
    }
}