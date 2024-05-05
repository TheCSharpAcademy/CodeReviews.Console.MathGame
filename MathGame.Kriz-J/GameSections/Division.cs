namespace MathGame.Kriz_J.GameSections;

public class Division : GameSection
{
    public override void GameLoop()
    {
        while (true) { };
    }

    public override void PrintGameMenu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Division}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}