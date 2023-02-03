namespace Kolejarz.MathGame.GameEngine.PuzzleProviders;

internal interface IPuzzleProvider
{
    public Puzzle GetPuzzle(Operation operation);
    public Puzzle GetAddition();
    public Puzzle GetSubtraction();
    public Puzzle GetMultiplication();
    public Puzzle GetDivision();
}
