namespace MathGame.Kriz_J.GameSections;

public class Subtraction : GameSection
{
    protected override void SectionLoop()
    {
        while (true) { };

    }

    protected override void StandardGame()
    {
        throw new NotImplementedException();
    }

    protected override void TimedGame()
    {
        throw new NotImplementedException();
    }

    protected override void CustomGame()
    {
        throw new NotImplementedException();
    }

    public void PrintGameMenu()
    {
        Console.Clear();
        Console.WriteLine($"{StylizedTexts.Subtraction}");
        Console.WriteLine("\tThe goal of this game is to....");
        Console.ReadKey();
    }
}