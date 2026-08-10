using Spectre.Console;

List<string> menuOptions = ["Addition Game", "Multiplication Game", "Subtraction Game", "Division Game", "View Game History", "Exit"];
int first = 0, second = 0;
Random firstNumber = new();
Random secondNumber = new();
List<(string game, string score)> gameHistory = [];

var table = new Table()
.AddColumn("Game")
.AddColumn("Score");

while (true)
{
    Console.Clear();
    var _ = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[yellow]What game do you want to play?[/]")
        .AddChoices(menuOptions)
    );

    switch (_)
    {
        case "Addition Game":
            AdditionGame();
            break;
        case "Multiplication Game":
            MultiplicationGame();
            break;
        case "Subtraction Game":
            SubtractionGame();
            break;
        case "Division Game":
            DivisionGame();
            break;
        case "View Game History":
            ViewGameHistory();
            break;
        case "Exit":
            return;
    }
}

void AdditionGame()
{
    int difficultyLevel = 1;
    int noOfCorrectAnswers = 0;
    for (int i = 0; i < 5; i++)
    {
        UpdateDifficultyLevel(difficultyLevel);
        var correctAnswer = first + second;

        int userAnswer;
        while (true)
        {
            var input = AnsiConsole.Ask<string>($"{first} + {second}:");
            if (int.TryParse(input, out userAnswer))
            {
                break;
            }
            AnsiConsole.MarkupLine("[red]That's not a valid number, try again.[/]");
        }
        if (userAnswer == correctAnswer)
        {
            noOfCorrectAnswers++;
            difficultyLevel++;
            AnsiConsole.MarkupLine("[green]Correct![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Wrong![/]");
        }
    }
    gameHistory.Add(("Addition Game", noOfCorrectAnswers.ToString()));
    AnsiConsole.MarkupLine($"[yellow]You got {noOfCorrectAnswers}/5 questions![/]");
    Console.Write("Press the enter key to go back to the menu!");
    Console.ReadKey();
}

void MultiplicationGame()
{
    int difficultyLevel = 1;
    int noOfCorrectAnswers = 0;

    for (int i = 0; i < 5; i++)
    {
        switch (difficultyLevel)
        {
            case 1:
                first = firstNumber.Next(1, 11);
                second = secondNumber.Next(1, 11);
                break;
            case 2:
                first = firstNumber.Next(1, 16);
                second = secondNumber.Next(1, 12);
                break;
            case 3:
                first = firstNumber.Next(5, 21);
                second = secondNumber.Next(5, 16);
                break;
            case 4:
                first = firstNumber.Next(10, 51);
                second = secondNumber.Next(2, 21);
                break;
            case 5:
                first = firstNumber.Next(20, 101);
                second = secondNumber.Next(10, 26);
                break;
        }

        var correctAnswer = first * second;

        int userAnswer;
        while (true)
        {
            var input = AnsiConsole.Ask<string>($"{first} * {second}:");
            if (int.TryParse(input, out userAnswer))
            {
                break;
            }
            AnsiConsole.MarkupLine("[red]That's not a valid number, try again.[/]");
        }
        if (userAnswer == correctAnswer)
        {
            noOfCorrectAnswers++;
            difficultyLevel++;
            AnsiConsole.MarkupLine("[green]Correct![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Wrong![/]");
        }
    }
    gameHistory.Add(("Multiplication Game", noOfCorrectAnswers.ToString()));
    AnsiConsole.MarkupLine($"[yellow]You got {noOfCorrectAnswers}/5 questions![/]");
    Console.Write("Press the enter key to go back to the menu!");
    Console.ReadKey();
}

void SubtractionGame()
{
    int difficultyLevel = 1;
    int noOfCorrectAnswers = 0;
    for (int i = 0; i < 5; i++)
    {
        UpdateDifficultyLevel(difficultyLevel);
        var correctAnswer = first - second;

        int userAnswer;
        while (true)
        {
            var input = AnsiConsole.Ask<string>($"{first} - {second}:");
            if (int.TryParse(input, out userAnswer))
            {
                break;
            }
            AnsiConsole.MarkupLine("[red]That's not a valid number, try again.[/]");
        }
        if (userAnswer == correctAnswer)
        {
            noOfCorrectAnswers++;
            difficultyLevel++;
            AnsiConsole.MarkupLine("[green]Correct![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Wrong![/]");
        }
    }
    gameHistory.Add(("Subtraction Game", noOfCorrectAnswers.ToString()));
    AnsiConsole.MarkupLine($"[yellow]You got {noOfCorrectAnswers}/5 questions![/]");
    Console.Write("Press the enter key to go back to the menu!");
    Console.ReadKey();
}
void DivisionGame()
{
    int difficultyLevel = 1;
    int noOfCorrectAnswers = 0;

    for (int i = 0; i < 5; i++)
    {
        switch (difficultyLevel)
        {
            case 1:
                do
                {
                    first = firstNumber.Next(1, 21);
                    second = secondNumber.Next(1, 6);
                } while (first % second != 0);
                break;
            case 2:
                do
                {
                    first = firstNumber.Next(10, 51);
                    second = secondNumber.Next(2, 11);
                } while (first % second != 0);
                break;
            case 3:
                do
                {
                    first = firstNumber.Next(20, 101);
                    second = secondNumber.Next(3, 16);
                } while (first % second != 0);
                break;
            case 4:
                do
                {
                    first = firstNumber.Next(50, 201);
                    second = secondNumber.Next(5, 21);
                } while (first % second != 0);
                break;
            case 5:
                do
                {
                    first = firstNumber.Next(100, 501);
                    second = secondNumber.Next(7, 26);
                } while (first % second != 0);
                break;
        }

        var correctAnswer = first / second;

        int userAnswer;
        while (true)
        {
            var input = AnsiConsole.Ask<string>($"{first} / {second}:");
            if (int.TryParse(input, out userAnswer))
            {
                break;
            }
            AnsiConsole.MarkupLine("[red]That's not a valid number, try again.[/]");
        }
        if (userAnswer == correctAnswer)
        {
            noOfCorrectAnswers++;
            difficultyLevel++;
            AnsiConsole.MarkupLine("[green]Correct![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Wrong![/]");
        }
    }
    gameHistory.Add(("Division Game", noOfCorrectAnswers.ToString()));
    AnsiConsole.MarkupLine($"[yellow]You got {noOfCorrectAnswers}/5 questions![/]");
    Console.Write("Press the enter key to go back to the menu!");
    Console.ReadKey();
}
void ViewGameHistory()
{
    foreach (var g in gameHistory)
    {
        table.AddRow($"[green]{g.game}[/]",$"[yellow]{g.score}/5[/]");
    }
    AnsiConsole.Write(table);
    table.Rows.Clear();
    Console.Write("Press the enter key to go back to the menu!");
    Console.ReadKey();
}

void UpdateDifficultyLevel(int currentDifficultyLevel)
{
    switch (currentDifficultyLevel)
    {
        case 1:
            first = firstNumber.Next(1, 10);
            second = secondNumber.Next(1, 10);
            break;
        case 2:
            first = firstNumber.Next(10, 100);
            second = secondNumber.Next(10, 100);
            break;
        case 3:
            first = firstNumber.Next(100, 1000);
            second = secondNumber.Next(100, 1000);
            break;
        case 4:
            first = firstNumber.Next(1000, 10000);
            second = secondNumber.Next(1000, 10000);
            break;
        case 5:
            first = firstNumber.Next(10000, 100000);
            second = secondNumber.Next(10000, 100000);
            break;
    }
}