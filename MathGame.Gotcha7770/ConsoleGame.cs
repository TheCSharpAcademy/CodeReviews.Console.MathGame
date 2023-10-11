using Spectre.Console;

namespace MathGame.Gotcha7770;

public class ConsoleGame
{
    private readonly Game _game = new();

    public IReadOnlyCollection<GameTurn> History => _game.History;

    public void StartTraining()
    {
        var input = AnsiConsole.Prompt(
            new SelectionPrompt<MathOperation>()
                .Title("Choose Math operation:")
                .AddChoices(Enum.GetValues<MathOperation>()));

        bool tryAgain = true;
        while (tryAgain)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new FigletText("Math Game project for")
                .Centered()
                .Color(Color.Green));
            AnsiConsole.Write(new FigletText("The C# Academy")
                .Centered()
                .Color(Color.Purple));
            AnsiConsole.WriteLine();

            var gameTurn = _game.NextTurn(input);
            AnsiConsole.WriteLine(gameTurn.Expression);
            int answer = AnsiConsole.Ask<int>("Enter the answer:");

            if (answer == gameTurn.Value)
            {
                AnsiConsole.MarkupLine($"Good job! {answer} is correct :thumbs_up:");
            }
            else
            {
                AnsiConsole.MarkupLine($"Sorry, but answer is {gameTurn.Value} :pensive_face:");
            }

            _game.SaveAnswer(gameTurn, answer);

            tryAgain = AnsiConsole.Prompt(
                new SelectionPrompt<bool> { Converter = value => value ? "Yes give me a chance!" : "No i`m done" }
                    .Title("Try again?")
                    .AddChoices(true, false));
        }
    }
}