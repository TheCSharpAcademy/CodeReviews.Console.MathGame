namespace MathGame.Kriz_J.GameSections;

public class NotImplemented : GameSection
{
    public override void PrintSelection() => Console.Write("\tNot a valid selection. Please select either of [A]/[S]/[M]/[D]/[R]/[Q] . . .");

    public override void Initialize() => Console.ReadKey();

    public override void PrintMenu(char difficulty, char mode) { }
}