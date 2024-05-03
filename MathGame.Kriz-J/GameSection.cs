using static MathGame.Kriz_J.GameHelperMethods;

namespace MathGame.Kriz_J;

public abstract class GameSection
{
    public GameSettings Settings { get; set; } = new();

    public bool QuitPressed { get; set; }

    protected GameSection()
    {
        Console.WriteLine();
        Console.WriteLine();

        PrintSelection();
        Initialize();
    }

    public abstract void PrintSelection();

    public abstract void Initialize();

    public abstract void PrintMenu(char difficulty, char mode);

}

public class Addition : GameSection
{
    public override void PrintSelection() => Console.Write("\tStarting addition!");

    public override void Initialize()
    {
        while (!QuitPressed)
        {
            PrintMenu(Settings.Difficulty, Settings.Mode);
            ReadUserInput();
        }
    }

    private void ReadUserInput()
    {
        var input = char.ToUpper(Console.ReadKey().KeyChar);

        switch (input)
        {
            case 'E' or 'M' or 'H':
                Settings.Difficulty = input;
                break;
            case 'S' or 'T':
                Settings.Mode = input;
                break;
            case ' ':
                StartGame();
                break;
            case 'Q':
                QuitPressed = true;
                break;
        }
    }

    private void StartGame()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("\t");
        GameCountDown();
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();

        var score = 0;
        var random = new Random();
        for (int i = 0; i < 15; i++)
        {
            var a = random.Next(Settings.IntegerBounds.Lower, Settings.IntegerBounds.Upper);
            var b = random.Next(Settings.IntegerBounds.Lower, Settings.IntegerBounds.Upper);
            Console.Write($"\t{a} + {b} = ");

            if (!int.TryParse(Console.ReadLine(), out var c))
                return;

            if (a + b == c)
            {
                //Console.Write("\tCorrect!");
                score++;
            }
            //else
            //Console.Write("\tINCORRECT!");
            //Console.Write($"{Environment.NewLine}");
        }

        Console.WriteLine();
        Console.WriteLine($"\tNot bad... {score}/{15}");
        Console.ReadKey();
    }

    public override void PrintMenu(char difficulty, char mode)
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Addition}");
        Console.WriteLine("\tThe goal of this game is to answer correctly to the set of questions presented.");
        Console.WriteLine("\tEach question will be an addition problem of two terms.");
        Console.WriteLine("");
        Console.WriteLine("\tSelect difficulty:");
        SetGameDifficulty(difficulty);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("\tSelect mode:");
        SetGameMode(mode);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("\tStart game: [SPACE]");
        Console.WriteLine();
        Console.WriteLine("\t[Q]uit.");
        Console.WriteLine();
        Console.Write("\t> ");
    }
}