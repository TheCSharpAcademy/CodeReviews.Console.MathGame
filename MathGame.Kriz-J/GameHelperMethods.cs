namespace MathGame.Kriz_J;

public class GameHelperMethods
{
    public static void PrintMainMenu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.MainMenu}");
        Console.WriteLine();
        Console.WriteLine("\tSelect to play one of the following games:");
        Console.WriteLine("\t\t[A]ddition");
        Console.WriteLine("\t\t[S]ubtraction");
        Console.WriteLine("\t\t[M]ultiplication");
        Console.WriteLine("\t\t[D]ivision");
        Console.WriteLine();
        Console.WriteLine("\t\t[R]ecent games");
        Console.WriteLine("\t\t[Q]uit");
        Console.WriteLine();
        Console.Write("\t> ");
    }

    public static void PrintGameMenu(string title, string description, Difficulty difficulty, Mode mode)
    {
        Console.Clear();
        Console.WriteLine($"{title}");
        Console.WriteLine("\tThe goal of this game is to answer correctly to the set of questions presented.");
        Console.WriteLine($"\t{description}");
        Console.WriteLine("");
        Console.WriteLine("\tSelect difficulty:");
        GameSettings.PrintGameDifficulties(difficulty);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("\tSelect mode:");
        GameSettings.PrintGameModes(mode);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("\tStart game: [ENTER] or [SPACE]");
        Console.WriteLine();
        Console.WriteLine("\t[Q]uit.");
        Console.WriteLine();
        Console.Write("\t> ");
    }

    public static void GameCountDown()
    {
        for (int i = 3; i > 0; i--)
        {
            Console.Write($"{i} . . . ");
            Thread.Sleep(1000);
        }
    }
}