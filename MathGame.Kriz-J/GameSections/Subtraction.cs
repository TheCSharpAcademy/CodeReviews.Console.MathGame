namespace MathGame.Kriz_J.GameSections;

public class Subtraction : GameSection
{
    public override void GameLoop()
    {
        while (true) { };

    }

    public override void PrintGameMenu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Subtraction}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}