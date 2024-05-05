namespace MathGame.Kriz_J.GameSections;

public class Multiplication : GameSection
{
    public override void GameLoop()
    {
        while (true) { };
    }

    public override void PrintGameMenu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Multiplication}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}