namespace MathGame.Kriz_J;

public abstract class GameSection
{
    protected GameSection()
    {
        Console.WriteLine();
        Console.WriteLine();

        PrintSelection();
        CountDown();
        Initialize();
    }

    public abstract void PrintSelection();

    public abstract void Initialize();

    public abstract void PrintMenu();

    private static void CountDown()
    {
        Console.Write(" ");
        for (int i = 3; i > 0; i--)
        {
            Console.Write($"{i} . . ");
            Thread.Sleep(400);
        }
    }
}

public class Addition : GameSection
{
    public override void PrintSelection() => Console.Write("\tStarting addition!");

    public override void Initialize()
    {
        do
        {
            PrintMenu();
        } while (char.ToUpper(Console.ReadKey().KeyChar) != 'Q');
    }

    public override void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Addition}");
        Console.WriteLine("\tThe goal of this game is to answer correctly to the set of questions presented.");
        Console.WriteLine("\tEach question will be an addition problem of two terms.");
        Console.WriteLine("");
        Console.WriteLine("\tSelect difficulty:");
        SetDifficulty('H');
        Console.WriteLine("");
        Console.WriteLine("\tSelect mode:");
        Console.WriteLine("\t\t[T]imed [F]ix");
        //Console.ReadKey();
    }

    private void SetDifficulty(char? difficulty = null)
    {
        switch (difficulty)
        {
            case 'E':
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t\t[E]asy");
                Console.ResetColor();
                Console.Write(" [M]edium [H]ard");
                break;
            case 'M':
                Console.Write("\t\t[E]asy ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[M]edium");
                Console.ResetColor();
                Console.Write(" [H]ard");
                break;
            case 'H':
                Console.Write("\t\t[E]asy [M]edium ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[H]ard");
                Console.ResetColor();
                break;
            default:
                Console.WriteLine("\t\t[E]asy [M]edium [H]ard");
                break;
        }
    }
}

public class Subtraction : GameSection
{
    public override void PrintSelection() => Console.Write("\tStarting subtraction!");

    public override void Initialize()
    {
        while (true) { };
    }

    public override void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Subtraction}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}

public class Multiplication : GameSection
{
    public override void PrintSelection() => Console.Write("\tStarting multiplication!");

    public override void Initialize()
    {
        while (true) { };
    }

    public override void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Multiplication}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}

public class Division : GameSection
{
    public override void PrintSelection() => Console.Write("\tStarting division!");

    public override void Initialize()
    {
        while (true) { };
    }

    public override void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Division}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}

public class RecentGames : GameSection
{
    public override void Initialize()
    {
        throw new NotImplementedException();
    }

    public override void PrintMenu()
    {
        throw new NotImplementedException();
    }

    public override void PrintSelection()
    {
        throw new NotImplementedException();
    }
}

public class Quit : GameSection
{
    public override void PrintSelection() => Console.Write("\tThank you for playing! Exiting game . . .");

    public override void Initialize() { }

    public override void PrintMenu() { }
}

public class NotImplemented : GameSection
{
    public override void PrintSelection() => Console.Write("\tNot a valid selection. Please select either of [A]/[S]/[M]/[D]/[R]/[Q] . . .");

    public override void Initialize() { }

    public override void PrintMenu() { }
}