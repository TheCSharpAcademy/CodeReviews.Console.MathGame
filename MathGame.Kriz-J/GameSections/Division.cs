namespace MathGame.Kriz_J.GameSections;

public class Division : GameSection
{
    public override void PrintSelection() => Console.Write("\tStarting division!");

    public override void Initialize()
    {
        while (true) { };
    }

    public override void PrintMenu(char difficulty, char mode)
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Division}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}