namespace MathGame.Kriz_J.GameSections;

public class Quit : GameSection
{
    public override void PrintSelection() => Console.Write("\tThank you for playing!");

    public override void Initialize() { }

    public override void PrintMenu(char difficulty, char mode) { }
}