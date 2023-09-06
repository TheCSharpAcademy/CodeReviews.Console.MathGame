using Spectre.Console;
using Stateless;

namespace MathGame.Gotcha7770;

public class ConsoleGame
{
    private readonly IAnsiConsole _console;
    private readonly StateMachine<State, Trigger> _stateMachine;

    internal State State => _stateMachine.State;

    public ConsoleGame(IAnsiConsole console)
    {
        _console = console;
        _stateMachine = new StateMachine<State, Trigger>(State.Started);

        _stateMachine.Configure(State.Started)
            .Permit(Trigger.Train, State.Training)
            .Permit(Trigger.ShowHistory, State.HistoryView)
            .Permit(Trigger.Quit, State.Exited);

        _stateMachine.Configure(State.Training)
            .OnEntry(StartTrainLoop)
            .PermitReentry(Trigger.Train)
            .Permit(Trigger.Back, State.Started);
        
        _stateMachine.Configure(State.HistoryView)
            .OnEntry(PrintHistory)
            .Permit(Trigger.Back, State.Started);
    }

    public void Start()
    {
        while (State != State.Exited)
        {
            PrintTitle();

            var trigger = _console.Prompt(new SelectionPrompt<Trigger>()
                .Title("What`s next?")
                .AddChoices(Trigger.Train, Trigger.ShowHistory, Trigger.Quit));
            // var trigger = _console.ShowMenu(
            //     new Menu<Trigger>()
            //         .AddItems(
            //             new MenuItem<Trigger>(Trigger.Train, "Train operation"),
            //             new MenuItem<Trigger>(Trigger.ShowHistory, "Show history"),
            //             new MenuItem<Trigger>(Trigger.Quit, "Quit")));

            _stateMachine.Fire(trigger);
        } 
    }

    private void PrintTitle()
    {
        _console.Clear();
        _console.Write(new FigletText("Math Game project for")
            .Centered()
            .Color(Color.Green));
        _console.Write(new FigletText("The C# Academy")
            .Centered()
            .Color(Color.Purple));
        _console.WriteLine();
    }
    
    void StartTrainLoop()
    {
        var input = _console.Prompt(new SelectionPrompt<MathOperation>()
            .Title("Choose Math operation:")
            .AddChoices(Enum.GetValues<MathOperation>()));
        
        while (State != State.Started)
        {
            var gameTurn = Game.NextTurn(input);
            _console.WriteLine(gameTurn.Expression);
            int answer = _console.Ask<int>("Enter the answer:");

            if (answer == gameTurn.Value)
            {
                _console.MarkupLine($"Good job! {answer} is correct :thumbs_up:");
            }
            else
            {
                _console.MarkupLine($"Sorry, but answer is {gameTurn.Value} :pensive_face:");
            }

            Game.SaveAnswer(gameTurn, answer);

            string Converter(Trigger value) => value == Trigger.Train ? "Yes give me a chance!" : "No i`m done";
            var trigger = _console.Prompt(new SelectionPrompt<Trigger> { Converter = Converter }
                .Title("Try again?")
                .AddChoices(Trigger.Train, Trigger.Back));

            _stateMachine.Fire(trigger);
        }
    }
    
    void PrintHistory()
    {
        _console.Write(Game.History.ToRows());
    
        _console.Prompt(
            new SelectionPrompt<string>()
                .Title("Back to main menu?")
                .AddChoices("Press enter"));
        
        _stateMachine.Fire(Trigger.Back);
    }
}