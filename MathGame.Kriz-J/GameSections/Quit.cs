namespace MathGame.Kriz_J.GameSections;

public class Quit : GameSection
{
    protected override void SectionLoop()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("\tExiting game . . .");
        _ = ConsoleHelperMethods.ReadUserSelection();
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
}