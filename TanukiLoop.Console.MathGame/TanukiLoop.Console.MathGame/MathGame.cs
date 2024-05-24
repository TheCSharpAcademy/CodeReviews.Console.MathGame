using Spectre.Console;
using TanukiLoop.Console.MathGame.Models;

namespace TanukiLoop.Console.MathGame;

public class MathGame
{
    public MathGameDifficulty Difficulty { get; set; } = MathGameDifficulty.Normal;
    public MathQuiz MathQuiz { get; set; } = new();

    private List<MathQuiz> QuizHistory { get; } = new();

    public void Play()
    {
        bool shouldContinue = true;

        while (shouldContinue)
        {
            var menuOption = MainMenuPrompt();
            if (menuOption == MenuOption.Quit) Environment.Exit(0);


            switch (menuOption)
            {
                case MenuOption.ViewGameHistory:
                    System.Console.WriteLine("View History Chosen!");
                    ShowQuizHistory();
                    continue;
                case MenuOption.AdditionGame:
                    System.Console.WriteLine("Addition chosen!");
                    break;
                case MenuOption.SubtractionGame:
                    System.Console.WriteLine("Subtraction Chosen");
                    break;
                case MenuOption.MultiplicationGame:
                    System.Console.WriteLine("Multiplication chosen!");
                    break;
                case MenuOption.DivisionGame:
                    System.Console.WriteLine("Division Chosen!");
                    break;
                case MenuOption.Quit:
                default:
                    shouldContinue = false;
                    Environment.Exit(0);
                    break;
            }

            var difficulty = ShowDifficultySelectionPrompt();
            var numQuestions = ShowNumQuestionsPrompt();

            var mathQuiz = GenerateMathQuiz(menuOption, difficulty, numQuestions);
            TakeQuiz(mathQuiz);
        }
    }

    private void TakeQuiz(MathQuiz mathQuiz)
    {
        while (mathQuiz.HasNext())
        {
            var question = mathQuiz.Next();

            PromptMathQuestion(question ?? throw new InvalidOperationException());
        }

        // Afterward, add the quiz to quiz history
        QuizHistory.Add(mathQuiz);
    }

