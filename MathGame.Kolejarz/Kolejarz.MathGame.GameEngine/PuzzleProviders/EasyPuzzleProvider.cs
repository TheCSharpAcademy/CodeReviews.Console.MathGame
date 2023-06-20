namespace Kolejarz.MathGame.GameEngine.PuzzleProviders;

internal class EasyPuzzleProvider : PuzzleProvider
{
    public override Puzzle GetAddition() => GetAddition(1, 10);

    public override Puzzle GetDivision() => GetDivision(2, 7, 70);

    public override Puzzle GetMultiplication() => GetMultiplication(2, 6);

    public override Puzzle GetSubtraction() => GetSubtraction(1, 20);
}
