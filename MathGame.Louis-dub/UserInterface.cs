using Spectre.Console;
using MathGame.Louis_dub.Calculation;
using static MathGame.Louis_dub.Enums;

namespace MathGame.Louis_dub;

internal class UserInterface
{
    private readonly AdditionCalculation _additionCalculation = new();
    private readonly SubtractionCalculation _subtractionCalculation = new();
    private readonly MultiplicationCalculation _multiplicationCalculation = new();
    private readonly DivisionCalculation _divisionCalculation = new();
    private readonly RandomCalculation _randomCalculation = new();
    internal void MainMenu()
    {
        while (true)
        {
            Console.Clear();

            var gameChoice = AnsiConsole.Prompt(
                new SelectionPrompt<Menu>()
                .Title("What vould you like to do ?")
                .AddChoices(Enum.GetValues<Menu>())
            );

            var modeChoice = Mode.Easy;
            if (gameChoice != Menu.History) {
                modeChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<Mode>()
                    .Title("Choose a game mode")
                    .AddChoices(Enum.GetValues<Mode>())
                );
            }

            switch (gameChoice)
            {
                case Menu.Addition:
                    AdditionPary(modeChoice);
                    break;
                case Menu.Subtraction:
                    SubtractioParty(modeChoice);
                    break;
                case Menu.Multiplication:
                    MultiplicationParty(modeChoice);
                    break;
                case Menu.Division:
                    DivisionParty(modeChoice);
                    break;
                case Menu.Random:
                    RandomParty(modeChoice);
                    break;
                case Menu.History:
                    History();
                    break;
            }
        }
    }

    private void AdditionPary(Mode mode)
    {
        switch (mode)
        {
            case Mode.Easy:
                _additionCalculation.EasyMode();
                break;
            case Mode.Medium:
                _additionCalculation.MediumMode();
                break;
            case Mode.Hard:
                _additionCalculation.HardMode();
                break;
        }
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    private void SubtractioParty(Mode mode)
    {
        switch (mode)
        {
            case Mode.Easy:
                _subtractionCalculation.EasyMode();
                break;
            case Mode.Medium:
                _subtractionCalculation.MediumMode();
                break;
            case Mode.Hard:
                _subtractionCalculation.HardMode();
                break;
        }
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    private void MultiplicationParty(Mode mode)
    {
        switch (mode)
        {
            case Mode.Easy:
                _multiplicationCalculation.EasyMode();
                break;
            case Mode.Medium:
                _multiplicationCalculation.MediumMode();
                break;
            case Mode.Hard:
                _multiplicationCalculation.HardMode();
                break;
        }
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    private void DivisionParty(Mode mode)
    {
        switch (mode)
        {
            case Mode.Easy:
                _divisionCalculation.EasyMode();
                break;
            case Mode.Medium:
                _divisionCalculation.MediumMode();
                break;
            case Mode.Hard:
                _divisionCalculation.HardMode();
                break;
        }
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    private void RandomParty(Mode mode)
    {
        switch (mode)
        {
            case Mode.Easy:
                _randomCalculation.EasyMode();
                break;
            case Mode.Medium:
                _randomCalculation.MediumMode();
                break;
            case Mode.Hard:
                _randomCalculation.HardMode();
                break;
        }
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }

    private static void History()
    {
        var table = new Table();

        table.Border(TableBorder.Rounded);
        table.AddColumn("[yellow]ID[/]");
        table.AddColumn("[yellow]Game[/]");
        table.AddColumn("[yellow]Mode[/]");
        table.AddColumn("[yellow]Score[/]");
        table.AddColumn("[yellow]Time[/]");
        
        var operations = DataBase.Operations;

        foreach (var operation in operations)
        {
            table.AddRow(
                operation.Id.ToString(),
                $"[cyan]{operation.Game}[/]",
                $"[cyan]{operation.Mode}[/]",
                $"[blue]{operation.Score}[/]",
                $"[blue]{operation.Time:F1}[/]"
            );
        }
        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("Press Any Key to Continue.");
        Console.ReadKey();
    }
}