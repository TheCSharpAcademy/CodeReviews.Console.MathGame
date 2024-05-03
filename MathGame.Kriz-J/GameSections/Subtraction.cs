namespace MathGame.Kriz_J.GameSections;

public class Subtraction : GameSection
{
    public override void PrintSelection() => Console.Write("\tStarting subtraction!");

    public override void Initialize()
    {
        while (true) { };

    }

    public override void PrintMenu(char difficulty, char mode)
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Subtraction}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}