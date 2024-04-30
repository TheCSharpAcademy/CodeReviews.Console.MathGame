namespace MathGame.Kriz_J;

public abstract class PartOfGame
{
    protected PartOfGame()
    {
        Console.WriteLine();
        Console.WriteLine();

        PrintSelection();
        CountDown();
        Initialize();
    }

    public abstract void PrintSelection();

    public abstract void Initialize();

    public abstract void Menu();

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

public class Addition : PartOfGame
{
    public override void PrintSelection() => Console.Write("\tStarting addition!");

    public override void Initialize()
    {
        do
        {
            Menu();
        } while (char.ToUpper(Console.ReadKey().KeyChar) != 'Q');
    }

    public override void Menu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Addition}");
        Console.WriteLine("\tThe goal of this game is to answer correctly to the set of questions presented.");
        Console.WriteLine("\tEach question will be an addition problem of two terms.");
        Console.WriteLine("");
        Console.WriteLine("\tSelect difficulty: [E]asy [M]edium [H]ard");
        Console.WriteLine("");
        Console.WriteLine("\tSelect mode: [T]imed [F]ix");
        //Console.ReadKey();
    }
}

public class Subtraction : PartOfGame
{
    public override void PrintSelection() => Console.Write("\tStarting subtraction!");

    public override void Initialize()
    {
        while (true) { };
    }

    public override void Menu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Subtraction}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}

public class Multiplication : PartOfGame
{
    public override void PrintSelection() => Console.Write("\tStarting multiplication!");

    public override void Initialize()
    {
        while (true) { };
    }

    public override void Menu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Multiplication}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}

public class Division : PartOfGame
{
    public override void PrintSelection() => Console.Write("\tStarting division!");

    public override void Initialize()
    {
        while (true) { };
    }

    public override void Menu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Division}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}

public class RecentGames : PartOfGame
{
    public override void Initialize()
    {
        throw new NotImplementedException();
    }

    public override void Menu()
    {
        throw new NotImplementedException();
    }

    public override void PrintSelection()
    {
        throw new NotImplementedException();
    }
}

public class Quit : PartOfGame
{
    public override void PrintSelection() => Console.Write("\tThank you for playing! Exiting game . . .");

    public override void Initialize() { }

    public override void Menu() { }
}

public class NotImplemented : PartOfGame
{
    public override void PrintSelection() => Console.Write("\tNot a valid selection. Please select either of [A]/[S]/[M]/[D]/[R]/[Q] . . .");

    public override void Initialize() { }

    public override void Menu() { }
}