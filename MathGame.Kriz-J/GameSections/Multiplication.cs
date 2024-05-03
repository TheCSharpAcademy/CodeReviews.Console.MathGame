namespace MathGame.Kriz_J.GameSections;

public class Multiplication : GameSection
{
    public override void PrintSelection() => Console.Write("\tStarting multiplication!");

    public override void Initialize()
    {
        while (true) { };
    }

    public override void PrintMenu(char difficulty, char mode)
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Multiplication}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}