    private void ShowQuizHistory()
    {
        AnsiConsole.Clear();
        // Create table
        var table = new Table();
        // Add some columns
        table.AddColumn("Date").Centered();
        table.AddColumn("Quiz Type").Centered();
        table.AddColumn("Correct Questions").Centered();
        table.AddColumn("Total Questions").Centered();

        table.LeftAligned();

        // Add some rows

        foreach (var quiz in QuizHistory)
        {
            var score = quiz.NumQuestionsCorrect;
            table.AddRow(quiz.StartTime.ToShortDateString(), quiz.QuizType ?? "QUIZ TYPE NOT FOUND", score.ToString(),
                quiz.MathQuestions.Count.ToString());
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("[grey]Press any key to continue[/]");
        System.Console.ReadKey();
    }

    private void PromptMathQuestion(MathQuestion mathQuestion)
    {
        AnsiConsole.Clear();
        var answer= AnsiConsole.Prompt(
            new TextPrompt<int>($"{mathQuestion.Operand1} {mathQuestion.OperationSymbol} {mathQuestion.Operand2} = ")
                .PromptStyle("yellow")
                .ValidationErrorMessage("[red]That's not a valid integer number[/]")
        );

        AnsiConsole.WriteLine();
        AnsiConsole.Write(
            new Rule("[yellow]Results[/]")
                .RuleStyle("grey")
        );

        mathQuestion.UserAnswer = answer;
        var gotQuestionCorrect = mathQuestion.ExpectedAnswer == mathQuestion.UserAnswer;

        AnsiConsole.Write(
            new Table()
                .AddColumns("Result", "Your Answer", "Correct Answer")
                .RoundedBorder()
                .BorderColor(Color.Grey)
                .AddRow(
                    (gotQuestionCorrect ? "[bold green] Correct! :)[/]" : "[bold red]Wrong! :([/]"),
                    mathQuestion.UserAnswer.ToString(),
                    mathQuestion.ExpectedAnswer.ToString()
                )
        );


        AnsiConsole.MarkupLine("[grey]Press any key to continue[/]");
        System.Console.ReadKey();
    }

    private MathQuiz GenerateMathQuiz(MenuOption menuOption, MathGameDifficulty difficulty, int numQuestions)
    {
        // Depending on the game difficulty, we will limit the operand value range
        MathQuiz mathQuiz = new();


        for (int i = 0; i < numQuestions; i++)
        {
            MathQuestion question;
            switch (menuOption)
            {
                case MenuOption.AdditionGame:
                    mathQuiz.QuizType = "Addition";
                    question = GenerateMathQuestion(difficulty, MathOperation.Addition);
                    break;
                case MenuOption.SubtractionGame:
                    mathQuiz.QuizType = "Subtraction";
                    question = GenerateMathQuestion(difficulty, MathOperation.Subtraction);
                    break;
                case MenuOption.MultiplicationGame:
                    mathQuiz.QuizType = "Multiplication";
                    question = GenerateMathQuestion(difficulty, MathOperation.Multiplication);
                    break;
                case MenuOption.DivisionGame:
                    mathQuiz.QuizType = "Division";
                    question = GenerateMathQuestion(difficulty, MathOperation.Division);
                    break;
                case MenuOption.RandomGame:
                    mathQuiz.QuizType = "Random";
                    question = GenerateMathQuestion(difficulty, GetRandomMathOperation());
                    break;
                default:
                    throw new Exception("Invalid option");
            }

            mathQuiz.AddQuestion(question);
        }

        return mathQuiz;
    }

    private MathOperation GetRandomMathOperation()
    {
        var enumValues = (MathOperation[])Enum.GetValues(typeof(MathOperation));
        var random = new Random();

        return enumValues[random.Next(0, enumValues.Length)];
    }

    private MathQuestion GenerateMathQuestion(MathGameDifficulty difficulty, MathOperation mathOperation)
    {
        // Create the math question

        var mathQuestion = new MathQuestion()
        {
            Operand1 = GetRandomOperand(difficulty),
            Operand2 = GetRandomOperand(difficulty),
        };

        switch (mathOperation)
        {
            case MathOperation.Addition:
                mathQuestion.Operation = MathOperation.Addition;
                mathQuestion.OperationSymbol = "+";
                mathQuestion.ExpectedAnswer = mathQuestion.Operand1 + mathQuestion.Operand2;
                break;
            case MathOperation.Subtraction:
                mathQuestion.Operation = MathOperation.Subtraction;
                mathQuestion.OperationSymbol = "-";
                mathQuestion.ExpectedAnswer = mathQuestion.Operand1 - mathQuestion.Operand2;
                break;
            case MathOperation.Multiplication:
                mathQuestion.Operation = MathOperation.Multiplication;
                mathQuestion.OperationSymbol = "*";
                mathQuestion.ExpectedAnswer = mathQuestion.Operand1 * mathQuestion.Operand2;
                break;
            case MathOperation.Division:
                EnsureDivisionQuestionOperandsResultInIntegerQuotient(mathQuestion, difficulty);
                mathQuestion.Operation = MathOperation.Division;
                mathQuestion.OperationSymbol = "/";
                mathQuestion.ExpectedAnswer = mathQuestion.Operand1 / mathQuestion.Operand2;
                break;
        }

        return mathQuestion;
    }

    private void EnsureDivisionQuestionOperandsResultInIntegerQuotient(MathQuestion divisionQuestion,
        MathGameDifficulty difficulty)
    {
        while (divisionQuestion.Operand2 == 0 || divisionQuestion.Operand1 % divisionQuestion.Operand2 != 0)
        {
            divisionQuestion.Operand1 = GetRandomOperand(difficulty);
            divisionQuestion.Operand2 = GetRandomOperand(difficulty);
        }
    }

    private int GetRandomOperand(MathGameDifficulty difficulty)
    {
        int maxOperandValue = difficulty switch
        {
            MathGameDifficulty.Easy => 10,
            MathGameDifficulty.Normal => 12,
            MathGameDifficulty.Hard => 100,
            _ => 12,
        };

        return GetRandomInt(0, maxOperandValue + 1);
    }

    private int GetRandomInt(int min, int max)
    {
        var random = new Random();
        return random.Next(min, max);
    }

    private int ShowNumQuestionsPrompt()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<int>("How many Questions do you want to solve?")
                .PromptStyle("yellow")
                .ValidationErrorMessage("[red]That's not a valid integer number[/]")
                .Validate(age =>
                {
                    return age switch
                    {
                        <= 0 => ValidationResult.Error("[red]You must solve at least one question[/]"),
                        _ => ValidationResult.Success(),
                    };
                }));
    }


    private MenuOption MainMenuPrompt()
    {
        AnsiConsole.Clear();
        var menuSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold black on yellow]Main Menu:[/] Please select an option and press enter")
                .MoreChoicesText("[grey](Use arrow keys or begin typing an option until its selected)[/]")
                .PageSize(10)
                .AddChoices(new[]
                {
                    "View Game History",
                    "Addition Game",
                    "Subtraction Game",
                    "Multiplication Game",
                    "Division Game",
                    "Quit",
                })
                .EnableSearch()
        );

        return ConvertMenuSelectionToMenuOption(menuSelection);
    }

    private MathGameDifficulty ShowDifficultySelectionPrompt()
    {
        var menuSelection = AnsiConsole.Prompt(
            new SelectionPrompt<MathGameDifficulty>()
                .Title("[bold black on yellow]Main Menu:[/] Please select an option and press enter")
                .MoreChoicesText("[grey](Use arrow keys or begin typing an option until its selected)[/]")
                .AddChoices(new[]
                {
                    MathGameDifficulty.Easy,
                    MathGameDifficulty.Normal,
                    MathGameDifficulty.Hard,
                }).EnableSearch()
        );

        return menuSelection;
    }

    private MenuOption ConvertMenuSelectionToMenuOption(string menuSelection)
    {
        if (!Enum.TryParse(menuSelection.Replace(" ", ""), true, out MenuOption menuOption))
        {
            throw new ArgumentException("Invalid menu selection");
        }

        return menuOption;
    }
}

public enum MenuOption
{
    ViewGameHistory,
    AdditionGame,
    SubtractionGame,
    MultiplicationGame,
    DivisionGame,
    RandomGame,
    Quit,
}

public enum MathGameDifficulty
{
    Easy,
    Normal,
    Hard
}