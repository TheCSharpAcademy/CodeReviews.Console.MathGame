namespace MathGame.Kriz_J;

public abstract class Game
{
    protected readonly List<ScoreRecord> ScoreKeeper;

    public Settings Settings { get; set; } = new();

    public bool Quit { get; set; }

    protected Game(List<ScoreRecord> scoreKeeper)
    {
        ScoreKeeper = scoreKeeper;
        Loop();
    }

    protected abstract void Loop();

    protected abstract void StandardGame();
    
    protected abstract void TimedGame();
    
    protected abstract void CustomGame();

    protected static void PrintMenu(string title, string description, Difficulty difficulty, Mode mode)
    {
        Console.Clear();
        Console.WriteLine($"{title}");
        Console.WriteLine("\tThe goal of this game is to answer correctly to the set of questions presented.");
        Console.WriteLine($"\t{description}");
        Console.WriteLine("");
        Console.WriteLine("\tSelect difficulty:");
        Settings.PrintDifficulties(difficulty);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("\tSelect mode:");
        Settings.PrintModes(mode);
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
                StandardGame();
                break;
            case Mode.Timed:
                TimedGame();
                break;
            case Mode.Custom:
                CustomGame();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
        }
    }
    
    protected void PrintScore(int score)
    {
        var nrOfQuestions = Settings.NumberOfQuestions;

        var percentage = 1.0 * score / nrOfQuestions;

        Console.WriteLine();
        if (score == nrOfQuestions)
            Console.Write($"\tPerfect score! {score}/{nrOfQuestions}.");
        else if (percentage >= 0.8)
            Console.Write($"\tImpressive! {score}/{nrOfQuestions}.");
        else if (percentage >= 0.6)
            Console.Write($"\tPretty good! {score}/{nrOfQuestions}.");
        else if (percentage >= 0.4)
            Console.Write($"\tYou can do better: {score}/{nrOfQuestions}.");
        else
            Console.Write($"\tTry again: {score}/{nrOfQuestions}.");
    }

    protected void SetNumberOfQuestions()
    {
        //TODO: Repeat question if bad value
        Console.Write("\tYou've selected custom! How many questions do you wish to try? (max 30): ");
        var nrOfQuestions = ConsoleHelperMethods.ReadUserInteger();

        Settings.NumberOfQuestions = nrOfQuestions switch
        {
            < 0 => 0,
            > 30 => 30,
            _ => nrOfQuestions
        };
    }
}