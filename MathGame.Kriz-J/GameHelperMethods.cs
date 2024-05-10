namespace MathGame.Kriz_J;

public class GameHelperMethods
{
    public static void GameCountDown()
    {
        Console.CursorVisible = false;

        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Three}");
        Thread.Sleep(1000);

        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Two}");
        Thread.Sleep(1000);

        Console.Clear();
        Console.WriteLine($"{StylizedTexts.One}");
        Thread.Sleep(1000);

        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Go}");

        Console.CursorVisible = true;
    }
}