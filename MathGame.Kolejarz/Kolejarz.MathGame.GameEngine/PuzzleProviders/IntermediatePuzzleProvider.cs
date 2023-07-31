namespace Kolejarz.MathGame.GameEngine.PuzzleProviders;

internal class IntermediatePuzzleProvider : PuzzleProvider
{
    public override Puzzle GetAddition() => GetAddition(10, 50);

    public override Puzzle GetDivision() => GetDivision(3, 9, 150);

    public override Puzzle GetMultiplication() => GetMultiplication(3, 11);

    public override Puzzle GetSubtraction() => GetSubtraction(7, 120);
}
