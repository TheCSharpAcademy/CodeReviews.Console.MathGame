namespace Kolejarz.MathGame.GameEngine.PuzzleProviders;

internal class HardPuzzleProvider : PuzzleProvider
{
    public override Puzzle GetAddition() => GetAddition(21, 999);

    public override Puzzle GetDivision() => GetDivision(7, 29, 800);

    public override Puzzle GetMultiplication() => GetMultiplication(6, 66);

    public override Puzzle GetSubtraction() => GetSubtraction(45, 999);
}
