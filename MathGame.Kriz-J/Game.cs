using MathGame.Kriz_J.Enums;

namespace MathGame.Kriz_J;

public abstract class Game(ResultKeeper resultKeeper)
{
    public Settings Settings { get; set; } = new();

    public bool Quit { get; set; }

    public abstract void Start();

    protected void PrintMenu(string title, string description)
    {
        Console.Clear();
        Console.WriteLine($"{title}");
        Console.WriteLine("\tThe goal of this game is to answer correctly to the set of questions presented.");
        Console.WriteLine($"\t{description}");
        Console.WriteLine("");
        Console.WriteLine("\tSelect difficulty:");
        Settings.PrintDifficulties(Settings.Difficulty);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("\tSelect mode:");
        Settings.PrintModes(Settings.Mode);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("\t[ENTER] / [SPACE] to start game, [Q] to quit.");
        Console.WriteLine();
        Console.Write("\t> ");
    }

    protected void ReadAndRouteUserSelection()
    {
        var input = ConsoleHelperMethods.ReadUserSelection();

        switch (input)
        {
            case 'Q':
                Quit = true;
                break;
            case '\r' or ' ':
                RouteMode(Settings.Mode);
                break;
            default:
                Settings.ChangeDifficultyOrMode(input);
                break;
        }
    }

    private void RouteMode(Mode mode) 
    {
        switch (mode)
        {
            case Mode.Standard:
                PlayGame();
                break;
            case Mode.Timed:
                PlayGame(timed: true);
                break;
            case Mode.Custom:
                SetNumberOfQuestions();
                PlayGame();
                Settings.NumberOfQuestions = Settings.DefaultNumberOfQuestions;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
        }
    }

    private void PlayGame(bool timed = false)
    {
        GameCountDown();

        var result = GameLogic(Settings.NumberOfQuestions, timed);

        result.SaveGameSettings(Settings);
        resultKeeper.Add(result);

        GameOverPresentation(result);
    }
    
    private static void GameOverPresentation(GameResult gameResult)
    {
        Console.WriteLine();

        PrintScore(gameResult);

        if (gameResult.TimeNeeded.HasValue)
            Console.Write($"\tTime: {gameResult.TimeNeeded:mm\\:ss\\.fff}");

        Console.Write("\t\t\t. . . Press any key to go back.");
        _ = Console.ReadKey();
    }

    private static void PrintScore(GameResult gameResult)
    {
        var result = $"{gameResult.Score}/{gameResult.NumberOfQuestions}";

        switch (gameResult.PercentageScore)
        {
            case >= 100:
                Console.Write($"\tPerfect score! {result}.");
                break;
            case >= 80:
                Console.Write($"\tImpressive! {result}.");
                break;
            case >= 60:
                Console.Write($"\tPretty good! {result}.");
                break;
            case >= 40:
                Console.Write($"\tYou can do better: {result}.");
                break;
            default:
                Console.Write($"\tTry again: {result}.");
                break;
        }
    }

    private void SetNumberOfQuestions()
    {
        const int max = Settings.MaxNumberOfQuestions;
        const int min = Settings.MinNumberOfQuestions;

        Console.Write($"You've selected custom! How many questions do you wish to try? (max {max}): ");
        while (true)
        {
            var cursorPosition = Console.GetCursorPosition();
            var numberOfQuestions = ConsoleHelperMethods.ReadUserInteger();

            if (numberOfQuestions is < min or > max)
            {
                ConsoleHelperMethods.ClearInputAndDisplayError(cursorPosition, numberOfQuestions.ToString(), $"\t! Please enter a valid number ({min} - {max}).");
                continue;
            }

            Settings.NumberOfQuestions = numberOfQuestions;
            break;
        }
    }

    private static void GameCountDown()
    {
        Console.CursorVisible = false;

        ConsoleHelperMethods.PrintTitle(StylizedTitles.Three);
        Thread.Sleep(1000);

        ConsoleHelperMethods.PrintTitle(StylizedTitles.Two);
        Thread.Sleep(1000);

        ConsoleHelperMethods.PrintTitle(StylizedTitles.One);
        Thread.Sleep(1000);

        ConsoleHelperMethods.PrintTitle(StylizedTitles.Go);

        Console.CursorVisible = true;
    }

    private GameResult GameLogic(int nrOfQuestions, bool timed)
    {
        var score = 0;
        var generator = new Random();
        var lower = Settings.NumberLimits.Lower;
        var upper = Settings.NumberLimits.Upper;

        var start = DateTime.Now;
        for (int i = 0; i < nrOfQuestions; i++)
        {
            var operatorSwitch = new OperatorSwitch(Settings.GameType);

            int a, b;
            do
            {
                a = generator.Next(lower, upper);
                b = generator.Next(lower, upper);
            } while (operatorSwitch.NumberGeneratorConditionDelegate(a, b));

            Console.Write($"\t{a} {operatorSwitch.Operator} {b} = ");

            var c = ConsoleHelperMethods.ReadUserInteger();

            if (operatorSwitch.OperatorConditionDelegate(a, b, c))
                score++;
        }
        var stop = DateTime.Now;

        return timed ? new GameResult(score, TimeNeeded: stop - start) : new GameResult(score);
    }
}